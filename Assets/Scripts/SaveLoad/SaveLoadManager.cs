using System.Collections.Generic;
using System;
using UnityEngine;


public static class SaveLoadManager
{
    private const string FileName = "data";

    private static ISaveLoader _saveLoader = new PlayerPrefsSaveLoader();
    private static PlayerData _current = null;



    public static PlayerData Current => _current;

    public static bool IsFirstLoad => _saveLoader.isFirstLoad;



    public static void Save()
    {
        _current.promoCodesArchive = PromoCodes.DeleteOldPromoCodes(_current.promoCodesArchive);
        _saveLoader.Save(_current, FileName);
    }

    public static void Load()
    {
        _current = _saveLoader.Load(FileName);
        Check(_current);
        TimeHelper(_current);
    }

    public static void Check(PlayerData data)
    {
        data.carsData = PlayerData.CarData.CheckCarData(data.carsData);
        data.inventoryObjects = Inventory.CheckInventory(data.inventoryObjects);
    }


    //public static void SaveToCloud(PlayerData playerData)
    //{
    //    string data = _saveLoader.Convert(playerData);
    //    GooglePlayServicesManager.GooglePlayCloud.Save(FileName, data);
    //}

    //public static void LoadFromCloud()
    //{
    //    string data = null;
    //    bool done = GooglePlayServicesManager.GooglePlayCloud.Load(FileName, out data);

    //    _current = _saveLoader.Convert(data);
    //}



    public static int MaxFreeKeys()
    {
        int maxFreeKeys = 3;

        long time = 0;
        bool isNetworkTime = TimeManager.GetNetworkTime(out time);

        if (TimeManager.IsHolliday(time) && isNetworkTime)
        {
            maxFreeKeys = 5;
        }
        else if (TimeManager.IsWeekend(time) && isNetworkTime)
        {
            maxFreeKeys = 4;
        }

        return maxFreeKeys;
    }

    public static int NewKeyAfter()
    {
        int newKeyAfter = 900;

        long time = 0;
        bool isNetworkTime = TimeManager.GetNetworkTime(out time);

        if (TimeManager.IsHolliday(time) && isNetworkTime)
        {
            newKeyAfter = 600;
        }
        else if (TimeManager.IsWeekend(time) && isNetworkTime)
        {
            newKeyAfter = 720;
        }

        return newKeyAfter;
    }


    
    private static void TimeHelper(PlayerData playerData)
    {

        long timeNow = 0;
        bool isNetworkTime = TimeManager.GetNetworkTime(out timeNow);

        if (isNetworkTime)
        {
            long time = playerData.lastNetworkTime;
            TimeSpan dif = new TimeSpan(timeNow - time);

            int seconds = (int)dif.TotalSeconds;
            int kAfter = playerData.newKeyTime;

            while (seconds-- > 0)
            {
                kAfter--;

                if (playerData.keys >= MaxFreeKeys())
                    break;

                if (kAfter == 0)
                {
                    playerData.keys++;
                    kAfter = NewKeyAfter();
                }

                if (kAfter < 0)
                {
                    kAfter = NewKeyAfter();
                }
            }

            playerData.newKeyTime = kAfter;

            playerData.lastNetworkTime = timeNow;
            Save();
        }
    }
}