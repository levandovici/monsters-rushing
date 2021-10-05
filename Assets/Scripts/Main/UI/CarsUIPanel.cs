using UnityEngine.UI;
using UnityEngine;
using System;
using Vocabulary;

public class CarsUIPanel : UIPanel
{
    [SerializeField]
    private Text _buyText;
    [SerializeField]
    private Text _selectText;
    [SerializeField]
    private Text _selectedText;

    [SerializeField]
    private Button _left;
    [SerializeField]
    private Button _right;
    [SerializeField]
    private Button _buy;
    [SerializeField]
    private Text _price;
    [SerializeField]
    private Button _select;

    [SerializeField]
    private GameObject _selected;

    private ESelectedUpgrade _selectedUpgrade;
    [SerializeField]
    private Text _upgradeTitle;
    [SerializeField]
    private Transform _upgradePanel;
    [SerializeField]
    private Transform _detailsPanel;
    [SerializeField]
    private Button _upgrade;
    [SerializeField]
    private Text _upgradePrice;
    [SerializeField]
    private Text _level;

    [SerializeField]
    private Button _health;
    [SerializeField]
    private Button _damage;
    [SerializeField]
    private Button _bullets;
    [SerializeField]
    private Button _fuel;

    private SystemLanguage _language;



    public event Action OnLeftClicked;
    public event Action OnRightClicked;
    public event Action OnBuyClicked;
    public event Action OnSelectClicked;

    public event Action OnHealthUpgradeClicked;
    public event Action OnDamageUpgradeClicked;
    public event Action OnCapacityUpgradeClicked;
    public event Action OnFuelUpgradeClicked;

    public event Action OnHealthClicked;
    public event Action OnDamageClicked;
    public event Action OnBulletsClicked;
    public event Action OnFuelClicked;



    public bool SetInteractable
    {
        set => _buy.interactable = value;
    }



    private void SetActivBuy(bool activ)
    {
        _buy.gameObject.SetActive(activ);
    }

    private void SetActivSelect(bool activ)
    {
        _select.gameObject.SetActive(activ);
    }

    private void SetActivSelected(bool activ)
    {
        _selected.SetActive(activ);
    }

