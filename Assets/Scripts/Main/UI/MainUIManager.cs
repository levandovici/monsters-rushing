using UnityEngine.UI;
using UnityEngine;
using System;
using Vocabulary;

public class MainUIManager : MonoBehaviour
{
    [SerializeField]
    private MainUIPanel _mainUIPanel;

    [SerializeField]
    private ShopUIPanel _shopUIPanel;

    [SerializeField]
    private CarsUIPanel _carsUIPanel;

    [SerializeField]
    private SettingsUIPanel _settingsUIPanel;

    [SerializeField]
    private TasksUIPanel _tasksUIPanel;

    [SerializeField]
    private PlayerInfoUIPanel _playerInfoPanel;

    [SerializeField]
    private EditNameUIPanel _editNamePanel;

    [SerializeField]
    private SwitchAccountUIPanel _switchAccountPanel;

    [SerializeField]
    private InternetRequireUIPanel _internetRequirePanel;

    [SerializeField]
    private InventoryUIPanel _inventoryPanel;

    [SerializeField]
    private OpenChestUIPanel _openChestPanel;

    [SerializeField]
    private YouGotUIPanel _youGotPanel;

    [SerializeField]
    private PromoCodeErrorUIPanel _promoCodeErrorPanel;

    [SerializeField]
    private Button _back;



    public MainUIPanel Main => _mainUIPanel;
    public ShopUIPanel Shop => _shopUIPanel;
    public CarsUIPanel Cars => _carsUIPanel;
    public SettingsUIPanel Settings => _settingsUIPanel;
    public TasksUIPanel Tasks => _tasksUIPanel;
    public PlayerInfoUIPanel PlayerInfo => _playerInfoPanel;
    public EditNameUIPanel EditName => _editNamePanel;
    public SwitchAccountUIPanel SwitchAccount => _switchAccountPanel;
    public InternetRequireUIPanel InternetRequire => _internetRequirePanel;

    public InventoryUIPanel Inventory => _inventoryPanel;

    public OpenChestUIPanel OpenChest => _openChestPanel;

    public YouGotUIPanel YouGot => _youGotPanel;

    public PromoCodeErrorUIPanel PromoCodeError =>  _promoCodeErrorPanel;



    public event Action OnMainOpened;
    public event Action OnShopOpened;
    public event Action OnCarsOpened;
    public event Action OnSettingsOpened;
    public event Action OnTasksOpened;
    public event Action OnPlayerInfoOpened;
    public event Action OnEditNameOpened;
    public event Action OnSwitchAccountOpened;
    public event Action OnInternetRequireOpened;
    public event Action OnInventoryOpened;
    public event Action OnOpenChestOpened;
    public event Action OnYouGotOpened;
    public event Action OnPromoCodeErrorOpened;



    public void OpenMain()
    {
        _mainUIPanel.Show();

        _shopUIPanel.Hide();
        _carsUIPanel.Hide();
        _settingsUIPanel.Hide();
        _tasksUIPanel.Hide();
        _playerInfoPanel.Hide();
        _editNamePanel.Hide();
        _internetRequirePanel.Hide();
        _inventoryPanel.Hide();
        _openChestPanel.Hide();
        _youGotPanel.Hide();
        _promoCodeErrorPanel.Hide();

        _back.gameObject.SetActive(false);

        OnMainOpened.Invoke();
    }

    public void OpenShop()
    {
        _mainUIPanel.Hide();
        _shopUIPanel.Show();
        _shopUIPanel.ResetPromoCode();
        _back.gameObject.SetActive(true);

        OnShopOpened.Invoke();
    }

    public void OpenCars()
    {
        _mainUIPanel.Hide();
        _carsUIPanel.Show();
        _back.gameObject.SetActive(true);

        OnCarsOpened.Invoke();
    }

