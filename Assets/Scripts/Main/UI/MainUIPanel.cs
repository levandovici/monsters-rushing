using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;
using System.Text;
using System;
using Vocabulary;

public class MainUIPanel : UIPanel
{
    [SerializeField]
    private Text _name;

    [SerializeField]
    private Button _shop;
    [SerializeField]
    private Text _shopText;
    [SerializeField]
    private Button _cars;
    [SerializeField]
    private Text _carsText;
    [SerializeField]
    private Button _inventory;
    [SerializeField]
    private Text _invetoryText;
    [SerializeField]
    private Button _play;
    [SerializeField]
    private Text _playText;

    [SerializeField]
    private Button _settings;
    [SerializeField]
    private Button _tasks;

    [SerializeField]
    private GameObject _newKeyTimePanel;
    [SerializeField]
    private Text _newKeyTime;
    [SerializeField]
    private Text _keys;
    [SerializeField]
    private Text _water;
    [SerializeField]
    private Text _timeEnergy;

    [SerializeField]
    private Button _adsOpenShop;
    [SerializeField]
    private Button _openPlayerInfo;

    [SerializeField]
    private GameObject _tasksDisponible;
    [SerializeField]
    private GameObject _tasksFinished;
    [SerializeField]
    private Text _disponibleTasks;
    [SerializeField]
    private Text _finishedTasks;



    public event Action OnShopClicked;
    public event Action OnCarsClicked;
    public event Action OnInventoryClicked;
    public event Action OnPlayClicked;

    public event Action OnSettingsClicked;
    public event Action OnTasksClicked;

    public event Action OnAdsOpenShopClicked;
    public event Action OnOpenPlayerInfoClicked;



    public bool SetInteractableShowAdd
    {
        set
        {
            if(_adsOpenShop != null)
            _adsOpenShop.gameObject.SetActive(value);
        }
    }

    public bool SetInteractablePlay
    {
        set
        {
            _play.interactable = value;
        }
    }



    public void SetNewKeyTime(int seconds)
    {
        bool active = seconds >= 0;

        _newKeyTimePanel.SetActive(active);

        if(active)
        {
            int min = seconds / 60;
            int sec = seconds - min * 60;

            _newKeyTime.text = $"{min.ToString("0")}:{sec.ToString("00")}";
        }
    }

    public void SetKeys(int count, int max)
    {
        if(_keys != null)
        _keys.text = $"{count}/{max}";

        if(_play != null)
        _play.interactable = count > 0;
    }

    public void SetWater(int count)
    {
        _water.text = count.ToString("### ### ### ### ### ##0");
    }

    public void SetTimeEnergy(int count)
    {
        _timeEnergy.text = count.ToString("### ### ### ### ### ##0");
    }

    public void SetTasks(int finished, int disponible)
    {
        if (finished > 0)
        {
            _finishedTasks.text = finished.ToString();

            _tasksFinished.SetActive(true);
            _tasksDisponible.SetActive(false);
        }
        else if(disponible > 0)
        {
            _disponibleTasks.text = disponible.ToString();

            _tasksFinished.SetActive(false);
            _tasksDisponible.SetActive(true);
        }
        else
        {
            _tasksFinished.SetActive(false);
            _tasksDisponible.SetActive(false);
        }
    }



    public void SetLanguage(SystemLanguage language)
    {
        _shopText.text = Words.GetWord(Word.shop, language);
        _carsText.text = Words.GetWord(Word.cars, language);
        _invetoryText.text = Words.GetWord(Word.inventory, language);
        _playText.text = Words.GetWord(Word.play, language);
    }



    public void SetName(string name)
    {
        _name.text = name;
    }


    private void Start()
    {
        _shop.onClick.AddListener(() => OnShopClicked.Invoke());
        _cars.onClick.AddListener(() => OnCarsClicked.Invoke());
        _inventory.onClick.AddListener(() => OnInventoryClicked.Invoke());
        _play.onClick.AddListener(() => OnPlayClicked.Invoke());

        _settings.onClick.AddListener(() => OnSettingsClicked.Invoke());
        _tasks.onClick.AddListener(() => OnTasksClicked.Invoke());

        _adsOpenShop.onClick.AddListener(() => OnAdsOpenShopClicked.Invoke());
        _openPlayerInfo.onClick.AddListener(() => OnOpenPlayerInfoClicked.Invoke());
    }



    private void OnDestroy()
    {
        _shop.onClick.RemoveAllListeners();
        _cars.onClick.RemoveAllListeners();
        _inventory.onClick.RemoveAllListeners();
        _play.onClick.RemoveAllListeners();

        _settings.onClick.RemoveAllListeners();
        _tasks.onClick.RemoveAllListeners();

        _adsOpenShop.onClick.RemoveAllListeners();
        _openPlayerInfo.onClick.RemoveAllListeners();
    }
}