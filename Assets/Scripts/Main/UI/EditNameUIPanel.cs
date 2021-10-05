using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vocabulary;

public class EditNameUIPanel : UIPanel
{
    [SerializeField]
    private Text _title;

    [SerializeField]
    private InputField _name;
    [SerializeField]
    private Button _ok;
    [SerializeField]
    private Text _okText;
    [SerializeField]
    private GameObject _payPanel;
    [SerializeField]
    private Button _pay;
    [SerializeField]
    private Text _payText;
    [SerializeField]
    private Text _priceText;
    private int _price;

    [SerializeField]
    private Button _close;



    private SystemLanguage _language;



    public event Action<string> OnNameChanged;
    public event Action<int> OnPayment;
    public event Func<int, bool> CanPay;
    public event Func<string> OldName;



    public void SetLanguage(SystemLanguage language)
    {
        _language = language;
        _payText.text = Words.GetWord(Word.pay, _language);
        _okText.text = Words.GetWord(Word.ok, _language);
    }


    public void Show(bool newName, int price)
    {
        base.Show();

        _title.text = Words.GetWord(
            newName ? Word.enter_new_name : Word.enter_your_name, _language);

        _ok.gameObject.SetActive(!newName);
        _payPanel.SetActive(newName);
        _priceText.text = (_price = price).ToString();
    }

    public override void Show()
    {
        Show(false, 0);
    }



    private void Awake()
    {
        _ok.onClick.AddListener(() =>
        {
            ChangeName();
        });

        _pay.onClick.AddListener(() =>
        {
            if (CanPay(_price))
            {
                OnPayment(_price);
                ChangeName();
            }
        });

        _close.onClick.AddListener(() => Hide());
    }

    private void Update()
    {
        _name.text = _name.text.Replace(" ", "");
        _ok.interactable = ValidName(_name.text);
        _pay.interactable = ValidName(_name.text) && CanPay(_price);

        Debug.Log(_name.text);
    }

    private void OnDestroy()
    {
        _ok.onClick.RemoveAllListeners();
        _pay.onClick.RemoveAllListeners();
        _close.onClick.RemoveAllListeners();
    }


    private bool ValidName(string name)
    {
        if (name.Length >= 3)
        {
            return true;
        }

        return false;
    }

    private void ChangeName()
    {
        string name = _name.text;
        if (ValidName(name) && !name.Equals(OldName.Invoke()))
            OnNameChanged.Invoke(name);
    }
}