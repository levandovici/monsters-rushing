using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class NewLifeUIPanel : UIPanel, IUITitled
{
    [SerializeField]
    private Text _title;

    [SerializeField]
    private Text _price;
    [SerializeField]
    private Slider _timeBar;
    [SerializeField]
    private Button use;
    [SerializeField]
    private Button _quit;

    [SerializeField]
    private GameObject _fuel;
    [SerializeField]
    private GameObject _toolBox;

    private bool _toolBoxNoFuel = false;


    public event Action OnUseToolBox;
    public event Action OnUseFuel;
    public event Action OnTimeYield;



    public void SetUp(float time, bool toolBoxNoFuel)
    {
        _toolBoxNoFuel = toolBoxNoFuel;
        StopAllCoroutines();
        _price.text = 1.ToString();
        StartCoroutine(Timer(time));
        _fuel.SetActive(!toolBoxNoFuel);
        _toolBox.SetActive(toolBoxNoFuel);
    }



    private IEnumerator Timer(float time)
    {
        _timeBar.gameObject.SetActive(true);
        float timer = time;

        while (timer > 0f)
        {
            timer -= Time.deltaTime;
            _timeBar.value = timer / time;
            yield return null;
        }

        _timeBar.gameObject.SetActive(false);

        yield return null;

        OnTimeYield.Invoke();
    }



    public void SetTitle(string title)
    {
        _title.text = title;
    }



    private void Start()
    {
        use.onClick.AddListener(() =>
        {
            StopAllCoroutines();
            if (_toolBoxNoFuel)
            {
                OnUseToolBox.Invoke();
            }
            else
            {
                OnUseFuel.Invoke();
            }
        });
        _quit.onClick.AddListener(() =>
        {
            StopAllCoroutines();
            OnTimeYield.Invoke();
        });
    }



    private void OnDestroy()
    {
        use.onClick.RemoveAllListeners();
        _quit.onClick.RemoveAllListeners();
    }
}