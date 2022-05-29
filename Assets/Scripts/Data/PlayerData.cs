using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Runtime.InteropServices;
using System;
using Tasks;

[System.Serializable]
public class PlayerData
{
    private const string NoneEmail = "none";


    public long lastNetworkTime;
    public string name;
    public int newKeyTime = 0;
    public int keys = 3;
    public int gems = 0;
    public int timeEnergy = 10;
    public float sfxVolume = 0.5f;
    public float musicVolume = 0.5f;
    public CarData[] carsData = CarData.GetCarsData();
    public int selectedCar = 0;
    public bool x3Gems = false;
    public int bestScore = 0;
    public SystemLanguage language;
    public string connectedEmail = "none";
    public int freeNameEdit = 2;
    public bool googleConnected = false;
    public Tasks.TaskCell[] tasks = null;
    public Achievement[] achievements = null;
    public Inventory.InventoryObjects inventoryObjects = null;
    public int smallChests = 0;
    public int middleChests = 0;
    public int bigChests = 0;
    public PromoCodes.PromoCodesArchive promoCodesArchive;



    public CarData SelectedCarData => carsData[selectedCar];

    public int Cars => carsData.Length;

    public int UnlockedCars
    {
        get
        {
            int i = 0;

            foreach (CarData carData in carsData)
                if (carData.bought) i++;

            return i;
        }
    }



    public PlayerData() : this(GetRandomName(), -1, 10, 0, 10, 0.5f, 0.5f, 
        CarData.GetCarsData(), 0, false, 0, GetLanguage(), NoneEmail, 2,
         false, null, null)
    {

    }

    public PlayerData(string name, int newKeyTime, int keys, int water,
        int timeEnergy, float sfxVolume, float musicVolume, CarData[] carsData,
        int selectedCar, bool x2Water, int bestScore, SystemLanguage language,
        string connectedEmail, int freeNameEdit, bool googleConnected, 
        TaskCell[] tasks, Achievement[] achievements)
    {
        this.name = name;
        this.newKeyTime = newKeyTime;
        this.keys = keys;
        this.gems = water;
        this.timeEnergy = timeEnergy;
        this.sfxVolume = sfxVolume;
        this.musicVolume = musicVolume;
        this.carsData = carsData;
        this.selectedCar = selectedCar;
        this.x3Gems = x2Water;
        this.bestScore = bestScore;
        this.language = language;
        this.connectedEmail = connectedEmail;
        this.freeNameEdit = freeNameEdit;
        this.googleConnected = googleConnected;
        this.tasks = tasks;
        this.achievements = achievements;
        this.middleChests = 0;
        this.smallChests = 0;
        this.bigChests = 0;
    }



    public static string GetRandomName()
    {
        StringBuilder sb = new StringBuilder();

        for(int i = 0; i < 10; i++)
        {
            sb.Append(UnityEngine.Random.Range(0, 10));
        }

        return sb.ToString();
    }

    public static bool IsNoneEmail(string email)
    {
        if (email == NoneEmail)
            return true;

        return false;
    }



    private static SystemLanguage GetLanguage()
    {
        foreach (SystemLanguage lang in Vocabulary.Words.SupportedLanguages)
        {
            if (Application.systemLanguage == lang)
                return lang;
        } 

        return SystemLanguage.English;
    }



    [System.Serializable]
    public class CarData
    {
        public bool bought;

        public Level healthLevel;
        public Level damageLevel;
        public Level capacityLevel;
        public Level fuelLevel;

        public Inventory.InventoryObjects upgradeHealth;
        public Inventory.InventoryObjects upgradeDamage;
        public Inventory.InventoryObjects upgradeBullets;
        public Inventory.InventoryObjects upgradeFuel;



        public void UpgradeHealth()
        {
            healthLevel = (Level)((int)healthLevel + 1);
        }

        public void UpgradeDamage()
        {
            damageLevel = (Level)((int)damageLevel + 1);
        }

        public void UpgradeCapacity()
        {
            capacityLevel = (Level)((int)capacityLevel + 1);
        }

        public void UpgradeFuel()
        {
            fuelLevel = (Level)((int)fuelLevel + 1);
        }



