using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class DeepLinkHandler : MonoBehaviour
{
    private static DeepLinkHandler _instance;
    private string _pendingPromoCode = null;
    private bool _hasPendingDeepLink = false;

    public static DeepLinkHandler Instance
    {
        get { return _instance; }
    }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);

        Application.deepLinkActivated += OnDeepLink;
        
        if (!string.IsNullOrEmpty(Application.absoluteURL))
        {
            OnDeepLink(Application.absoluteURL);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnDeepLink(string url)
    {
        Debug.Log("Deep link activated: " + url);

        try
        {
            Uri uri = new Uri(url);
            string query = uri.Query;
            string promo = GetQueryParam(query, "code");

            if (!string.IsNullOrEmpty(promo))
            {
                _pendingPromoCode = promo;
                _hasPendingDeepLink = true;
                HandleDeepLinkInCurrentScene();
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Deep link error: " + e.Message);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (_hasPendingDeepLink && !string.IsNullOrEmpty(_pendingPromoCode))
        {
            HandleDeepLinkInCurrentScene();
        }
    }

    void HandleDeepLinkInCurrentScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        Debug.Log($"Current scene: {currentSceneIndex}, Handling deep link with promo: {_pendingPromoCode}");

        // Scene indices based on your Loading.cs:
        // 0 = Loading scene
        // 1 = Main scene  
        // 2 = Game scene
        
        if (currentSceneIndex == 1) // Main scene
        {
            HandleDeepLinkInMainScene();
        }
        else if (currentSceneIndex == 2) // Game scene
        {
            HandleDeepLinkInGameScene();
        }
        else // Loading scene or any other scene
        {
            // Wait for scene to load, will be handled in OnSceneLoaded
            Debug.Log("In loading scene, waiting for scene transition...");
        }
    }

    void HandleDeepLinkInMainScene()
    {
        Debug.Log("Opening shop with promo code in main scene");
        
        // Find MainManager and trigger shop opening with promo code
        MainManager mainManager = FindObjectOfType<MainManager>();
        if (mainManager != null)
        {
            // Open shop and apply promo code
            mainManager.OpenShopWithPromoCode(_pendingPromoCode);
        }
        else
        {
            Debug.LogError("MainManager not found in main scene!");
        }

        ClearPendingDeepLink();
    }

    void HandleDeepLinkInGameScene()
    {
        Debug.Log("Quitting game scene to main with promo code");
        
        // Save current game state and return to main scene
        SaveLoadManager.Save();
        
        // Set loading ID to main scene and load
        Loading.ID = 1; // main scene
        SceneManager.LoadScene(0); // loading scene
        
        // The promo code will be handled when main scene loads
        // Don't clear pending deep link yet
    }

    void ClearPendingDeepLink()
    {
        _pendingPromoCode = null;
        _hasPendingDeepLink = false;
    }

    string GetQueryParam(string query, string key)
    {
        if (string.IsNullOrEmpty(query))
            return null;

        query = query.TrimStart('?');
        var pairs = query.Split('&');

        foreach (var pair in pairs)
        {
            var kv = pair.Split('=');
            if (kv.Length == 2 && kv[0] == key)
                return Uri.UnescapeDataString(kv[1]);
        }
        return null;
    }

    // Public method to be called from MainManager
    public void ApplyPendingPromoCode()
    {
        if (_hasPendingDeepLink && !string.IsNullOrEmpty(_pendingPromoCode))
        {
            HandleDeepLinkInMainScene();
        }
    }
}
