using UnityEngine.SceneManagement;
using static SoundController;
using UnityEngine;
using Tasks;
using System;

public class MainManager : MonoBehaviour
{
    [SerializeField]
    private MainUIManager _UIManager;
    [SerializeField]
    private MainController _mainController;
    [SerializeField]
    private ShopController _shopController;
    [SerializeField]
    private CarsController _carsController;
    [SerializeField]
    private SoundController _soundController;
    [SerializeField]
    private TasksController _tasksController;


    [SerializeField]
    private Material _skyboxDay;
    [SerializeField]
    private Transform _sun;

    [SerializeField]
    private Material _skyboxNight;
    [SerializeField]
    private Transform _moon;



    private void Awake()
    {
        _UIManager.OnInternetRequireOpened += () =>
        {
            _soundController.PlaySFX(SoundController.ESFXClip.Click);
        };


        _UIManager.Settings.OnLanguageChanged += (SystemLanguage lang) =>
        {
            SaveLoadManager.Current.language = lang;
            SaveLoadManager.Save();
            Loading.ID = 1; //main scene
            SceneManager.LoadScene(0); // laoding scene
        };



        _mainController.OnNewKeyTimeChanged += (i) =>
        {
            _UIManager.Main.SetNewKeyTime(i);
            int dif = SaveLoadManager.Current.newKeyTime - i;
            SaveLoadManager.Current.newKeyTime = i;

            if(dif > 0)
            {
                SaveLoadManager.Current.lastNetworkTime = 
                (new DateTime(SaveLoadManager.Current.lastNetworkTime) + new TimeSpan(0, 0, dif)).Ticks;
            }
        };
        _mainController.OnKeyAdd += () => ChangeKeys(1);
        _mainController.OnNewKeyAfterNeed += () => SaveLoadManager.NewKeyAfter();
        _mainController.OnMaxFreeKeysNeed += () => SaveLoadManager.MaxFreeKeys();
        _mainController.OnKeysCountNeed += () => SaveLoadManager.Current.keys;


        _UIManager.Settings.OnSfxVolumeChanged += (f) => SetSfxVolume(f);
        _UIManager.Settings.OnMusicVolumeChanged += (f) => SetMusicVolume(f);
        _UIManager.Settings.OnPrivacyPolicyClicked += () =>
        {
            Application.OpenURL(@"https://nikitalnc-games.jimdosite.com/monstersrushing-privacypolicy/");
        };


        _UIManager.Cars.OnBuyClicked += () =>
        {
            int price = PlayerData.CarData.GetCarPrice(_carsController.CurrentID);

            if (SaveLoadManager.Current.gems >= price)
            {
                ChangeGems(-price);
                SaveLoadManager.Current.carsData[_carsController.CurrentID].bought = true;
            }

            CarsReload();
            _soundController.PlaySFX(SoundController.ESFXClip.Click);
        };
        _UIManager.Cars.OnSelectClicked += () =>
        {
            if (SaveLoadManager.Current.carsData[_carsController.CurrentID].bought)
            {
                SaveLoadManager.Current.selectedCar = _carsController.CurrentID;
            }
            CarsReload();
            _soundController.PlaySFX(SoundController.ESFXClip.Click);
        };
        _UIManager.Cars.OnLeftClicked += () =>
        {
            _carsController.Left();
            CarsReload();
            _soundController.PlaySFX(SoundController.ESFXClip.Click);
        };
        _UIManager.Cars.OnRightClicked += () =>
        {
            _carsController.Right();
            CarsReload();
            _soundController.PlaySFX(SoundController.ESFXClip.Click);
        };
        _UIManager.OnMainOpened += () =>
        {
            _carsController.SetUp(SaveLoadManager.Current.selectedCar);
            _carsController.StopRotation();
            _soundController.PlaySFX(SoundController.ESFXClip.Click);
        };
        _UIManager.OnShopOpened += () =>
        {
            ShopReload();
            _soundController.PlaySFX(SoundController.ESFXClip.Click);
        };
        _UIManager.OnCarsOpened += () =>
        {
            _carsController.SetUp(SaveLoadManager.Current.selectedCar);
            _carsController.Rotate();
            CarsReload();
            _soundController.PlaySFX(SoundController.ESFXClip.Click);
        };
        _UIManager.OnSettingsOpened += () =>
        {
            _soundController.PlaySFX(SoundController.ESFXClip.Click);
        };
        _UIManager.OnTasksOpened += () =>
        {
            _soundController.PlaySFX(SoundController.ESFXClip.Click);
        };
        _UIManager.Main.OnPlayClicked += () =>
        {
            if (SaveLoadManager.Current.keys > 0)
            {
                ChangeKeys(-1);
                SaveLoadManager.Save();
                _UIManager.Main.SetInteractablePlay = false;
                Loading.ID = 2; //game scene
                SceneManager.LoadScene(0); // laoding scene
            }
            _soundController.PlaySFX(SoundController.ESFXClip.Click);
        };

        _shopController.OnBuyWater += (i) =>
        {
            int price = i / 1000;

            if (SaveLoadManager.Current.timeEnergy >= price * ShopController.One1000WaterPrice)
            {
                ChangeTimeEnergy(-price * ShopController.One1000WaterPrice);
                ChangeGems(price * 1000);

                _UIManager.OpenYouGot();
                _UIManager.YouGot.SetUp(YouGotUIPanel.EObjType.gems, price * 1000);

                //SFX
                //VFX
            }
            else
            {
                //SFX
                //VFX
            }
        };

        _shopController.OnBuyX2Water += (succesful) =>
        {
            if (succesful)
            {
                SaveLoadManager.Current.x3Gems = true;

                //SFX
                //VFX
            }
            else
            {
                //SFX
                //VFX
            }
        };
        _shopController.OnBuyTimeEnergy += (i, succesful) =>
        {
            if (succesful)
            {
                ChangeTimeEnergy(i);

                //SFX
                //VFX
            }
            else
            {
                //SFX
                //VFX
            }
        };


        _UIManager.Shop.OnBuyX2Water += () =>
        {
            if (SaveLoadManager.Current.x3Gems)
                return;

            _shopController.BuyX2Water();
            _UIManager.Shop.SetBoughtX2Water = SaveLoadManager.Current.x3Gems;
            _soundController.PlaySFX(SoundController.ESFXClip.Click);
        };

        _UIManager.Shop.OnShowAdForKey += () =>
        {
            //if (!_adsController.isRewardedAdReady)
            //    return;

            //ShowAdForKey();
        };
        _UIManager.Shop.OnShowAdForTimeEnergy += () =>
        {
            //if (!_adsController.isRewardedAdReady)
            //    return;

            //ShowAdForTimeEnergy();
        };
        _UIManager.Shop.OnShowAdForFuel += () =>
        {
            //if (!_adsController.isRewardedAdReady)
            //    return;

            //ShowAdForFuel();
        };
        _UIManager.Shop.OnShowAdForToolBox += () =>
        {
            //if (!_adsController.isRewardedAdReady)
            //    return;

            //ShowAdForToolBox();
        };
        _UIManager.Shop.OnShowAdForSmallChest += () =>
        {
            //if (!_adsController.isRewardedAdReady)
            //    return;

            //ShowAdForSmallChest();
        };


        _UIManager.Shop.OnBuyMiddleChest += () =>
        {
            if (SaveLoadManager.Current.timeEnergy >= 500)
            {
                SaveLoadManager.Current.middleChests++;
                ChangeTimeEnergy(-500);
                _UIManager.OpenYouGot();
                _UIManager.YouGot.SetUp(YouGotUIPanel.EObjType.middleChest, 1);
                ShopReload();
            }

            _soundController.PlaySFX(SoundController.ESFXClip.Click);
        };

        _UIManager.Shop.OnBuyBigChest += () =>
        {
            if (SaveLoadManager.Current.timeEnergy >= 1500)
            {
                SaveLoadManager.Current.bigChests++;
                ChangeTimeEnergy(-1500);
                _UIManager.OpenYouGot();
                _UIManager.YouGot.SetUp(YouGotUIPanel.EObjType.bigChest, 1);
                ShopReload();
            }

            _soundController.PlaySFX(SoundController.ESFXClip.Click);
        };


        _UIManager.Shop.OnBuy10000Water += () =>
        {
            _shopController.BuyWater(10000);
            ShopReload();
            _soundController.PlaySFX(SoundController.ESFXClip.Click);
        };
        _UIManager.Shop.OnBuy100000Water += () =>
        {
            _shopController.BuyWater(100000);
            ShopReload();
            _soundController.PlaySFX(SoundController.ESFXClip.Click);
        };
        _UIManager.Shop.OnBuy1000000Water += () =>
        {
            _shopController.BuyWater(1000000);
            ShopReload();
            _soundController.PlaySFX(SoundController.ESFXClip.Click);
        };

        _UIManager.Shop.OnBuy50TimeEnergy += () =>
        {
            _shopController.BuyTimeEnergy(ShopController.EShopTimeEnergyPriceInCents.fifty);
            ShopReload();
            _soundController.PlaySFX(SoundController.ESFXClip.Click);
        };
        _UIManager.Shop.OnBuy250TimeEnergy += () =>
        {
            _shopController.BuyTimeEnergy(ShopController.EShopTimeEnergyPriceInCents.two_hundred_fifty);
            ShopReload();
            _soundController.PlaySFX(SoundController.ESFXClip.Click);
        };
        _UIManager.Shop.OnBuy1000TimeEnergy += () =>
        {
            _shopController.BuyTimeEnergy(ShopController.EShopTimeEnergyPriceInCents.one_thousand);
            ShopReload();
            _soundController.PlaySFX(SoundController.ESFXClip.Click);
        };
        _UIManager.Shop.OnBuy5000TimeEnergy += () =>
        {
            _shopController.BuyTimeEnergy(ShopController.EShopTimeEnergyPriceInCents.five_thousand);
            ShopReload();
            _soundController.PlaySFX(SoundController.ESFXClip.Click);
        };


        //_adsController.OnAdFinished += (succesful) =>
        //{
        //    OnAddFinished(succesful);
        //};
        //_adsController.OnRewardedAdStatusChanged += (b) =>
        //{
        //    _UIManager.Main.SetInteractableShowAdd = b;
        //    _UIManager.Shop.SetInteractableShowAdd = b;
        //};


        _UIManager.OnOpenChestOpened += () =>
        {
            _soundController.PlaySFX(SoundController.ESFXClip.Click);
        };

        _UIManager.OnInventoryOpened += () =>
        {
            InventoryUIUpdate();
        };

        _UIManager.Inventory.OnSmallChestOpenClicked += () =>
        {
            if(SaveLoadManager.Current.smallChests > 0)
            {
                SaveLoadManager.Current.smallChests--;

                Inventory.Chest chest = Inventory.GenerateChest(Inventory.EInventoryChestType.small);
                ChangeGems(chest.gems);
                ChangeTimeEnergy(chest.energy);
                ChangeKeys(chest.keys);

                for (int i = 0; i < chest.InventoryObjects.inventoryObjects.Length; i++)
                {
                    SaveLoadManager.Current.inventoryObjects.TryAdd(chest.InventoryObjects.inventoryObjects[i]);
                }

                _UIManager.OpenOpenChest();
                _UIManager.OpenChest.SetUp(chest);

                InventoryUIUpdate();
            }
        };

        _UIManager.Inventory.OnMiddleChestOpenClicked += () =>
        {
            if (SaveLoadManager.Current.middleChests > 0)
            {
                SaveLoadManager.Current.middleChests--;

                Inventory.Chest chest = Inventory.GenerateChest(Inventory.EInventoryChestType.middle);
                ChangeGems(chest.gems);
                ChangeTimeEnergy(chest.energy);
                ChangeKeys(chest.keys);

                for (int i = 0; i < chest.InventoryObjects.inventoryObjects.Length; i++)
                {
                    SaveLoadManager.Current.inventoryObjects.TryAdd(chest.InventoryObjects.inventoryObjects[i]);
                }

                _UIManager.OpenOpenChest();
                _UIManager.OpenChest.SetUp(chest);

                InventoryUIUpdate();
            }
        };

        _UIManager.Shop.OnPromoCodeEnter += (s) =>
        {
            long t = 0;
            if(TimeManager.GetNetworkTime(out t))
            {
                DateTime dt = new DateTime(t);
                PromoCodes.PromoCode code = null;
                bool b = PromoCodes.TryUnpackPromoCode(s, out code);

                if(!b || SaveLoadManager.Current.promoCodesArchive.Contains(s) || dt.Year != code.year ||
                dt.Month != code.month || code.startDay > dt.Day || code.endDay < dt.Day)
                {
                    _UIManager.OpenPromoCodeError();
                }
                else
                {
                    switch(code.id)
                    {
                        case PromoCodes.EPromoCodeID.gems:
                            ChangeGems(code.count);
                            _UIManager.OpenYouGot();
                            _UIManager.YouGot.SetUp(YouGotUIPanel.EObjType.gems, code.count);
                            break;

                        case PromoCodes.EPromoCodeID.energy:
                            ChangeTimeEnergy(code.count);
                            _UIManager.OpenYouGot();
                            _UIManager.YouGot.SetUp(YouGotUIPanel.EObjType.energy, code.count);
                            break;

                        case PromoCodes.EPromoCodeID.keys:
                            ChangeKeys(code.count);
                            _UIManager.OpenYouGot();
                            _UIManager.YouGot.SetUp(YouGotUIPanel.EObjType.key, code.count);
                            break;

                        case PromoCodes.EPromoCodeID.fuel:
                            SaveLoadManager.Current.inventoryObjects.TryAdd(
                                new Inventory.InventoryObject(Inventory.Fuel, Inventory.EInventoryObjectRarity.none, code.count));
                            _UIManager.OpenYouGot();
                            _UIManager.YouGot.SetUp(YouGotUIPanel.EObjType.fuel, code.count);
                            break;

                        case PromoCodes.EPromoCodeID.toolbox:
                            SaveLoadManager.Current.inventoryObjects.TryAdd(
                                new Inventory.InventoryObject(Inventory.ToolBox, Inventory.EInventoryObjectRarity.none, code.count));
                            _UIManager.OpenYouGot();
                            _UIManager.YouGot.SetUp(YouGotUIPanel.EObjType.toolBox, code.count);
                            break;

                        case PromoCodes.EPromoCodeID.middle:
                            SaveLoadManager.Current.middleChests += code.count;
                            _UIManager.OpenYouGot();
                            _UIManager.YouGot.SetUp(YouGotUIPanel.EObjType.middleChest, code.count);
                            break;

                        case PromoCodes.EPromoCodeID.big:
                            SaveLoadManager.Current.bigChests += code.count;
                            _UIManager.OpenYouGot();
                            _UIManager.YouGot.SetUp(YouGotUIPanel.EObjType.bigChest, code.count);
                            break;
                    }

                    SaveLoadManager.Current.promoCodesArchive.Add(s);
                }
            }

            _UIManager.Shop.ResetPromoCode();
            ShopReload();
            _soundController.PlaySFX(SoundController.ESFXClip.Click);
        };

        _UIManager.Inventory.OnBigChestOpenClicked += () =>
        {
            if (SaveLoadManager.Current.bigChests > 0)
            {
                SaveLoadManager.Current.bigChests--;

                Inventory.Chest chest = Inventory.GenerateChest(Inventory.EInventoryChestType.big);
                ChangeGems(chest.gems);
                ChangeTimeEnergy(chest.energy);
                ChangeKeys(chest.keys);

                for (int i = 0; i < chest.InventoryObjects.inventoryObjects.Length; i++)
                {
                    SaveLoadManager.Current.inventoryObjects.TryAdd(chest.InventoryObjects.inventoryObjects[i]);
                }

                _UIManager.OpenOpenChest();
                _UIManager.OpenChest.SetUp(chest);

                InventoryUIUpdate();
            }
        };

        _UIManager.Main.OnInventoryClicked += () =>
        {
            _UIManager.OpenInventory();
            _soundController.PlaySFX(SoundController.ESFXClip.Click);
        };

        _UIManager.Cars.OnHealthUpgradeClicked += () =>
        {
            if(SaveLoadManager.Current.carsData[_carsController.CurrentID].bought)
            {
                int healthUpgradePrice = PlayerData.CarData.GetCarUpgrade(_carsController.CurrentID).HealthUpgradePrice(SaveLoadManager.Current.carsData[_carsController.CurrentID].healthLevel);

                if (SaveLoadManager.Current.carsData[_carsController.CurrentID].healthLevel != PlayerData.CarData.Level.ten)
                if (SaveLoadManager.Current.gems >= healthUpgradePrice && 
                    SaveLoadManager.Current.inventoryObjects.CanUpgrade(SaveLoadManager.Current.carsData[_carsController.CurrentID].upgradeHealth))
                {
                    ChangeGems(-healthUpgradePrice);
                    SaveLoadManager.Current.inventoryObjects.Use(SaveLoadManager.Current.carsData[_carsController.CurrentID].upgradeHealth);
                    SaveLoadManager.Current.carsData[_carsController.CurrentID].UpgradeHealth();

                        if (SaveLoadManager.Current.carsData[_carsController.CurrentID].healthLevel != PlayerData.CarData.Level.ten)
                            SaveLoadManager.Current.carsData[_carsController.CurrentID].upgradeHealth =
                            Inventory.GenerateUpgrade(SaveLoadManager.Current.inventoryObjects,
                                SaveLoadManager.Current.carsData[_carsController.CurrentID].healthLevel);

                        CarsReload();
                }
            }
            _soundController.PlaySFX(SoundController.ESFXClip.Click);
        };
        _UIManager.Cars.OnDamageUpgradeClicked += () =>
        {
            if (SaveLoadManager.Current.carsData[_carsController.CurrentID].bought)
            {
                int damageUpgradePrice = PlayerData.CarData.GetCarUpgrade(_carsController.CurrentID).DamageUpgradePrice(SaveLoadManager.Current.carsData[_carsController.CurrentID].damageLevel);

                if (SaveLoadManager.Current.carsData[_carsController.CurrentID].damageLevel != PlayerData.CarData.Level.ten)
                    if (SaveLoadManager.Current.gems >= damageUpgradePrice &&
                    SaveLoadManager.Current.inventoryObjects.CanUpgrade(SaveLoadManager.Current.carsData[_carsController.CurrentID].upgradeDamage))
                    {
                        ChangeGems(-damageUpgradePrice);
                        SaveLoadManager.Current.inventoryObjects.Use(SaveLoadManager.Current.carsData[_carsController.CurrentID].upgradeDamage);
                        SaveLoadManager.Current.carsData[_carsController.CurrentID].UpgradeDamage();

                        if (SaveLoadManager.Current.carsData[_carsController.CurrentID].damageLevel != PlayerData.CarData.Level.ten)
                            SaveLoadManager.Current.carsData[_carsController.CurrentID].upgradeDamage =
                            Inventory.GenerateUpgrade(SaveLoadManager.Current.inventoryObjects,
                                SaveLoadManager.Current.carsData[_carsController.CurrentID].damageLevel);

                        CarsReload(CarsUIPanel.ESelectedUpgrade.damage);
                    }
            }
            _soundController.PlaySFX(SoundController.ESFXClip.Click);
        };
        _UIManager.Cars.OnCapacityUpgradeClicked += () =>
        {
            if (SaveLoadManager.Current.carsData[_carsController.CurrentID].bought)
            {
                int capacityUpgradePrice = PlayerData.CarData.GetCarUpgrade(_carsController.CurrentID).CapacityUpgradePrice(SaveLoadManager.Current.carsData[_carsController.CurrentID].capacityLevel);

                if (SaveLoadManager.Current.carsData[_carsController.CurrentID].capacityLevel != PlayerData.CarData.Level.ten)
                    if (SaveLoadManager.Current.gems >= capacityUpgradePrice &&
                    SaveLoadManager.Current.inventoryObjects.CanUpgrade(SaveLoadManager.Current.carsData[_carsController.CurrentID].upgradeBullets))
                    {
                        ChangeGems(-capacityUpgradePrice);
                        SaveLoadManager.Current.inventoryObjects.Use(SaveLoadManager.Current.carsData[_carsController.CurrentID].upgradeBullets);
                        SaveLoadManager.Current.carsData[_carsController.CurrentID].UpgradeCapacity();

                        if (SaveLoadManager.Current.carsData[_carsController.CurrentID].capacityLevel != PlayerData.CarData.Level.ten)
                            SaveLoadManager.Current.carsData[_carsController.CurrentID].upgradeBullets =
                            Inventory.GenerateUpgrade(SaveLoadManager.Current.inventoryObjects,
                                SaveLoadManager.Current.carsData[_carsController.CurrentID].capacityLevel);

                        CarsReload(CarsUIPanel.ESelectedUpgrade.bullets);
                    }
            }
            _soundController.PlaySFX(SoundController.ESFXClip.Click);
        };

        _UIManager.Cars.OnFuelUpgradeClicked += () =>
        {
            if (SaveLoadManager.Current.carsData[_carsController.CurrentID].bought)
            {
                int fuelUpgradePrice = PlayerData.CarData.GetCarUpgrade(_carsController.CurrentID).FuelUpgradePrice(SaveLoadManager.Current.carsData[_carsController.CurrentID].fuelLevel);

                if (SaveLoadManager.Current.carsData[_carsController.CurrentID].fuelLevel != PlayerData.CarData.Level.ten)
                    if (SaveLoadManager.Current.gems >= fuelUpgradePrice &&
                    SaveLoadManager.Current.inventoryObjects.CanUpgrade(SaveLoadManager.Current.carsData[_carsController.CurrentID].upgradeFuel))
                    {
                        ChangeGems(-fuelUpgradePrice);
                        SaveLoadManager.Current.inventoryObjects.Use(SaveLoadManager.Current.carsData[_carsController.CurrentID].upgradeFuel);
                        SaveLoadManager.Current.carsData[_carsController.CurrentID].UpgradeFuel();
                        
                        if(SaveLoadManager.Current.carsData[_carsController.CurrentID].fuelLevel != PlayerData.CarData.Level.ten)
                        SaveLoadManager.Current.carsData[_carsController.CurrentID].upgradeFuel = 
                            Inventory.GenerateUpgrade(SaveLoadManager.Current.inventoryObjects, 
                                SaveLoadManager.Current.carsData[_carsController.CurrentID].fuelLevel);

                        CarsReload(CarsUIPanel.ESelectedUpgrade.fuel);
                    }
            }
            _soundController.PlaySFX(SoundController.ESFXClip.Click);
        };

        _UIManager.Cars.OnHealthClicked += () =>
        {
            _soundController.PlaySFX(SoundController.ESFXClip.Click);

            _UIManager.Cars.SetUpgrades(_carsController.CurrentID,
                SaveLoadManager.Current.carsData[_carsController.CurrentID], 
                SaveLoadManager.Current.gems, CarsUIPanel.ESelectedUpgrade.health, 
                SaveLoadManager.Current.inventoryObjects);
        };

        _UIManager.Cars.OnDamageClicked += () =>
        {
            _soundController.PlaySFX(SoundController.ESFXClip.Click);

            _UIManager.Cars.SetUpgrades(_carsController.CurrentID,
                SaveLoadManager.Current.carsData[_carsController.CurrentID],
                SaveLoadManager.Current.gems, CarsUIPanel.ESelectedUpgrade.damage,
                SaveLoadManager.Current.inventoryObjects);
        };

        _UIManager.Cars.OnBulletsClicked += () =>
        {
            _soundController.PlaySFX(SoundController.ESFXClip.Click);

            _UIManager.Cars.SetUpgrades(_carsController.CurrentID,
                SaveLoadManager.Current.carsData[_carsController.CurrentID],
                SaveLoadManager.Current.gems, CarsUIPanel.ESelectedUpgrade.bullets,
                SaveLoadManager.Current.inventoryObjects);
        };

        _UIManager.Cars.OnFuelClicked += () =>
        {
            _soundController.PlaySFX(SoundController.ESFXClip.Click);

            _UIManager.Cars.SetUpgrades(_carsController.CurrentID,
                SaveLoadManager.Current.carsData[_carsController.CurrentID],
                SaveLoadManager.Current.gems, CarsUIPanel.ESelectedUpgrade.fuel,
                SaveLoadManager.Current.inventoryObjects);
        };


        _UIManager.EditName.OnNameChanged += (name) =>
        {
            SaveLoadManager.Current.name = name;
            SaveLoadManager.Current.freeNameEdit = 
            Mathf.Clamp(SaveLoadManager.Current.freeNameEdit - 1, 0, 10);
            _UIManager.Main.SetName(name);
            _UIManager.PlayerInfo.SetUp(SaveLoadManager.Current.name, SaveLoadManager.Current.bestScore);
            _UIManager.EditName.Hide();
            _soundController.PlaySFX(SoundController.ESFXClip.Click);

            Debug.Log(SaveLoadManager.Current.freeNameEdit);
        };
        _UIManager.EditName.OnPayment += (price) =>
        {
            if(SaveLoadManager.Current.timeEnergy >= price)
            ChangeTimeEnergy(-price);
        };
        _UIManager.EditName.CanPay += (i) =>
        {
            return SaveLoadManager.Current.timeEnergy >= i;
        };
        _UIManager.EditName.OldName += () => SaveLoadManager.Current.name;

        _UIManager.PlayerInfo.OnEditNameClicked += () =>
        {
            _UIManager.EditName.Show(SaveLoadManager.Current.freeNameEdit > 0, 20);
        };

        _UIManager.OnPlayerInfoOpened += () =>
        {
            _soundController.PlaySFX(SoundController.ESFXClip.Click);
            _UIManager.PlayerInfo.SetUp(SaveLoadManager.Current.name, SaveLoadManager.Current.bestScore);
        };

        _UIManager.OnEditNameOpened += () =>
        {
            _soundController.PlaySFX(SoundController.ESFXClip.Click);
        };


        _UIManager.YouGot.OnOkClicked += () =>
        {
            _soundController.PlaySFX(SoundController.ESFXClip.Click);
        };

        _UIManager.PromoCodeError.OnOkClicked += () =>
        {
            _soundController.PlaySFX(SoundController.ESFXClip.Click);
        };

        _UIManager.OnPromoCodeErrorOpened += () =>
        {
            _soundController.PlaySFX(SoundController.ESFXClip.Click);
        };

        _UIManager.OnYouGotOpened += () =>
        {
            _soundController.PlaySFX(SoundController.ESFXClip.Click);
        };


        _UIManager.OnSwitchAccountOpened += () =>
        {
            _soundController.PlaySFX(SoundController.ESFXClip.Click);
        };

        _UIManager.Main.OnOpenPlayerInfoClicked += () =>
        {
            _UIManager.OpenPlayerInfo();
            _soundController.PlaySFX(SoundController.ESFXClip.Click);
        };

        _UIManager.OpenChest.OnNextClicked += () =>
        {
            _soundController.PlaySFX(SoundController.ESFXClip.chestNext);
        };

        _tasksController.OnTasksNeed += () => 
        {
            AddTasks();
            return SaveLoadManager.Current.tasks;
        };
        _tasksController.OnUpdateUI += (tasks, lang, actions) =>
        {
            _UIManager.Tasks.SetUp(tasks, lang, actions);

            TaskCell[] cells = SaveLoadManager.Current.tasks;
            int finished = 0;
            int disponible = 0;

            foreach(TaskCell taskCell in cells)
            {
                if(taskCell.ExistTask)
                {
                    if (taskCell.task.Percentage >= 100f)
                    {
                        finished++;
                    }
                    else
                    {
                        disponible++;
                    }
                }
            }

            _UIManager.Main.SetTasks(finished, disponible);
        };
        _tasksController.OnTaskIDReward += (i) =>
        {
            if (SaveLoadManager.Current.tasks[i].ExistTask &&
            SaveLoadManager.Current.tasks[i].task.Percentage >= 100f)
            {
                int count = SaveLoadManager.Current.tasks[i].task.reward;
                _UIManager.OpenYouGot();

                if (SaveLoadManager.Current.tasks[i].task.rewardType == ETaskReward.energy)
                {
                    ChangeTimeEnergy(count);
                    _UIManager.YouGot.SetUp(YouGotUIPanel.EObjType.energy, count);
                }
                else if (SaveLoadManager.Current.tasks[i].task.rewardType == ETaskReward.middleChest)
                {
                    SaveLoadManager.Current.middleChests += count;
                    _UIManager.YouGot.SetUp(YouGotUIPanel.EObjType.middleChest, count);
                }
                else if (SaveLoadManager.Current.tasks[i].task.rewardType == ETaskReward.bigChest)
                {
                    SaveLoadManager.Current.bigChests += count;
                    _UIManager.YouGot.SetUp(YouGotUIPanel.EObjType.bigChest, count);
                }

                SaveLoadManager.Current.tasks[i].Reward();


                _tasksController.UpdateNow();
            }
        };

    }