    public void SetUpgrades(int index, PlayerData.CarData carData, int gems, ESelectedUpgrade upgrade, Inventory.InventoryObjects all)
    {
        _selectedUpgrade = upgrade;

        if (!carData.bought)
        {
            _upgradePanel.gameObject.SetActive(false);
            return;
        }

        _upgradePanel.gameObject.SetActive(true);


        foreach (Transform t in _detailsPanel)
            Destroy(t.gameObject);


        switch (upgrade)
        {
            case ESelectedUpgrade.health:
                _upgrade.gameObject.SetActive(carData.healthLevel != PlayerData.CarData.Level.ten);
                if (carData.healthLevel == PlayerData.CarData.Level.ten)
                {
                    _level.text = Words.GetWord(Word.full, _language);
                    carData.upgradeHealth = null;
                }
                else
                {
                    _level.text = $"{(int)carData.healthLevel}/10";
                    int healthUpgradePrice = PlayerData.CarData.GetCarUpgrade(index).HealthUpgradePrice(carData.healthLevel);
                    _upgradePrice.text = $"{healthUpgradePrice}";

                    _upgrade.interactable = gems >= healthUpgradePrice &&
                    SaveLoadManager.Current.inventoryObjects.CanUpgrade(SaveLoadManager.Current.carsData[index].upgradeHealth);



                    if(carData.upgradeHealth == null || carData.upgradeHealth.inventoryObjects == null ||
                        carData.upgradeHealth.inventoryObjects.Length == 0)
                    {
                        carData.upgradeHealth = Inventory.GenerateUpgrade(all, carData.healthLevel);
                    }

                    foreach(Inventory.InventoryObject obj in carData.upgradeHealth.inventoryObjects)
                    {
                        CellUI cell = Instantiate<CellUI>(Resources.Load<CellUI>(Inventory.Cell), _detailsPanel);
                        Transform t = Instantiate<Transform>(Resources.Load<Transform>(obj.location), cell.ItemPanel);
                        t.localScale = new Vector3(0.75f, 0.75f, 1f);

                        Inventory.InventoryObject inv = null;
                        bool b = all.TryGetClone(obj.location, out inv);

                        if(b)
                        {
                            cell.SetUp(inv.count, obj.count, obj.rarity);
                        }
                        else
                        {
                            cell.SetUp(obj.count, obj.rarity);
                        }
                    }
                }
                _upgradeTitle.text = Words.GetWord(Word.health, _language);
                break;

            case ESelectedUpgrade.damage:
                _upgrade.gameObject.SetActive(carData.damageLevel != PlayerData.CarData.Level.ten);
                if (carData.damageLevel == PlayerData.CarData.Level.ten)
                {
                    _level.text = Words.GetWord(Word.full, _language);
                    carData.upgradeDamage = null;
                }
                else
                {
                    _level.text = $"{(int)carData.damageLevel}/10";
                    int damageUpgradePrice = PlayerData.CarData.GetCarUpgrade(index).DamageUpgradePrice(carData.damageLevel);
                    _upgradePrice.text = $"{damageUpgradePrice}";

                    _upgrade.interactable = gems >= damageUpgradePrice &&
                    SaveLoadManager.Current.inventoryObjects.CanUpgrade(SaveLoadManager.Current.carsData[index].upgradeDamage);



                    if (carData.upgradeDamage == null || carData.upgradeDamage.inventoryObjects == null ||
                        carData.upgradeDamage.inventoryObjects.Length == 0)
                    {
                        carData.upgradeDamage = Inventory.GenerateUpgrade(all, carData.damageLevel);
                    }

                    foreach (Inventory.InventoryObject obj in carData.upgradeDamage.inventoryObjects)
                    {
                        CellUI cell = Instantiate<CellUI>(Resources.Load<CellUI>(Inventory.Cell), _detailsPanel);
                        Transform t = Instantiate<Transform>(Resources.Load<Transform>(obj.location), cell.ItemPanel);
                        t.localScale = new Vector3(0.75f, 0.75f, 1f);

                        Inventory.InventoryObject inv = null;
                        bool b = all.TryGetClone(obj.location, out inv);

                        if (b)
                        {
                            cell.SetUp(inv.count, obj.count, obj.rarity);
                        }
                        else
                        {
                            cell.SetUp(obj.count, obj.rarity);
                        }
                    }
                }
                _upgradeTitle.text = Words.GetWord(Word.damage, _language);
                break;

            case ESelectedUpgrade.bullets:
                _upgrade.gameObject.SetActive(carData.capacityLevel != PlayerData.CarData.Level.ten);
                if (carData.capacityLevel == PlayerData.CarData.Level.ten)
                {
                    _level.text = Words.GetWord(Word.full, _language);
                    carData.upgradeBullets = null;
                }
                else
                {
                    _level.text = $"{(int)carData.capacityLevel}/10";
                    int capacityUpgradePrice = PlayerData.CarData.GetCarUpgrade(index).CapacityUpgradePrice(carData.capacityLevel);
                    _upgradePrice.text = $"{capacityUpgradePrice}";

                    _upgrade.interactable = gems >= capacityUpgradePrice &&
                    SaveLoadManager.Current.inventoryObjects.CanUpgrade(SaveLoadManager.Current.carsData[index].upgradeBullets);



                    if (carData.upgradeBullets == null || carData.upgradeBullets.inventoryObjects == null ||
                         carData.upgradeBullets.inventoryObjects.Length == 0)
                    {
                        carData.upgradeBullets = Inventory.GenerateUpgrade(all, carData.capacityLevel);
                    }

                    foreach (Inventory.InventoryObject obj in carData.upgradeBullets.inventoryObjects)
                    {
                        CellUI cell = Instantiate<CellUI>(Resources.Load<CellUI>(Inventory.Cell), _detailsPanel);
                        Transform t = Instantiate<Transform>(Resources.Load<Transform>(obj.location), cell.ItemPanel);
                        t.localScale = new Vector3(0.75f, 0.75f, 1f);

                        Inventory.InventoryObject inv = null;
                        bool b = all.TryGetClone(obj.location, out inv);

                        if (b)
                        {
                            cell.SetUp(inv.count, obj.count, obj.rarity);
                        }
                        else
                        {
                            cell.SetUp(obj.count, obj.rarity);
                        }
                    }
                }
                _upgradeTitle.text = Words.GetWord(Word.capacity, _language);
                break;

            case ESelectedUpgrade.fuel:
                _upgrade.gameObject.SetActive(carData.fuelLevel != PlayerData.CarData.Level.ten);
                if (carData.fuelLevel == PlayerData.CarData.Level.ten)
                {
                    _level.text = Words.GetWord(Word.full, _language);
                    carData.upgradeFuel = null;
                }
                else
                {
                    _level.text = $"{(int)carData.fuelLevel}/10";
                    int fuelUpgradePrice = PlayerData.CarData.GetCarUpgrade(index).FuelUpgradePrice(carData.fuelLevel);
                    _upgradePrice.text = $"{fuelUpgradePrice}";

                    _upgrade.interactable = gems >= fuelUpgradePrice &&
                    SaveLoadManager.Current.inventoryObjects.CanUpgrade(SaveLoadManager.Current.carsData[index].upgradeFuel);



                    if (carData.upgradeFuel == null || carData.upgradeFuel.inventoryObjects == null ||
                        carData.upgradeFuel.inventoryObjects.Length == 0)
                    {
                        carData.upgradeFuel = Inventory.GenerateUpgrade(all, carData.fuelLevel);
                    }

                    foreach (Inventory.InventoryObject obj in carData.upgradeFuel.inventoryObjects)
                    {
                        CellUI cell = Instantiate<CellUI>(Resources.Load<CellUI>(Inventory.Cell), _detailsPanel);
                        Transform t = Instantiate<Transform>(Resources.Load<Transform>(obj.location), cell.ItemPanel);
                        t.localScale = new Vector3(0.75f, 0.75f, 1f);

                        Inventory.InventoryObject inv = null;
                        bool b = all.TryGetClone(obj.location, out inv);

                        if (b)
                        {
                            cell.SetUp(inv.count, obj.count, obj.rarity);
                        }
                        else
                        {
                            cell.SetUp(obj.count, obj.rarity);
                        }
                    }
                }
                _upgradeTitle.text = Words.GetWord(Word.fuel, _language);
                break;
        }
    }



