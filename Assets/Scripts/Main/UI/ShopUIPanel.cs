using UnityEngine.UI;
using UnityEngine;
using System;
using Vocabulary;

public class ShopUIPanel : UIPanel, IUITitled
{
    [SerializeField]
    private Text _title;

    [SerializeField]
    private Button _buyX2Water;

    [SerializeField]
    private Button _showAdForKey;
    [SerializeField]
    private Button _showAdForTimeEnergy;
    [SerializeField]
    private Button _showAdForFuel;
    [SerializeField]
    private Button _showAdForToolBox;
    [SerializeField]
    private Button _showAdForSmallChest;


    [SerializeField]
    private Button _buy10000Water;
    [SerializeField]
    private Button _buy100000Water;
    [SerializeField]
    private Button _buy1000000Water;

    [SerializeField]
    private Button _buy50TimeEnergy;
    [SerializeField]
    private Button _buy250TimeEnergy;
    [SerializeField]
    private Button _buy1000TimeEnergy;
    [SerializeField]
    private Button _buy5000TimeEnergy;


    [SerializeField]
    private Text _promoCodeTitle;
    [SerializeField]
    private Text _enterText;
    [SerializeField]
    private Button _enter;
    [SerializeField]
    private GameObject _networkRequire;
    [SerializeField]
    private Text _networkRequireText;

    [SerializeField]
    private Button _buyMiddleChest;
    [SerializeField]
    private Button _buyBigChest;

    [SerializeField]
    private InputField _n1;
    [SerializeField]
    private InputField _n2;
    [SerializeField]
    private InputField _n3;
    [SerializeField]
    private InputField _n4;
    [SerializeField]
    private InputField _n5;



    public bool SetInteractableShowAdd
    {
        set
        {
            if (_showAdForKey != null)
                _showAdForKey.interactable = value;

            if (OnShowAdForTimeEnergy != null)
                _showAdForTimeEnergy.interactable = value;

            if (_showAdForFuel != null)
                _showAdForFuel.interactable = value;

            if (_showAdForToolBox != null)
                _showAdForToolBox.interactable = value;

            if (_showAdForSmallChest != null)
                _showAdForSmallChest.interactable = value;
        }
    }

    public bool SetInteractablePromoCode
    {
        set
        {
            _networkRequire.SetActive(!value);
            _enter.interactable = value;
        }
    }

    public bool SetBoughtX2Water
    {
        set => _buyX2Water.interactable = !value;
    }

    public bool SetInteractableBuy10000Water
    {
        set => _buy10000Water.interactable = value;
    }

    public bool SetInteractableBuy100000Water
    {
        set => _buy100000Water.interactable = value;
    }

    public bool SetInteractableBuy1000000Water
    {
        set => _buy1000000Water.interactable = value;
    }

    public bool SetInteractableBuyMiddleChest
    {
        set => _buyMiddleChest.interactable = value;
    }

    public bool SetInteractableBuyBigChest
    {
        set => _buyBigChest.interactable = value;
    }



    public event Action OnBuyX2Water;

    public event Action OnShowAdForKey;
    public event Action OnShowAdForTimeEnergy;
    public event Action OnShowAdForFuel;
    public event Action OnShowAdForToolBox;
    public event Action OnShowAdForSmallChest;

    public event Action OnBuy10000Water;
    public event Action OnBuy100000Water;
    public event Action OnBuy1000000Water;

    public event Action OnBuy50TimeEnergy;
    public event Action OnBuy250TimeEnergy;
    public event Action OnBuy1000TimeEnergy;
    public event Action OnBuy5000TimeEnergy;

    public event Action OnBuyMiddleChest;
    public event Action OnBuyBigChest;

    public event Action<string> OnPromoCodeEnter;



    public void SetTitle(string title)
    {
        _title.text = title;
    }

    public void SetLanguage(SystemLanguage language)
    {
        _promoCodeTitle.text = Words.GetWord(Word.promo_code, language);
        _enterText.text = Words.GetWord(Word.ok, language);
        _networkRequireText.text = Words.GetWord(Word.network_require, language);
    }



    public void ResetPromoCode()
    {
        _n1.text = "";
        _n2.text = "";
        _n3.text = "";
        _n4.text = "";
        _n5.text = "";
    }



    private void Start()
    {
        _buyX2Water.onClick.AddListener(() => OnBuyX2Water.Invoke());

        _showAdForKey.onClick.AddListener(() => OnShowAdForKey.Invoke());
        _showAdForTimeEnergy.onClick.AddListener(() => OnShowAdForTimeEnergy.Invoke());
        _showAdForFuel.onClick.AddListener(() => OnShowAdForFuel.Invoke());
        _showAdForToolBox.onClick.AddListener(() => OnShowAdForToolBox.Invoke());
        _showAdForSmallChest.onClick.AddListener(() => OnShowAdForSmallChest.Invoke());

        _buy10000Water.onClick.AddListener(() => OnBuy10000Water.Invoke());
        _buy100000Water.onClick.AddListener(() => OnBuy100000Water.Invoke());
        _buy1000000Water.onClick.AddListener(() => OnBuy1000000Water.Invoke());

        _buy50TimeEnergy.onClick.AddListener(() => OnBuy50TimeEnergy.Invoke());
        _buy250TimeEnergy.onClick.AddListener(() => OnBuy250TimeEnergy.Invoke());
        _buy1000TimeEnergy.onClick.AddListener(() => OnBuy1000TimeEnergy.Invoke());
        _buy5000TimeEnergy.onClick.AddListener(() => OnBuy5000TimeEnergy.Invoke());

        _buyMiddleChest.onClick.AddListener(() => OnBuyMiddleChest.Invoke());
        _buyBigChest.onClick.AddListener(() => OnBuyBigChest.Invoke());

        _enter.onClick.AddListener(() => OnPromoCodeEnter.Invoke($"{_n1.text}-{_n2.text}-{_n3.text}-{_n4.text}-{_n5.text}"));
    }

    private void OnDestroy()
    {
        _buyX2Water.onClick.RemoveAllListeners();

        _showAdForKey.onClick.RemoveAllListeners();
        _showAdForTimeEnergy.onClick.RemoveAllListeners();
        _showAdForFuel.onClick.RemoveAllListeners();
        _showAdForToolBox.onClick.RemoveAllListeners();
        _showAdForSmallChest.onClick.RemoveAllListeners();

        _buy10000Water.onClick.RemoveAllListeners();
        _buy100000Water.onClick.RemoveAllListeners();
        _buy1000000Water.onClick.RemoveAllListeners();

        _buy50TimeEnergy.onClick.RemoveAllListeners();
        _buy250TimeEnergy.onClick.RemoveAllListeners();
        _buy1000TimeEnergy.onClick.RemoveAllListeners();
        _buy5000TimeEnergy.onClick.RemoveAllListeners();

        _buyMiddleChest.onClick.RemoveAllListeners();
        _buyBigChest.onClick.RemoveAllListeners();

        _enter.onClick.RemoveAllListeners();
    }
}