    private void Start()
    {
        long time = 0;
        bool isNetworkTime = TimeManager.GetNetworkTime(out time);

        if (TimeManager.IsHolliday(time) && isNetworkTime)
        {
            _soundController.PlayMusic(EMusicClip.HolidayMusic);
        }
        else
        {
            _soundController.PlayMusic(EMusicClip.Music);
        }

        if (!isNetworkTime)
            _UIManager.OpenInternetRequire();

        _UIManager.Shop.SetInteractablePromoCode = isNetworkTime;


        //pre sets
        SetSfxVolume(SaveLoadManager.Current.sfxVolume);
        SetMusicVolume(SaveLoadManager.Current.musicVolume);
        //

        _mainController.SetNewKeyTime(SaveLoadManager.Current.newKeyTime);
        _mainController.ActivateTimer();


        _UIManager.Shop.SetBoughtX2Water = SaveLoadManager.Current.x3Gems;


        _tasksController.SetUp(SaveLoadManager.Current.language);

        ResetResources();
        _UIManager.OpenMain();
        _UIManager.SetLanguage(SaveLoadManager.Current.language);
        _UIManager.Main.SetName(SaveLoadManager.Current.name);

        if (SaveLoadManager.IsFirstLoad)
        {
            _UIManager.OpenEditName(false, 0);
        }

        AddTasks();
    }



