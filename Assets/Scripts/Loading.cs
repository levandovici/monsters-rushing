using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System.Text;
using System;

public class Loading : MonoBehaviour
{
    private static int _id = 1;



    public static int ID
    {
        set { _id = value; }
    }

    

    [SerializeField]
    private Slider _loadBar = null;
    [SerializeField]
    private Text _loadBarText = null;



    private async void Awake()
    {
        //await TimeManager.GetNetworkTime();
    }



    private void Start()
    {
        SaveLoadManager.Load();



        StartCoroutine(LoadScene(_id));
        _id = 1;
    }



    private IEnumerator LoadScene(int id)
    {
        yield return new WaitForSeconds(0.2f);

        float progress = 0f;
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(id);

        while (!asyncOperation.isDone)
        {
            if (progress < asyncOperation.progress)
                progress = asyncOperation.progress;


            _loadBar.value = progress;
            _loadBarText.text = $"{(int)(progress * 100f)}%";

            yield return null;
        }
    }
}