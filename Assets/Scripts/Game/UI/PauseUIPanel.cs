using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System;
using Vocabulary;

public class PauseUIPanel : UIPanel, IUITitled
{
    [SerializeField]
    private Text _title;

    [SerializeField]
    private Text _musicText;
    [SerializeField]
    private Text _sfxText;
    [SerializeField]
    private Text _quitText;


    [SerializeField]
    private Slider _musicVolume;
    [SerializeField]
    private Slider _sfxVolume;

    [SerializeField]
    private Button _back;
    [SerializeField]
    private Button _quit;



    public event Action<float> OnMusicVolumeChanged;
    public event Action<float> OnSfxVolumeChanged;

    public event Action OnBackClicked;
    public event Action OnQuitClicked;



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



    public void SetLanguage(SystemLanguage language)
    {
        _musicText.text = Words.GetWord(Word.music, language);
        _sfxText.text = Words.GetWord(Word.sfx, language);
        _quitText.text = Words.GetWord(Word.quit, language);
    }



    private void Start()
    {
        _sfxVolume.onValueChanged.AddListener((f) => OnSfxVolumeChanged.Invoke(f));
        _musicVolume.onValueChanged.AddListener((f) => OnMusicVolumeChanged.Invoke(f));

        _back.onClick.AddListener(() => OnBackClicked.Invoke());
        _quit.onClick.AddListener(() => OnQuitClicked.Invoke());
    }

    

    private void OnDestroy()
    {
        _sfxVolume.onValueChanged.RemoveAllListeners();
        _musicVolume.onValueChanged.RemoveAllListeners();

        _back.onClick.RemoveAllListeners();
        _quit.onClick.RemoveAllListeners();
    }
}