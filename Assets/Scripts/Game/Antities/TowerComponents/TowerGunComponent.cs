using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TowerLookAtComponent))]
public class TowerGunComponent : MonoBehaviour
{
    private Tower _tower;
    private TowerLookAtComponent _main;

    private float _lastGunTime = 0f;
    
    [SerializeField]
    private Bullet _bullet;
    [SerializeField]
    private Transform _pivot;



    private void Awake()
    {
        _tower = GetComponent<Tower>();
        _main = GetComponent<TowerLookAtComponent>();
    }

    private void Update()
    {
        Fire();
    }



    private void Fire()
    {
        if(Time.time >= _lastGunTime + _tower.CoolDown)
        {   
            Transform target = _main.Target;

            if(target != null)
            {
               Bullet b = ObjectsController.InstantiateAntity(_bullet, _pivot.position, _pivot.rotation);
               b.SetUp(_tower.Damage);
               
                _lastGunTime = Time.time;
            }
        }
    }
}