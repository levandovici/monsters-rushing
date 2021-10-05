using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Antity : MonoBehaviour
{
    [SerializeField]
    private string _id;



    public string id => _id;



    public void NewGUID()
    {
        _id = Guid.NewGuid().ToString();
    }
}