    public void OpenSettings()
    {
        _mainUIPanel.Hide();
        _settingsUIPanel.Show();
        _back.gameObject.SetActive(true);

        OnSettingsOpened.Invoke();
    }

    public void OpenTasks()
    {
        _mainUIPanel.Hide();
        _tasksUIPanel.Show();
        _back.gameObject.SetActive(true);

        OnTasksOpened.Invoke();
    }

    public void OpenPlayerInfo()
    {
        _mainUIPanel.Hide();
        _playerInfoPanel.Show();
        _back.gameObject.SetActive(true);

        OnPlayerInfoOpened.Invoke();
    }

    public void OpenEditName(bool newName, int price)
    {
        _editNamePanel.Show(newName, price);
        _back.gameObject.SetActive(false);

        OnEditNameOpened.Invoke();
    }

    public void OpenInternetRequire()
    {
        _internetRequirePanel.Show();
        _back.gameObject.SetActive(false);

        OnInternetRequireOpened.Invoke();
    }

    public void OpenSwitchAccount()
    {
        _mainUIPanel.Hide();
        _switchAccountPanel.Show();
        _back.gameObject.SetActive(false);

        OnSwitchAccountOpened.Invoke();
    }

    public void OpenInventory()
    {
        _mainUIPanel.Hide();
        _inventoryPanel.Show();
        _back.gameObject.SetActive(true);

        OnInventoryOpened.Invoke();
    }

    public void OpenOpenChest()
    {
        _openChestPanel.Show();
        _back.gameObject.SetActive(true);

        OnOpenChestOpened.Invoke();
    }

    public void OpenYouGot()
    {
        _youGotPanel.Show();
        OnYouGotOpened.Invoke();
    }

    public void OpenPromoCodeError()
    {
        _promoCodeErrorPanel.Show();
        OnPromoCodeErrorOpened.Invoke();
    }



    private void Awake()
    {
        _back.onClick.AddListener(OpenMain);
        _mainUIPanel.OnShopClicked += () => OpenShop();
        _mainUIPanel.OnCarsClicked += () => OpenCars();
        _mainUIPanel.OnSettingsClicked += () => OpenSettings();
        _mainUIPanel.OnTasksClicked += () => OpenTasks();
        _mainUIPanel.OnAdsOpenShopClicked += () => OpenShop();
    }

    private void OnDestroy()
    {
        _back.onClick.RemoveAllListeners();
        _mainUIPanel.OnShopClicked -= () => OpenShop();
        _mainUIPanel.OnCarsClicked -= () => OpenCars();
        _mainUIPanel.OnSettingsClicked -= () => OpenSettings();
        _mainUIPanel.OnTasksClicked -= () => OpenTasks();
        _mainUIPanel.OnAdsOpenShopClicked -= () => OpenShop();
    }



    public void SetLanguage(SystemLanguage language)
    {
        _shopUIPanel.SetTitle(Words.GetWord(Word.shop, language));
        _settingsUIPanel.SetTitle(Words.GetWord(Word.settings, language));
        _tasksUIPanel.SetTitle(Words.GetWord(Word.tasks, language));
        _inventoryPanel.SetTitle(Words.GetWord(Word.inventory, language));
        _promoCodeErrorPanel.SetTitle(Words.GetWord(Word.promo_code, language));
        _youGotPanel.SetTitle(Words.GetWord(Word.you_got, language));

        _tasksUIPanel.SetLanguage(language);

        _promoCodeErrorPanel.SetLanguage(language);
        _youGotPanel.SetLanguage(language);

        _shopUIPanel.SetLanguage(language);
        _carsUIPanel.SetLanguage(language);
        _settingsUIPanel.SetLanguage(language);
        _mainUIPanel.SetLanguage(language);

        _editNamePanel.SetLanguage(language);
        _playerInfoPanel.SetLanguage(language);
        _switchAccountPanel.SetLanguage(language);

        _internetRequirePanel.SetLanguage(language);
    }
}