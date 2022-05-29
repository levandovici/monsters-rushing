using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using Vocabulary;

public class GameUIPanel : UIPanel
{
    [SerializeField]
    private Text _brakeText;
    [SerializeField]
    private Text _fireText;

    [SerializeField]
    private Slider _bestScore;
    [SerializeField]
    private GameObject _trophey;
    [SerializeField]
    private Text _distance;

    [SerializeField]
    private Slider _healthBar;
    [SerializeField]
    private Text _health;

    [SerializeField]
    private Image _fuel;

    [SerializeField]
    private Button _pause;

    [SerializeField]
    private ButtonDLL _shoot;
    private Button _shootButton;
    [SerializeField]
    private ButtonDLL _brake;
    [SerializeField]
    private Button _leftLine;
    [SerializeField]
    private Button _rightLine;

    [SerializeField]
    private Slider _reloadBar;
    [SerializeField]
    private Text _bullets;

    [SerializeField]
    private GameObject _addWaterPanel;
    [SerializeField]
    private Text _addWater;

    private int _waterCount = 0;
    private float _counter = 0;



    private SystemLanguage _language;



    public event Action OnPauseClicked;

    public event Action OnShootPointerDown;
    public event Action OnShootPointerUp;
    public event Action OnBrakePointerDown;
    public event Action OnBrakePointerUp;
    public event Action OnLeftLineClicked;
    public event Action OnRightLineClicked;



    public void SetDistance(int distance, int bestScore)
    {
        float v = (float)distance / (float)bestScore;
        v = Mathf.Clamp(v, 0, 1);

        _bestScore.value = v;

        _trophey.SetActive(v == 1f);

        _distance.text = distance.ToString();
    }

    public void SetHealth(float health, float maxHealth)
    {
        float v = health / maxHealth;

        _healthBar.value = v;

        _health.text = $"{(int)health}/{(int)maxHealth}";
    }

    public void SetFuel(float health, float maxHealth)
    {
        float v = health / maxHealth;

        _fuel.fillAmount = v;
    }

    public void SetBullets(int count, int max, float reloadValue)
    {
        _shootButton.interactable = reloadValue == 1f;

        _bullets.text = $"{count}/{max}";

        _reloadBar.value = 1f - reloadValue;
        _reloadBar.gameObject.SetActive(reloadValue < 1f);
    }

    public void SetAddWater(int water)
    {
        bool b = water > 0;

        _addWaterPanel.SetActive(b);
        
        if(b)
        {
            StopAllCoroutines();
            _waterCount += water;
            StartCoroutine(AddWaterAnim(_waterCount));
        }
    }



    private IEnumerator AddWaterAnim(int water)
    {
        if (_counter >= water)
            _counter = 0f;

        while(_counter < water)
        {
            _counter += water * Time.deltaTime;
            _addWater.text = $"{(int)_counter}";

            yield return null;
        }

        _addWater.text = $"+{water}";
        _waterCount = 0;
        _counter = 0f;

        yield return new WaitForSeconds(1f);

        _addWaterPanel.SetActive(false);
    }



    public void SetLanguage(SystemLanguage language)
    {
        _language = language;
        _brakeText.text = Words.GetWord(Word.brake, language);
        _fireText.text = Words.GetWord(Word.fire, language);
    }



    public override void Show()
    {
        base.Show();
        _addWaterPanel.SetActive(false);
    }

    public override void Hide()
    {
        base.Hide();
    }



    private void Start()
    {
        _shootButton = _shoot.GetComponent<Button>();

        _pause.onClick.AddListener(() => OnPauseClicked.Invoke());
        _shoot.onPointerDown += OnShootPointerDown;
        _shoot.onPointerUpORExit += OnShootPointerUp;
        _brake.onPointerDown += OnBrakePointerDown;
        _brake.onPointerUpORExit += OnBrakePointerUp;
        _leftLine.onClick.AddListener(() => OnLeftLineClicked.Invoke());
        _rightLine.onClick.AddListener(() => OnRightLineClicked.Invoke());
    }



    private void OnDestroy()
    {
        _pause.onClick.RemoveAllListeners();
        _shoot.onPointerDown -= OnShootPointerDown;
        _shoot.onPointerUpORExit -= OnShootPointerUp;
        _brake.onPointerDown -= OnBrakePointerDown;
        _brake.onPointerUpORExit -= OnBrakePointerUp;
        _leftLine.onClick.RemoveAllListeners();
        _rightLine.onClick.RemoveAllListeners();
    }
}