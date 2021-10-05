using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainController : MonoBehaviour
{
    private int _newKeyTime = -1;
    private bool _activated = false;



    public event Action OnKeyAdd;
    public event Action<int> OnNewKeyTimeChanged;
    public event Func<int> OnKeysCountNeed;
    public event Func<int> OnMaxFreeKeysNeed;
    public event Func<int> OnNewKeyAfterNeed;



    public void SetNewKeyTime(int newKeyTime)
    {
        if (OnKeysCountNeed.Invoke() < OnMaxFreeKeysNeed.Invoke())
        {
            _newKeyTime = newKeyTime;

            OnNewKeyTimeChanged.Invoke(newKeyTime);

            if (newKeyTime == 0)
            {
                OnKeyAdd.Invoke();
            }

            if (newKeyTime <= 0)
            {
                _newKeyTime = OnNewKeyAfterNeed();
            }
        }
        else
        {
            OnNewKeyTimeChanged.Invoke(-1);
        }
    }


    public bool ActivateTimer()
    {
        if (_activated)
            return false;

        StartCoroutine(Timer());

        return _activated = true;
    }



    private IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            SetNewKeyTime(_newKeyTime - 1);
        }
    }
}