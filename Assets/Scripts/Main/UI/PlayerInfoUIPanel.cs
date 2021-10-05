using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vocabulary;

public class PlayerInfoUIPanel : UIPanel, IUITitled
{
    [SerializeField]
    private Text _title;

    [SerializeField]
    private Text _nameText;
    [SerializeField]
    private Text _name;
    [SerializeField]
    private Text _bestDistanceText;
    [SerializeField]
    private Text _bestDistance;
    [SerializeField]
    private Button _editName;



    public event Action OnEditNameClicked;



    public void SetTitle(string title)
    {
        _title.text = title;
    }

    public void SetLanguage(SystemLanguage language)
    {
        SetTitle(Words.GetWord(Word.player_info, language));
        _nameText.text = Words.GetWord(Word.name, language);
        _bestDistanceText.text = Words.GetWord(Word.best_distance, language);
    }

    public void SetUp(string name, int bestDistance)
    {
        _name.text = name;
        _bestDistance.text = bestDistance.ToString();
    }



    private void Awake()
    {
        _editName.onClick.AddListener(() => OnEditNameClicked.Invoke());
    }

    private void OnDestroy()
    {
        _editName.onClick.RemoveAllListeners();
    }
}