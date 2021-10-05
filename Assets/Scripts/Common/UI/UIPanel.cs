using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel : MonoBehaviour, IUIPanel
{
    public virtual void Show()
    {
        SetActiv(true);
    }

    public virtual void Hide()
    {
        SetActiv(false);
    }

    private void SetActiv(bool activ)
    {
        gameObject.SetActive(activ);
    }
}