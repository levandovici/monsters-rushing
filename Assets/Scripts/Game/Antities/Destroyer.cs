using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : Antity
{
    [SerializeField]
    private float _lifeTime = 0.3f;



    private void Awake()
    {
        OnAwake();
    }



    protected virtual void OnAwake()
    {
        StartCoroutine(DestroyMe(_lifeTime));
    }

    private IEnumerator DestroyMe(float after)
    {
        yield return new WaitForSeconds(after);
        ObjectsController.DestroyAntity(this);
    }
}