    private void Update()
    {
        DateTime dt = DateTime.Now;
        float time = dt.Hour * 3600f + dt.Minute * 60f + dt.Second;

        if (time > 6f * 3600f && time < 21f * 3600f)
        {
            RenderSettings.skybox = _skyboxDay;

            _sun.gameObject.SetActive(true);
            _moon.gameObject.SetActive(false);
        }
        else
        {
            RenderSettings.skybox = _skyboxNight;

            _moon.gameObject.SetActive(true);
            _sun.gameObject.SetActive(false);
        }
    }


    private void OnApplicationQuit()
    {
        SaveLoadManager.Save();
    }


    private void OnApplicationPause(bool pause)
    {
        ResetResources();
    }

    private void OnApplicationFocus(bool focus)
    {
        ResetResources();
    }



    private void SetSfxVolume(float value)
    {
        SaveLoadManager.Current.sfxVolume = value;
        _soundController.SetSfxVolume(value, false);
        _UIManager.Settings.SetSfxVolume(value);
    }

    private void SetMusicVolume(float value)
    {
        SaveLoadManager.Current.musicVolume = value;
        _soundController.SetMusicVolume(value);
        _UIManager.Settings.SetMusicVolume(value);
    }


    private void CarsReload(CarsUIPanel.ESelectedUpgrade selectedUpgrade = CarsUIPanel.ESelectedUpgrade.health)
    {
        if (SaveLoadManager.Current.selectedCar == _carsController.CurrentID)
        {
            _UIManager.Cars.ActivateSelected();
        }
        else if (SaveLoadManager.Current.carsData[_carsController.CurrentID].bought)
        {
            _UIManager.Cars.ActivateSelect();
        }
        else
        {
            _UIManager.Cars.SetInteractable = PlayerData.CarData.GetCarPrice(_carsController.CurrentID) <= SaveLoadManager.Current.gems;
            _UIManager.Cars.ActivateBuy(PlayerData.CarData.GetCarPrice(_carsController.CurrentID));
        }

        _UIManager.Cars.SetUpgrades(_carsController.CurrentID,
            SaveLoadManager.Current.carsData[_carsController.CurrentID], 
            SaveLoadManager.Current.gems, selectedUpgrade, 
            SaveLoadManager.Current.inventoryObjects);
    }


