using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vocabulary;

public class PromoCodeErrorUIPanel : UIPanel, IUITitled
{
    [SerializeField]
    private Text _title;

    [SerializeField]
    private Button _ok;

    [SerializeField]
    private Button _close;

    [SerializeField]
    private Text _okText;

    [SerializeField]
    private Text _promoCodeErrorText;



    public event Action OnOkClicked;



    private void Awake()
    {
        _ok.onClick.AddListener(() =>
        {
            this.Hide();
            OnOkClicked.Invoke();
        });
        _close.onClick.AddListener(() =>
        {
            this.Hide();
            OnOkClicked.Invoke();
        });
    }

    private void OnDestroy()
    {
        _ok.onClick.RemoveAllListeners();
        _close.onClick.RemoveAllListeners();
    }



    public void SetTitle(string title)
    {
        _title.text = title;
    }

    public void SetLanguage(SystemLanguage language)
    {
        _okText.text = Words.GetWord(Word.ok, language);
        _promoCodeErrorText.text = Words.GetWord(Word.the_promo_code_is_incorrect_or_used, language);
    }
}