    public void ActivateBuy(int price)
    {
        _price.text = price.ToString("### ### ### ### ##0");

        SetActivBuy(true);
        SetActivSelect(false);
        SetActivSelected(false);
    }

    public void ActivateSelect()
    {
        SetActivBuy(false);
        SetActivSelect(true);
        SetActivSelected(false);
    }

    public void ActivateSelected()
    {
        SetActivBuy(false);
        SetActivSelect(false);
        SetActivSelected(true);
    }



    private void Start()
    {
        _buy.onClick.AddListener(() => OnBuyClicked.Invoke());
        _select.onClick.AddListener(() => OnSelectClicked.Invoke());
        _left.onClick.AddListener(() => OnLeftClicked.Invoke());
        _right.onClick.AddListener(() => OnRightClicked.Invoke());

        _upgrade.onClick.AddListener(() =>
        {
            switch (_selectedUpgrade)
            {
                case ESelectedUpgrade.health:
                    OnHealthUpgradeClicked.Invoke();
                    break;

                case ESelectedUpgrade.damage:
                    OnDamageUpgradeClicked.Invoke();
                    break;

                case ESelectedUpgrade.bullets:
                    OnCapacityUpgradeClicked.Invoke();
                    break;

                case ESelectedUpgrade.fuel:
                    OnFuelUpgradeClicked.Invoke();
                    break;
            }
        });

        _health.onClick.AddListener(() => OnHealthClicked.Invoke());
        _damage.onClick.AddListener(() => OnDamageClicked.Invoke());
        _bullets.onClick.AddListener(() => OnBulletsClicked.Invoke());
        _fuel.onClick.AddListener(() => OnFuelClicked.Invoke());
    }

    private void OnDestroy()
    {
        _buy.onClick.RemoveAllListeners();
        _select.onClick.RemoveAllListeners();
        _left.onClick.RemoveAllListeners();
        _right.onClick.RemoveAllListeners();

        _upgrade.onClick.RemoveAllListeners();
    }



    public void SetLanguage(SystemLanguage language)
    {
        _language = language;
        _buyText.text = Words.GetWord(Word.buy, language);
        _selectText.text = Words.GetWord(Word.select, language);
        _selectedText.text = Words.GetWord(Word.selected, language);
    }


    public enum ESelectedUpgrade
    {
        health, damage, bullets, fuel,
    }
}