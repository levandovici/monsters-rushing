using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using Vocabulary;

public class OverUIPanel : UIPanel, IUITitled
{
    private SystemLanguage _language; 



    [SerializeField]
    private Text _title;

    [SerializeField]
    private Text _distanceTitle;
    [SerializeField]
    private Text _distance;
    [SerializeField]
    private GameObject _trophey;
    [SerializeField]
    private Text _destroyTitle;
    [SerializeField]
    private Text _destroy;
    [SerializeField]
    private Text _specialTitle;
    [SerializeField]
    private Text _special;

    [SerializeField]
    private Text _totalTitle;
    [SerializeField]
    private Text _total;
    [SerializeField]
    private GameObject _x2Water;

    [SerializeField]
    private Button _quit;



    public event Action OnQuitClicked;



    public void SetDistance(int distance, bool newRecord)
    {
        _distance.text = distance.ToString();
        _trophey.SetActive(newRecord);
    }

    public void SetDestroy(int water)
    {
        _destroy.text = water.ToString();
    }

    public void SetSpecial(int water)
    {
        _special.text = water.ToString();
    }

    public void SetTotal(int water, bool x2Water)
    {
        _total.text = water.ToString();
        _x2Water.SetActive(x2Water);
    }


    public void SetLanguage(SystemLanguage language)
    {
        _language = language;
  
        _distanceTitle.text = Words.GetWord(Word.distance, language);
        _destroyTitle.text = Words.GetWord(Word.destroy, language);
        _specialTitle.text = Words.GetWord(Word.special, language);
        _totalTitle.text = Words.GetWord(Word.total, language);
    }


    public void SetTitle(string title)
    {
        _title.text = title;
    }



    private void Start()
    {
        _quit.onClick.AddListener(() => OnQuitClicked.Invoke());    
    }



    private void OnDestroy()
    {
        _quit.onClick.RemoveAllListeners();
    }
}