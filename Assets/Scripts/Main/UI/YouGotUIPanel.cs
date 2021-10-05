using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vocabulary;

public class YouGotUIPanel : UIPanel, IUITitled
{
    [SerializeField]
    private Text _title;

    [SerializeField]
    private Text _okText;
    [SerializeField]
    private Button _ok;
    [SerializeField]
    private Button _close;

    [SerializeField]
    private Text _count;

    [SerializeField]
    private GameObject _smallChest;
    [SerializeField]
    private GameObject _middleChest;
    [SerializeField]
    private GameObject _bigChest;
    [SerializeField]
    private GameObject _key;
    [SerializeField]
    private GameObject _fuel;
    [SerializeField]
    private GameObject _toolBox;
    [SerializeField]
    private GameObject _gems;
    [SerializeField]
    private GameObject _energy;



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



    public void SetUp(EObjType obj, int count)
    {
        _smallChest.SetActive(false);
        _middleChest.SetActive(false);
        _bigChest.SetActive(false);
        _key.SetActive(false);
        _fuel.SetActive(false);
        _toolBox.SetActive(false);
        _gems.SetActive(false);
        _energy.SetActive(false);

        switch (obj)
        {
            case EObjType.smallChest:
                _smallChest.SetActive(true);
                break;

            case EObjType.middleChest:
                _middleChest.SetActive(true);
                break;

            case EObjType.bigChest:
                _bigChest.SetActive(true);
                break;

            case EObjType.key:
                _key.SetActive(true);
                break;

            case EObjType.fuel:
                _fuel.SetActive(true);
                break;

            case EObjType.toolBox:
                _toolBox.SetActive(true);
                break;

            case EObjType.gems:
                _gems.SetActive(true);
                break;

            case EObjType.energy:
                _energy.SetActive(true);
                break;

        }

        _count.text = $"x{count}";
    }

    public enum EObjType
    { 
        smallChest, middleChest, bigChest, key, fuel, toolBox, gems, energy
    }




    public void SetTitle(string s)
    {
        _title.text = s;
    }

    public void SetLanguage(SystemLanguage language)
    {
        _okText.text = Words.GetWord(Word.ok, language);
    }
}
