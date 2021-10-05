using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Target
{
    public static GameObject[] Targets(ETarget targetTypes)
    {
        List<GameObject> list = new List<GameObject>();

        string[] tags = Tags(targetTypes);
        foreach(string tag in tags)
            list.AddRange(GameObject.FindGameObjectsWithTag(tag));

        return list.ToArray();
    }

    public static string[] Tags(ETarget targetTypes)
    {
        List<string> tags = new List<string>();

        ETarget t = targetTypes & ETarget.Player;
        if(t == ETarget.Player)
        {
            tags.Add("Player");
        }

        t = targetTypes & ETarget.Obj;
        if(t == ETarget.Obj)
        {
            tags.Add("Obj");
        }

        t = targetTypes & ETarget.Monster;
        if(t == ETarget.Monster)
        {
            tags.Add("Monster");
        }

        t = targetTypes & ETarget.Tower;
        if(t == ETarget.Tower)
        {
            tags.Add("Tower");
        }

        return tags.ToArray();
    }



    [System.Flags]
    public enum ETarget
    {
        Player = 1, Obj = 2, Monster = 4, Tower = 8
    }

    public enum EFindTarget
    {
        Forward, Radius
    }
}