using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjUI : MonoBehaviour
{
    [SerializeField]
    protected Canvas _canvas;
    [SerializeField]
    protected Slider _healthBar;
    [SerializeField]
    protected Text _health;



    private void Awake()
    {
        _canvas = GetComponentInChildren<Canvas>(true);
        _healthBar =  _canvas.transform.Find("HealthBar").GetComponent<Slider>();
        _health = _canvas.transform.Find("Health").GetComponent<Text>();

        _canvas.worldCamera = Camera.main;
        _canvas.gameObject.SetActive(false);
    }

    private void Update()
    {
        _canvas.transform.forward = _canvas.transform.position - Camera.main.transform.position;
    }



    public virtual void SetHealth(float health, float maxHealth)
    {
        _canvas.gameObject.SetActive(health < maxHealth);
        _health.text = $"{health}";
        _healthBar.value = health / maxHealth;
    }
}