using System.Net.Sockets;
using System.Net;
using System;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http;
using System.Text;
using UnityEditor.PackageManager;
using Unity.Android.Gradle;
using TMPro;
using Newtonsoft.Json;

public static class TimeManager
{
    private static bool _isNetworkTime = false;
    private static DateTime _time = DateTime.Now;



    public static bool IsNetworkTime
    {
        get
        {
            return _isNetworkTime;
        }

        private set
        {
            _isNetworkTime = value;
        }
    }

    public static DateTime Time
    {
        get
        {
            return _time;
        }

        private set
        {
            _time = value;
        }
    }



    public static bool GetNetworkTime(out long result)
    {
        result = DateTime.Now.Ticks;

        return _isNetworkTime;
    }

    public static async Task<GetNetTimeResult> GetNetworkTime()
    {
        try
        {
            GetNetTimeResult res = await GetNetTime();

            if (!res.success)
            {
                throw new Exception("GetNetTimeResult: Success: False");
            }

            _time = res.time;

            _isNetworkTime = true;
        }
        catch
        {
            _time = DateTime.Now;

            _isNetworkTime = false;
        }

        return new GetNetTimeResult(_isNetworkTime, _time);
    }

    public static async Task<GetNetTimeResult> GetNetTime(float timeoutSeconds = 10f)
    {
        throw new NotImplementedException();
    }


    public static bool IsHolliday(DateTime dateTime)
    {
        return (int)CurrentHolliday(dateTime) != 0;
    }

    public static bool IsHolliday(long ticks)
    {
        return IsHolliday(new DateTime(ticks));
    }


    public static bool IsWeekend(DateTime dateTime)
    {
        DayOfWeek day = dateTime.DayOfWeek;

        if (day == DayOfWeek.Saturday || day == DayOfWeek.Sunday)
            return true;

        return false;
    }

    public static bool IsWeekend(long ticks)
    {
        return IsWeekend(new DateTime(ticks));
    }




    // Class to match the JSON structure
    [System.Serializable]
    private class TimeData
    {
        public long ticks;
        public string datetime;
    }



    public struct GetNetTimeResult
    {
        public bool success;

        public DateTime time;



        public GetNetTimeResult(bool success, DateTime time)
        {
            this.success = success;

            this.time = time;
        }
    }





    public static EHolliday CurrentHolliday(DateTime dateTime)
    {
        if (dateTime.Month >= 3 && dateTime.Month <= 5)
        {
            return EHolliday.Paska;
        }
        else if (dateTime.Month >= 12 && dateTime.Month <= 1)
        {
            return EHolliday.Christmas;
        }

        return EHolliday.No;
    }

    public static EHolliday CurrentHolliday(long ticks)
    {
        return CurrentHolliday(new DateTime(ticks));
    }



    public enum EHolliday
    {
       No = 0, Christmas = 1, Paska = 2
    }
}