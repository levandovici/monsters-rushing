using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Vocabulary;

public class InternetRequireUIPanel : UIPanel, IUITitled
{
    [SerializeField]
    private Text _title;

    [SerializeField]
    private Button _ok;

    [SerializeField]
    private Button _close;

    [SerializeField]
    private Text _okText;



    public void SetTitle(string title)
    {
        _title.text = title;
    }

    public void SetLanguage(SystemLanguage language)
    {
        _okText.text = Words.GetWord(Word.ok, language);
        _title.text = Words.GetWord(Word.network_require, language);
    }



    public void Awake()
    {
        _ok.onClick.AddListener(() => this.Hide());
        _close.onClick.AddListener(() => this.Hide());
    }

    public void OnDestroy()
    {
        _ok.onClick.RemoveAllListeners();
        _close.onClick.RemoveAllListeners();
    }
}