    private void ShopReload()
    {
        int timeEnergy = SaveLoadManager.Current.timeEnergy;

        _UIManager.Shop.SetInteractableBuy10000Water = timeEnergy >= ShopController.One1000WaterPrice * 10;
        _UIManager.Shop.SetInteractableBuy100000Water = timeEnergy >= ShopController.One1000WaterPrice * 100;
        _UIManager.Shop.SetInteractableBuy1000000Water = timeEnergy >= ShopController.One1000WaterPrice * 1000;
        _UIManager.Shop.SetInteractableBuyMiddleChest = timeEnergy >= 500;
        _UIManager.Shop.SetInteractableBuyBigChest = timeEnergy >= 1500;
    }


    public void InventoryUIUpdate()
    {
        _UIManager.Inventory.SetChests(SaveLoadManager.Current.smallChests,
    SaveLoadManager.Current.middleChests, SaveLoadManager.Current.bigChests);
        _UIManager.Inventory.SetInventory(SaveLoadManager.Current.inventoryObjects);
        _soundController.PlaySFX(SoundController.ESFXClip.Click);
    }


    private void ResetResources()
    {
        ChangeKeys(0);
        ChangeGems(0);
        ChangeTimeEnergy(0);
    }

    private void ChangeKeys(int count)
    {
        SaveLoadManager.Current.keys += count;
        _UIManager.Main.SetKeys(SaveLoadManager.Current.keys, SaveLoadManager.MaxFreeKeys());
    }