        public CarData(bool bought)
        {
            this.bought = bought;

            this.healthLevel = Level.zero;
            this.damageLevel = Level.zero;
            this.capacityLevel = Level.zero;
            this.fuelLevel = Level.zero;

            this.upgradeHealth = null;
            this.upgradeDamage = null;
            this.upgradeBullets = null;
            this.upgradeFuel = null;
        }


        public static CarUpgrade GetCarUpgrade(int index)
        {
            switch (index)
            {
                case 0:
                    return new CarUpgrade(
                new CarUpgrade.Prices(500, 1000, 2500, 5000, 10000, 25000, 50000, 100000, 250000, 500000),
                new CarUpgrade.Health(1000, 1100, 1200, 1300, 1400, 1500, 1600, 1700, 1800, 1900, 2000),
                new CarUpgrade.Damage(20, 22, 24, 26, 28, 30, 32, 34, 36, 38, 40),
                new CarUpgrade.Capacity(110, 112, 114, 116, 118, 120, 122, 124, 126, 128, 130),
                new CarUpgrade.Fuel(150*3, 160*3, 170*3, 180*3, 190*3, 200*3, 210*3, 220*3, 230*3, 240*3, 250*3));

                case 1:
                    return new CarUpgrade(
                new CarUpgrade.Prices(1000, 2000, 5000, 10000, 20000, 50000, 100000, 200000, 500000, 1000000),
                new CarUpgrade.Health(2000, 2200, 2400, 2600, 2800, 3000, 3200, 3400, 3600, 3800, 4000),
                new CarUpgrade.Damage(140, 144, 148, 152, 156, 160, 164, 169, 172, 176, 180),
                new CarUpgrade.Capacity(16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36),
                new CarUpgrade.Fuel(200*3, 210*3, 220*3, 230*3, 240*3, 250*3, 260*3, 270*3, 280*3, 290*3, 300*3));

                case 2:
                    return new CarUpgrade(
                new CarUpgrade.Prices(2000, 4000, 10000, 20000, 40000, 100000, 200000, 400000, 1000000, 2000000),
                new CarUpgrade.Health(4000, 4400, 4800, 5200, 5600, 6000, 6400, 6800, 7200, 7600, 8000),
                new CarUpgrade.Damage(180, 188, 196, 204, 212, 220, 228, 236, 244, 252, 260),
                new CarUpgrade.Capacity(22, 24, 26, 28, 30, 32, 34, 36, 38, 40, 42),
                new CarUpgrade.Fuel(250*3, 260*3, 270*3, 280*3, 290*3, 300*3, 310*3, 320*3, 330*3, 340*3, 350*3));

                case 3:
                    return new CarUpgrade(
                new CarUpgrade.Prices(3000, 6000, 15000, 30000, 60000, 150000, 300000, 600000, 1500000, 3000000),
                new CarUpgrade.Health(8000, 8800, 9600, 10400, 11200, 1200, 12800, 13600, 14400, 15200, 16000),
                new CarUpgrade.Damage(260, 276, 292, 308, 324, 340, 356, 372, 388, 404, 420),
                new CarUpgrade.Capacity(28, 30, 32, 34, 36, 38, 40, 42, 44, 46, 48),
                new CarUpgrade.Fuel(300*3, 310*3, 320*3, 330*3, 340*3, 350*3, 360*3, 370*3, 380*3, 390*3, 400*3));

                case 4:
                    return new CarUpgrade(
                new CarUpgrade.Prices(5000, 10000, 25000, 50000, 100000, 250000, 500000, 1000000, 2500000, 5000000),
                new CarUpgrade.Health(16000, 17600, 19200, 20800, 22400, 24000, 25600, 27200, 28800, 30400, 32000),
                new CarUpgrade.Damage(420, 452, 484, 516, 548, 580, 612, 644, 676, 708, 740),
                new CarUpgrade.Capacity(34, 36, 38, 40, 42, 44, 46, 48, 50, 52, 54),
                new CarUpgrade.Fuel(350*3, 360*3, 370*3, 380*3, 390*3, 400*3, 410*3, 420*3, 430*3, 440*3, 450*3));
            }

            throw new NotImplementedException();
        }

