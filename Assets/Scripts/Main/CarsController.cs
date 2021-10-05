using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;

public class CarsController : MonoBehaviour
{
    [SerializeField]
    private GameObject _rotator;
    [SerializeField]
    private GameObject[] _cars;
    private int _currentID;

    

    public int CurrentID
    {
        get => _currentID;
        set 
        {
            _currentID = value;
            OverFlow();

            for(int i = 0; i < _cars.Length; i++)
            {
                _cars[i].SetActive(false);
            }

            _cars[_currentID].SetActive(true);
        }
    }



    public void Left()
    {
        CurrentID--;
    }

    public void Right()
    {
        CurrentID++;
    }

    public void OverFlow()
    {
        if (_currentID < 0)
            _currentID = _cars.Length - 1;
        else if (_currentID >= _cars.Length)
            _currentID = 0;
    }


    public void SetUp(int selectedID)
    {
        CurrentID = selectedID;
    }


    public void Rotate()
    {
        StartCoroutine(Rotation());
    }

    public void StopRotation()
    {
        StopAllCoroutines();
        _rotator.transform.localEulerAngles = Vector3.zero;
    }



    IEnumerator Rotation()
    {
        while (true)
        {
            yield return null;
            _rotator.transform.Rotate(new Vector3(0f, 30f, 0f) * Time.deltaTime);
        }
    }
}