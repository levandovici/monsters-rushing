using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class AdsUIPanel : UIPanel, IUITitled
{
    [SerializeField]
    private Text _title;

    [SerializeField]
    private Button _back;


    public event Action OnBackClicked;



    public void SetTitle(string title)
    {
        _title.text = title;
    }


    private void Awake()
    {
        _back.onClick.AddListener(() => OnBackClicked());
    }

    private void OnDestroy()
    {
        _back.onClick.RemoveAllListeners();
    }
}