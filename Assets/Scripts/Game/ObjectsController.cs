using System.Collections.Generic;
using UnityEngine;
using System;

public static class ObjectsController
{
    private static Dictionary<string, Stack<Antity>> FreeObjects = new Dictionary<string, Stack<Antity>>();
    private static int Counter = 0;
    private static int MaxObjects = 32;



    private static int MaxObjectsCount => 
        Mathf.Clamp((int)(SystemInfo.systemMemorySize / 256f) * 32, 32, 256);



    public static int ObjectsCount => Counter;

    public static int MaxCount => MaxObjects;



    public static void DestroyAntity(Antity antity)
    {
        if (antity.gameObject.activeSelf)
        {
            if (antity.id != null && Counter < MaxObjects)
            {
                GameObject go = antity.gameObject;
                go.SetActive(false);

                Stack<Antity> stack = null;

                bool exist = FreeObjects.TryGetValue(antity.id, out stack);

                if (!exist)
                    stack = new Stack<Antity>();

                stack.Push(antity);

                if (!exist)
                    FreeObjects.Add(antity.id, stack);
            }
            else
            {
                Counter--;
                GameObject.Destroy(antity.gameObject);
            }
        }
    }

    public static T InstantiateAntity<T>(T antity, Vector3 pos) where T : Antity
    {
        return InstantiateAntity(antity, pos, Quaternion.identity);
    }

    public static T InstantiateAntity<T>(T antity, Vector3 pos, Quaternion quaternion) where T : Antity
    {
        Stack<Antity> stack = null;

        bool exist = antity.id != null && FreeObjects.TryGetValue(antity.id, out stack);

        if (stack != null)
            exist = stack.Count > 0;


        Antity a = null;

        if(exist)
        while (stack.Count > 0)
        {
            a = stack.Pop();

            if (a != null)
            {
                exist = true;
                break;
            }
            else
            {
                Debug.LogError("Antity was destroyed!!! Is null!!!");
                exist = false;
            }
        }


        if (exist)
        {
            a.gameObject.SetActive(true);
            a.transform.position = pos;
            a.transform.rotation = quaternion;

            return a as T;
        }
        else
        {
            Counter++;
            return GameObject.Instantiate(antity, pos, quaternion);
        }
    }


    public static T CloneAntity<T>(T antity) where T : Antity
    {
        return InstantiateAntity(antity, antity.transform.position);
    } 



    public static void Reset()
    {
        FreeObjects = new Dictionary<string, Stack<Antity>>();
        Counter = 0;
        MaxObjects = MaxObjectsCount;
    }
}