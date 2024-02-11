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
using UnityEditor.PackageManager.Requests;

public class TimeManager
{
    private static bool _isNetworkTime = false;
    private static DateTime _time;



    public static bool GetNetworkTime(out long result)
    {
        if(_isNetworkTime)
        {
            result = _time.Ticks;
            return true;
        }

        try
        {
            DateTime dt;
            bool isCorrect = GetNetTime(out dt);
            if (!isCorrect)
                throw new Exception();

            _time = dt;
            result = _time.Ticks;
        }
        catch
        {
            result = DateTime.Now.Ticks;
            _isNetworkTime = false;
            return false;
        }

        _isNetworkTime = true;
        return true; 
    }

    private static bool GetNetTime(out DateTime result)
    {
        result = DateTime.Now;

        return true;
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