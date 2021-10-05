using UnityEngine.UI;
using UnityEngine;
using System;
using Vocabulary;

public class SettingsUIPanel : UIPanel, IUITitled
{
    [SerializeField]
    private Text _title;

    [SerializeField]
    private Slider _musicVolume;
    [SerializeField]
    private Text _musicVolumeText;
    [SerializeField]
    private Slider _sfxVolume;
    [SerializeField]
    private Text _sfxVolumeText;

    private SystemLanguage _language;

    [SerializeField]
    private Dropdown _changeLanguage;

    [SerializeField]
    private CreditsUIPanel _credits;
    [SerializeField]
    private Button _openCredits;
    [SerializeField]
    private Text _creditsText;

    [SerializeField]
    private Button _privacyPolicy;
    [SerializeField]
    private Text _privacyPolicyText;
    [SerializeField]
    private Button _googlePlay;



    public event Action<float> OnMusicVolumeChanged;
    public event Action<float> OnSfxVolumeChanged;

    public event Action<SystemLanguage> OnLanguageChanged;

   
    public event Action OnPrivacyPolicyClicked;
    public event Action OnGooglePlayClicked;



    public void SetTitle(string title)
    {
        _title.text = title;
    }


    public void SetSfxVolume(float value)
    {
        _sfxVolume.value = value;
    }

    public void SetMusicVolume(float value)
    {
        _musicVolume.value = value;
    }



    private void Start()
    {
        _musicVolume.onValueChanged.AddListener((f) => OnMusicVolumeChanged.Invoke(f));
        _sfxVolume.onValueChanged.AddListener((f) => OnSfxVolumeChanged.Invoke(f));
        _changeLanguage.onValueChanged.AddListener((i) => ChangeLang(i));
        _openCredits.onClick.AddListener(() => _credits.Show());

        _privacyPolicy.onClick.AddListener(() => OnPrivacyPolicyClicked.Invoke());
        _googlePlay.onClick.AddListener(() => OnGooglePlayClicked.Invoke());
    }



    private void OnDestroy()
    {
        _musicVolume.onValueChanged.RemoveAllListeners();
        _sfxVolume.onValueChanged.RemoveAllListeners();
        _changeLanguage.onValueChanged.RemoveAllListeners();
        _openCredits.onClick.RemoveAllListeners();

        _privacyPolicy.onClick.RemoveAllListeners();
        _googlePlay.onClick.RemoveAllListeners();
    }


    private void ChangeLang(int i)
    {
        SystemLanguage lang = Words.SupportedLanguages[i];
        OnLanguageChanged(lang);
    }

    private int GetLang(SystemLanguage language)
    {
        for(int i = 0; i < Words.SupportedLanguages.Length; i++)
        {
            if(Words.SupportedLanguages[i] == language)
            {
                return i;
            }
        }

        return 0;
    }



    public override void Hide()
    {
        base.Hide();
        _credits.Hide();
    }



    public void SetLanguage(SystemLanguage language)
    {
        _language = language;
        _musicVolumeText.text = Words.GetWord(Word.music, language);
        _sfxVolumeText.text = Words.GetWord(Word.sfx, language);

        _changeLanguage.value = GetLang(language);
        _creditsText.text = Words.GetWord(Word.credits, language);
        _privacyPolicyText.text = Words.GetWord(Word.privacy_policy, language);


        _credits.SetLnaguage(language);
    }
}