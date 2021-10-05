using UnityEngine;
using System.Text;
using System;

[System.Serializable]
public class Data
{
    private const int CriptCount = 3;

    public ESerialization version;
    public string encriptedData;



    public string decriptedData => Decription(version, encriptedData, CriptCount);



    public Data(ESerialization version, string data)
    {
        this.version = version;
        this.encriptedData = Encription(version, data, CriptCount);
    }



    private string Encription(ESerialization version, string data, int count)
    {
        while (count > 0)
        {
            count--;
            data = Encription(version, data);
        }

        return data;
    }

    private string Decription(ESerialization version, string data, int count)
    {
        while (count > 0)
        {
            count--;
            data = Decription(version, data);
        }

        return data;
    }


    private string Encription(ESerialization version, string data)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(Round(data));

        for (int i = 0; i < bytes.Length; i += 4)
        {
            byte[] arr = BitConverter.GetBytes(BitConverter.ToInt32(bytes, i) ^ GetSecurityCode(version));

            bytes[i] = arr[0];
            bytes[i + 1] = arr[1];
            bytes[i + 2] = arr[2];
            bytes[i + 3] = arr[3];
        }


        return BitConverter.ToString(bytes).Replace("-", "");
    }

    private string Decription(ESerialization version, string data)
    {
        int CharsCount = data.Length;

        byte[] bytes = new byte[CharsCount / 2];

        for (int i = 0; i < CharsCount; i += 2)
        {
            bytes[i / 2] = Convert.ToByte(data.Substring(i, 2), 16);
        }

        for (int i = 0; i < bytes.Length; i += 4)
        {
            byte[] arr = BitConverter.GetBytes(BitConverter.ToInt32(bytes, i) ^ GetSecurityCode(version));

            bytes[i] = arr[0];
            bytes[i + 1] = arr[1];
            bytes[i + 2] = arr[2];
            bytes[i + 3] = arr[3];
        }


        return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
    }

    private static string Round(string str)
    {
        int length = str.Length;
        int count = 0;

        while (length >= 4)
        {
            count++;
            length -= 4;
        }

        count = 4 - length;

        StringBuilder sb = new StringBuilder();

        if (count < 4)
            for (int i = 0; i < count; i++)
            {
                sb.Append(" ");
            }
        sb.Append(str);

        return sb.ToString();
    }


    private int GetSecurityCode(ESerialization version)
    {
        int code = 9999999;

        switch (version)
        {
            case ESerialization.zero:
                code = 0;
                break;

            case ESerialization.one:
                code = 15625*2*2*2*2*2*2 + 3125*2*2*2*2*2*2 + 3125*2*2*2*2 + 875*2*2*2 + 225*2*2 + 2*2*2 + 2*2 + 2;
                break;

            default:
                code = 9999999;
                break;
        }

        return code;
    }



    public enum ESerialization
    {
        zero = 0, one = 1,
    }
}