    private void ChangeGems(int count)
    {
        SaveLoadManager.Current.gems += count;
        _UIManager.Main.SetWater(SaveLoadManager.Current.gems);
    }

    private void ChangeTimeEnergy(int count)
    {
        SaveLoadManager.Current.timeEnergy += count;
        _UIManager.Main.SetTimeEnergy(SaveLoadManager.Current.timeEnergy);
    }



    private void OnAddFinished(bool success)
    {
        if (success)
        {
            if (_shopController.ShowAdFor == ShopController.EShowAdFor.key)
            {
                ChangeKeys(1);
                _UIManager.OpenYouGot();
                _UIManager.YouGot.SetUp(YouGotUIPanel.EObjType.key, 1);
            }
            else if (_shopController.ShowAdFor == ShopController.EShowAdFor.timeEnergy)
            {
                ChangeTimeEnergy(25);
                _UIManager.OpenYouGot();
                _UIManager.YouGot.SetUp(YouGotUIPanel.EObjType.energy, 25);
            }
            else if(_shopController.ShowAdFor == ShopController.EShowAdFor.fuel)
            {
                SaveLoadManager.Current.inventoryObjects.TryAdd(new Inventory.InventoryObject(Inventory.Fuel,
                    Inventory.EInventoryObjectRarity.none, 1));
                _UIManager.OpenYouGot();
                _UIManager.YouGot.SetUp(YouGotUIPanel.EObjType.fuel, 1);
            }
            else if (_shopController.ShowAdFor == ShopController.EShowAdFor.toolBox)
            {
                SaveLoadManager.Current.inventoryObjects.TryAdd(new Inventory.InventoryObject(Inventory.ToolBox,
                    Inventory.EInventoryObjectRarity.none, 1));
                _UIManager.OpenYouGot();
                _UIManager.YouGot.SetUp(YouGotUIPanel.EObjType.toolBox, 1);
            }
            else if (_shopController.ShowAdFor == ShopController.EShowAdFor.smallChest)
            {
                SaveLoadManager.Current.smallChests += 1;
                _UIManager.OpenYouGot();
                _UIManager.YouGot.SetUp(YouGotUIPanel.EObjType.smallChest, 1);
            }

            //SFX
            //VFX
        }

        ResetResources();
    }

