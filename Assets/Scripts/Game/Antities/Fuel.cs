using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : Obj
{
    private void Awake()
    {
        base.OnAwake();
    }

    private void Start()
    {
        _objUI.SetHealth(_health, _maxHealth);
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        if (_health <= 0f)
            GameObject.FindGameObjectWithTag("MapController").GetComponent<MapController>().Car.FillUp();
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;

        Bump.IBumpable bumpable = null;
        Move.IBounce bounce = null;

        if (go.tag == "Player")
        {
            bumpable = go.GetComponent<Bump.IBumpable>();
            bounce = go.GetComponent<Move.IBounce>();
        }

        if (go.tag == "Monster")
        {
            bumpable = go.GetComponent<Bump.IBumpable>();
            bounce = go.GetComponent<Move.IBounce>();
        }

        if (bounce != null)
        {
            if (bumpable == null || _health > bumpable.BumpDamage || !_isDestructable)
                bounce.Rebound();
        }

        if (bumpable != null)
        {
            bumpable.Bump(_bumpDamage);
            TakeDamage(bumpable.BumpDamage);
        }
    }
}