        public static int GetCarPrice(int index)
        {
            switch (index)
            {
                case 0:
                    return 2500000;

                case 1:
                    return 5000000;

                case 2:
                    return 10000000;

                case 3:
                    return 15000000;

                case 4:
                    return 25000000;
            }

            throw new NotImplementedException();
        }

        public static CarData[] GetCarsData()
        {
            CarData[] arr = new CarData[5];

            arr[0] = new CarData(true);   
            
            arr[1] = new CarData(false);

            arr[2] = new CarData(false);

            arr[3] = new CarData(false);

            arr[4] = new CarData(false);


            return arr;
        }

        public static CarData[] CheckCarData(CarData[] cars)
        {
            CarData[] datas = GetCarsData();

            if (cars.Length < datas.Length)
            {
                for (int i = 0; i < cars.Length; i++)
                {
                    datas[i] = cars[i];
                }
                return datas;
            }

            return cars;
        }



        [System.Serializable]
        public class CarUpgrade
        {
            public Prices prices;
            public Health health;
            public Damage damage;
            public Capacity capacity;
            public Fuel fuel;



            public int HealthUpgradePrice(Level level) => prices[(int)level];

            public int DamageUpgradePrice(Level level) => prices[(int)level];

            public int CapacityUpgradePrice(Level level) => prices[(int)level];

            public int FuelUpgradePrice(Level level) => prices[(int)level];



            public float CurrentHealth(Level level) => health[(int)level];

            public float CurrentDamage(Level level) => damage[(int)level];

            public int CurrentCapacity(Level level) => capacity[(int)level];

            public int CurrentFuel(Level level) => fuel[(int)level];



            public CarUpgrade(Prices prices, Health health, Damage damage, Capacity capacity, Fuel fuel)
            {
                this.prices = prices;
                this.health = health;
                this.damage = damage;
                this.capacity = capacity;
                this.fuel = fuel;
            }



            public struct Prices
            {
                public int level_1;
                public int level_2;
                public int level_3;
                public int level_4;
                public int level_5;
                public int level_6;
                public int level_7;
                public int level_8;
                public int level_9;
                public int level_10;



                public Prices(int level_1, int level_2, int level_3, int level_4, int level_5,
                    int level_6, int level_7, int level_8, int level_9, int level_10)
                {
                    this.level_1 = level_1;
                    this.level_2 = level_2;
                    this.level_3 = level_3;
                    this.level_4 = level_4;
                    this.level_5 = level_5;
                    this.level_6 = level_6;
                    this.level_7 = level_7;
                    this.level_8 = level_8;
                    this.level_9 = level_9;
                    this.level_10 = level_10;
                }



                public int this[int index]
                {
                    get
                    {
                        switch (index)
                        {
                            case 1:
                                return level_2;

                            case 2:
                                return level_3;

                            case 3:
                                return level_4;

                            case 4:
                                return level_5;

                            case 5:
                                return level_6;

                            case 6:
                                return level_7;

                            case 7:
                                return level_8;

                            case 8:
                                return level_9;

                            case 9:
                                return level_10;

                            default:
                                return level_1;
                        }
                    }
                }
            }

            public struct Health
            {
                public float level_0;
                public float level_1;
                public float level_2;
                public float level_3;
                public float level_4;
                public float level_5;
                public float level_6;
                public float level_7;
                public float level_8;
                public float level_9;
                public float level_10;



                public Health(float level_0, float level_1, float level_2, float level_3, float level_4, float level_5,
                    float level_6, float level_7, float level_8, float level_9, float level_10)
                {
                    this.level_0 = level_0;
                    this.level_1 = level_1;
                    this.level_2 = level_2;
                    this.level_3 = level_3;
                    this.level_4 = level_4;
                    this.level_5 = level_5;
                    this.level_6 = level_6;
                    this.level_7 = level_7;
                    this.level_8 = level_8;
                    this.level_9 = level_9;
                    this.level_10 = level_10;
                }



                public float this[int index]
                {
                    get
                    {
                        switch (index)
                        {
                            case 1:
                                return level_1;

                            case 2:
                                return level_2;

                            case 3:
                                return level_3;

                            case 4:
                                return level_4;

                            case 5:
                                return level_5;

                            case 6:
                                return level_6;

                            case 7:
                                return level_7;

                            case 8:
                                return level_8;

                            case 9:
                                return level_9;

                            case 10:
                                return level_10;

                            default:
                                return level_0;
                        }
                    }
                }
            }

