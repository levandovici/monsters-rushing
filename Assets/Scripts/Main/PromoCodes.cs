using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class PromoCodes
{
    public class PromoCode
    {
        public int year;
        public int month;
        public int startDay;
        public int endDay;
        public EPromoCodeID id;
        public int count;
    }

    [System.Serializable]
    public class PromoCodesArchive
    {
        public string[] archive;



        public bool Contains(string s)
        {
            foreach(string str in archive)
            {
                Debug.Log($"{str} ||| {s}");
                if (str.ToUpper().Equals(s.ToUpper()))
                {
                    return true;
                }
            }

            return false;
        }

        public PromoCodesArchive()
        {
            archive = new string[0];
        }

        public void Add(string s)
        {
            string[] arr = new string[archive.Length + 1];
            for(int i = 0; i < arr.Length - 1; i++)
            {
                arr[i] = archive[i];
            }

            arr[arr.Length - 1] = s;

            archive = arr;
        }
    }



    public enum EPromoCodeID
    {
        gems, energy, keys, middle, big, fuel, toolbox
    }



    public static PromoCodesArchive DeleteOldPromoCodes(PromoCodesArchive archive)
    {
        if (archive == null || archive.archive == null || archive.archive.Length == 0)
            return new PromoCodesArchive();

        List<string> list = new List<string>();

        foreach(string s in archive.archive)
        {
            long time = 0;
            bool b = TimeManager.GetNetworkTime(out time);

            if(b)
            {
                DateTime dt = new DateTime(time);

                PromoCode code = null;
                bool bb = TryUnpackPromoCode(s, out code);

                if(bb && code.year == dt.Year && code.month == dt.Month && dt.Day >= code.startDay && dt.Day <= code.endDay)
                {
                    list.Add(s);
                }
            }
        }

        PromoCodesArchive promoCodesArchive = new PromoCodesArchive();
        promoCodesArchive.archive = list.ToArray();
        return promoCodesArchive;
    }

    public static bool TryUnpackPromoCode(string promoCode, out PromoCode obj)
    {
        promoCode = promoCode.ToUpper();

        string[] arr = promoCode.Split('-');
        if(arr.Length != 5)
        {
            Debug.LogError("PromoCode Error 1");
            obj = null;
            return false;
        }


        char[] arr1 = arr[0].ToCharArray();
        char[] arr2 = arr[1].ToCharArray();
        char[] arr3 = arr[2].ToCharArray();
        char[] arr4 = arr[3].ToCharArray();
        char[] arr5 = arr[4].ToCharArray();

        if (arr1.Length != 4 || arr2.Length != 4 || arr3.Length != 4 ||
            arr4.Length != 4 || arr5.Length != 4)
        {
            Debug.LogError("PromoCode Error 2");
            obj = null;
            return false;
        }


        int[] ints = new int[20];
        for(int i = 0; i < 4; i++)
        {
            bool b = GetInt(arr1[i], out ints[i]);
            if(!b)
            {
                obj = null;
                return false;
            }
        }
        for (int i = 0; i < 4; i++)
        {
            bool b = GetInt(arr2[i], out ints[i+4]);
            if (!b)
            {
                obj = null;
                return false;
            }
        }
        for (int i = 0; i < 4; i++)
        {
            bool b = GetInt(arr3[i], out ints[i+8]);
            if (!b)
            {
                obj = null;
                return false;
            }
        }
        for (int i = 0; i < 4; i++)
        {
            bool b = GetInt(arr4[i], out ints[i+12]);
            if (!b)
            {
                obj = null;
                return false;
            }
        }
        for (int i = 0; i < 4; i++)
        {
            bool b = GetInt(arr5[i], out ints[i+16]);
            if (!b)
            {
                obj = null;
                return false;
            }
        }


        PromoCode code = new PromoCode();
        code.count = ints[2] * 36 * 36 + ints[14] * 36 + ints[18];
        code.year = 2020 + ints[1];
        code.month = (ints[5] + 1) / 3;
        code.startDay = ints[13] - 4;
        code.endDay = ints[17] - 3;
        code.id = (EPromoCodeID)(ints[7] % 7);

        if(ints[1] != ints[9])
        {
            Debug.LogError("PromoCode Error 3");
            obj = null;
            return false;
        }

        int sum1 = ints[1] + ints[5] + ints[5] + ints[7] + ints[10] + ints[13] + ints[14] + ints[15] + ints[18] + ints[19];
        int sum2 = ints[2] + ints[3] + ints[5] + ints[6] + ints[9] + ints[12] + ints[14] + ints[16] + ints[17] + ints[17];

        if(sum1 * 3 != ints[0] * 36 + ints[4] || sum2 * 3 != ints[8] * 36 + ints[11])
        {
            Debug.LogError("PromoCode Error 4");
            obj = null;
            return false;
        }

        obj = code;
        return true;
    }

    private static bool GetInt(char c, out int i)
    {
        switch(c)
        {
            case '0':
                i = 0;
                return true;

            case '1':
                i = 1;
                return true;

            case '2':
                i = 2;
                return true;

            case '3':
                i = 3;
                return true;

            case '4':
                i = 4;
                return true;

            case '5':
                i = 5;
                return true;

            case '6':
                i = 6;
                return true;

            case '7':
                i = 7;
                return true;

            case '8':
                i = 8;
                return true;

            case '9':
                i = 9;
                return true;

            case 'A':
                i = 10;
                return true;

            case 'B':
                i = 11;
                return true;

            case 'C':
                i = 12;
                return true;

            case 'D':
                i = 13;
                return true;

            case 'E':
                i = 14;
                return true;

            case 'F':
                i = 15;
                return true;

            case 'G':
                i = 16;
                return true;

            case 'H':
                i = 17;
                return true;

            case 'I':
                i = 18;
                return true;

            case 'J':
                i = 19;
                return true;

            case 'K':
                i = 20;
                return true;

            case 'L':
                i = 21;
                return true;

            case 'M':
                i = 22;
                return true;

            case 'N':
                i = 23;
                return true;

            case 'O':
                i = 24;
                return true;

            case 'P':
                i = 25;
                return true;

            case 'Q':
                i = 26;
                return true;

            case 'R':
                i = 27;
                return true;

            case 'S':
                i = 28;
                return true;

            case 'T':
                i = 29;
                return true;

            case 'U':
                i = 30;
                return true;

            case 'V':
                i = 31;
                return true;

            case 'W':
                i = 32;
                return true;

            case 'X':
                i = 33;
                return true;

            case 'Y':
                i = 34;
                return true;

            case 'Z':
                i = 35;
                return true;

            default:
                i = -1;
                return false;
        }
    }
}