    private void ShowAdForKey()
    {
        _shopController.ShowAdFor = ShopController.EShowAdFor.key;
        ShowAd();
    }

    private void ShowAdForTimeEnergy()
    {
        _shopController.ShowAdFor = ShopController.EShowAdFor.timeEnergy;
        ShowAd();
    }

    private void ShowAdForFuel()
    {
        _shopController.ShowAdFor = ShopController.EShowAdFor.fuel;
        ShowAd();
    }

    private void ShowAdForToolBox()
    {
        _shopController.ShowAdFor = ShopController.EShowAdFor.toolBox;
        ShowAd();
    }

    private void ShowAdForSmallChest()
    {
        _shopController.ShowAdFor = ShopController.EShowAdFor.smallChest;
        ShowAd();
    }

    private void ShowAd()
    {
        //_adsController.ShowRewardedAd();
        _soundController.PlaySFX(SoundController.ESFXClip.Click);
    }

    private void AddTasks()
    {
        long time = 0;
        bool isNetworkTime = TimeManager.GetNetworkTime(out time);
        DateTime networkTime = new DateTime(time);

        if (!isNetworkTime)
        {
            if (SaveLoadManager.Current.tasks == null || SaveLoadManager.Current.tasks.Length != 5)
            {
                TaskCell[] cells = new TaskCell[5];
                cells[0] = new TaskCell(null, ETaskType.daily, networkTime);
                cells[1] = new TaskCell(null, ETaskType.daily, networkTime);
                cells[2] = new TaskCell(null, ETaskType.daily, networkTime);

                int wait = (int)networkTime.DayOfWeek + 1;
                wait = 168 - 24 * wait;

                cells[3] = new TaskCell(null, ETaskType.weekly, networkTime);
                cells[4] = new TaskCell(null, ETaskType.weekly, networkTime);

                SaveLoadManager.Current.tasks = cells;
            }
            return;
        }

        if (SaveLoadManager.Current.tasks == null || SaveLoadManager.Current.tasks.Length != 5)
        {
            TaskCell[] cells = new TaskCell[5];
            cells[0] = new TaskCell(Task.GenerateTasks(ETaskType.daily), ETaskType.daily, networkTime + new TimeSpan(24, 0, 0));
            cells[1] = new TaskCell(Task.GenerateTasks(ETaskType.daily), ETaskType.daily, networkTime + new TimeSpan(24, 0, 0));
            cells[2] = new TaskCell(Task.GenerateTasks(ETaskType.daily), ETaskType.daily, networkTime + new TimeSpan(24, 0, 0));

            int wait = (int)networkTime.DayOfWeek + 1;
            wait = 168 - 24 * wait;

            cells[3] = new TaskCell(Task.GenerateTasks(ETaskType.weekly), ETaskType.weekly, networkTime + new TimeSpan(wait, 0, 0));
            cells[4] = new TaskCell(Task.GenerateTasks(ETaskType.weekly), ETaskType.weekly, networkTime + new TimeSpan(wait, 0, 0));

            SaveLoadManager.Current.tasks = cells;
        }
        else if (SaveLoadManager.Current.tasks.Length == 5)
        {
            TaskCell[] arr = SaveLoadManager.Current.tasks;

            for (int i = 0; i < arr.Length; i++)
            {
                if(networkTime > arr[i].NewTaskDate && !arr[i].ExistTask)
                {
                    if (arr[i].taskType == ETaskType.daily)
                    {
                        bool isNotVeryOld = networkTime <= arr[i].NewTaskDate + new TimeSpan(24, 0, 0);

                        DateTime dateTime = isNotVeryOld ? arr[i].NewTaskDate : networkTime;

                        arr[i] = new TaskCell(Task.GenerateTasks(ETaskType.daily), 
                            ETaskType.daily, dateTime + new TimeSpan(24, 0, 0));
                    }
                    else
                    {
                        int wait = (int)networkTime.DayOfWeek + 1;
                        wait = 168 - 24 * wait;

                        bool isNotVeryOld = networkTime <= arr[i].NewTaskDate;

                        DateTime dateTime = isNotVeryOld ? arr[i].NewTaskDate : networkTime;

                        arr[i] = new TaskCell(Task.GenerateTasks(ETaskType.weekly),
                            ETaskType.weekly, dateTime + new TimeSpan(wait, 0, 0));
                    }
                }
            }
        }
    }
}