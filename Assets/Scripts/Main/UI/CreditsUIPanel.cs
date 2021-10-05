using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vocabulary;

public class CreditsUIPanel : UIPanel, IUITitled
{
    [SerializeField]
    private Text _title;

    [SerializeField]
    private Text _creditsText;



    public void SetTitle(string title)
    {
        _title.text = title;
    }



    public void SetLnaguage(SystemLanguage language)
    {
        SetTitle(Words.GetWord(Word.credits, language));
        _creditsText.text = Words.GetWord(Word.credits_text, language);
    }
}