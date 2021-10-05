using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vocabulary;

public class SwitchAccountUIPanel : UIPanel, IUITitled
{
    [SerializeField]
    private Text _title;

    [SerializeField]
    private Text _diskText;
    [SerializeField]
    private Text _diskBestDistanceText;
    [SerializeField]
    private Text _diskBestDistance;
    [SerializeField]
    private Text _diskLastVisitText;
    [SerializeField]
    private Text _diskLastVisit;
    [SerializeField]
    private Text _diskCarsText;
    [SerializeField]
    private Text _diskCars;
    [SerializeField]
    private Button _diskSelect;
    [SerializeField]
    private Text _diskSelectText;

    [SerializeField]
    private Text _cloudText;
    [SerializeField]
    private Text _cloudBestDistanceText;
    [SerializeField]
    private Text _cloudBestDistance;
    [SerializeField]
    private Text _cloudLastVisitText;
    [SerializeField]
    private Text _cloudLastVisit;
    [SerializeField]
    private Text _cloudCarsText;
    [SerializeField]
    private Text _cloudCars;
    [SerializeField]
    private Button _cloudSelect;
    [SerializeField]
    private Text _cloudSelectText;



    public event Action OnSelectDiskClicked;
    public event Action OnSelectCloudClicked;



    public void SetTitle(string title)
    {
        _title.text = title;
    }

    public void SetLanguage(SystemLanguage language)
    {
        SetTitle(Words.GetWord(Word.switch_account, language));

        _diskText.text = Words.GetWord(Word.disk, language);
        _cloudText.text = Words.GetWord(Word.cloud, language);

        _diskBestDistanceText.text = _cloudBestDistanceText.text =
            Words.GetWord(Word.best_distance, language);

        _cloudLastVisitText.text = _diskLastVisitText.text =
            Words.GetWord(Word.last_visit, language);

        _diskCarsText.text = _cloudCarsText.text =
            Words.GetWord(Word.cars, language);

        _diskSelectText.text = _cloudSelectText.text =
            Words.GetWord(Word.select, language);
    }

    public void SetUp(PlayerData disk, PlayerData cloud)
    {
        _diskBestDistance.text = disk.bestScore.ToString();
        _diskLastVisit.text = new DateTime(disk.lastNetworkTime).ToString("MM/dd/yy H:mm");
        _diskCars.text = $"{disk.UnlockedCars} / {disk.Cars}";

        _cloudBestDistance.text = cloud.bestScore.ToString();
        _cloudLastVisit.text = new DateTime(cloud.lastNetworkTime).ToString("MM/dd/yy H:mm");
        _cloudCars.text = $"{cloud.UnlockedCars} / {cloud.Cars}";
    }



    private void Awake()
    {
        _diskSelect.onClick.AddListener(() => OnSelectDiskClicked.Invoke());
        _cloudSelect.onClick.AddListener(() => OnSelectCloudClicked.Invoke());
    }

    private void OnDestroy()
    {
        _diskSelect.onClick.RemoveAllListeners();
        _cloudSelect.onClick.RemoveAllListeners();
    }
}