            public struct Damage
            {
                public float level_0;
                public float level_1;
                public float level_2;
                public float level_3;
                public float level_4;
                public float level_5;
                public float level_6;
                public float level_7;
                public float level_8;
                public float level_9;
                public float level_10;



                public Damage(float level_0, float level_1, float level_2, float level_3, float level_4, float level_5,
                    int level_6, float level_7, float level_8, float level_9, float level_10)
                {
                    this.level_0 = level_0;
                    this.level_1 = level_1;
                    this.level_2 = level_2;
                    this.level_3 = level_3;
                    this.level_4 = level_4;
                    this.level_5 = level_5;
                    this.level_6 = level_6;
                    this.level_7 = level_7;
                    this.level_8 = level_8;
                    this.level_9 = level_9;
                    this.level_10 = level_10;
                }



                public float this[int index]
                {
                    get
                    {
                        switch (index)
                        {
                            case 1:
                                return level_1;

                            case 2:
                                return level_2;

                            case 3:
                                return level_3;

                            case 4:
                                return level_4;

                            case 5:
                                return level_5;

                            case 6:
                                return level_6;

                            case 7:
                                return level_7;

                            case 8:
                                return level_8;

                            case 9:
                                return level_9;

                            case 10:
                                return level_10;

                            default:
                                return level_0;
                        }
                    }
                }
            }

            public struct Capacity
            {
                public int level_0;
                public int level_1;
                public int level_2;
                public int level_3;
                public int level_4;
                public int level_5;
                public int level_6;
                public int level_7;
                public int level_8;
                public int level_9;
                public int level_10;



                public Capacity(int level_0, int level_1, int level_2, int level_3, int level_4, int level_5,
                    int level_6, int level_7, int level_8, int level_9, int level_10)
                {
                    this.level_0 = level_0;
                    this.level_1 = level_1;
                    this.level_2 = level_2;
                    this.level_3 = level_3;
                    this.level_4 = level_4;
                    this.level_5 = level_5;
                    this.level_6 = level_6;
                    this.level_7 = level_7;
                    this.level_8 = level_8;
                    this.level_9 = level_9;
                    this.level_10 = level_10;
                }



                public int this[int index]
                {
                    get
                    {
                        switch (index)
                        {
                            case 1:
                                return level_1;

                            case 2:
                                return level_2;

                            case 3:
                                return level_3;

                            case 4:
                                return level_4;

                            case 5:
                                return level_5;

                            case 6:
                                return level_6;

                            case 7:
                                return level_7;

                            case 8:
                                return level_8;

                            case 9:
                                return level_9;

                            case 10:
                                return level_10;

                            default:
                                return level_0;
                        }
                    }
                }
            }

            public struct Fuel
            {
                public int level_0;
                public int level_1;
                public int level_2;
                public int level_3;
                public int level_4;
                public int level_5;
                public int level_6;
                public int level_7;
                public int level_8;
                public int level_9;
                public int level_10;



                public Fuel(int level_0, int level_1, int level_2, int level_3, int level_4, int level_5,
                    int level_6, int level_7, int level_8, int level_9, int level_10)
                {
                    this.level_0 = level_0;
                    this.level_1 = level_1;
                    this.level_2 = level_2;
                    this.level_3 = level_3;
                    this.level_4 = level_4;
                    this.level_5 = level_5;
                    this.level_6 = level_6;
                    this.level_7 = level_7;
                    this.level_8 = level_8;
                    this.level_9 = level_9;
                    this.level_10 = level_10;
                }



                public int this[int index]
                {
                    get
                    {
                        switch (index)
                        {
                            case 1:
                                return level_1;

                            case 2:
                                return level_2;

                            case 3:
                                return level_3;

                            case 4:
                                return level_4;

                            case 5:
                                return level_5;

                            case 6:
                                return level_6;

                            case 7:
                                return level_7;

                            case 8:
                                return level_8;

                            case 9:
                                return level_9;

                            case 10:
                                return level_10;

                            default:
                                return level_0;
                        }
                    }
                }
            }
        }

        public enum Level
        {
            zero, one, two, three, four, five, six, seven, eight, nine, ten,
        }
    }
}