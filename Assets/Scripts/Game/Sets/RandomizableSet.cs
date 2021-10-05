using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class RandomizableSet
{
    public int randomizeWeight; //0 - did not spawn, //1-oo spawnRarity where 1 is rare, oo is common



    public static T GetRandom<T>(T[] arr) where T : RandomizableSet
    {
        int count = 0;
        for (int i = 0; i < arr.Length; i++)
            count += arr[i].randomizeWeight;

        int[,] get = new int[arr.Length, 2]; //at-to
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i].randomizeWeight == 0)
            {
                get[i, 0] = 0;
                get[i, 1] = 0;
            }
            else
            {
                int pre = 0;
                for (int j = 0; j < i; j++)
                    pre += arr[j].randomizeWeight;

                get[i, 0] = pre + 1;
                get[i, 1] = pre + arr[i].randomizeWeight;
            }
        }


        int r = UnityEngine.Random.Range(0, count) + 1;

        for (int i = 0; i < get.GetLength(0); i++)
        {
            if (r >= get[i, 0] && r <= get[i, 1])
            {
                return arr[i];
            }
        }

        throw new NullReferenceException("Object weight is 0 or null array");
    }
}