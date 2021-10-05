using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using System;

[RequireComponent(typeof(Button))]
public class ButtonDLL : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    public event Action onPointerDown;
    public event Action onPointerUpORExit;

    private Button _button;



    private void Awake()
    {
        _button = GetComponent<Button>();
    }



    public void OnPointerDown(PointerEventData eventData)
    {
        onPointerDown.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        onPointerUpORExit.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        onPointerUpORExit.Invoke();
    }
}