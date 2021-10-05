using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MonsterLookAtComponent))]
public class MonsterGunComponent : MonoBehaviour
{
    private Monster _monster;
    private MonsterLookAtComponent _main;

    private float _lastGunTime = 0f;
    
    [SerializeField]
    private Bullet _bullet;
    [SerializeField]
    private Transform _pivot;



    private void Awake()
    {
        _monster = GetComponent<Monster>();
        _main = GetComponent<MonsterLookAtComponent>();
    }

    private void Update()
    {
        Fire();
    }



    private void Fire()
    {
        if(Time.time >= _lastGunTime + _monster.CoolDown)
        {   
            Transform target = _main.Target;

            if(target != null)
            {
                _monster.Animator.SetBool("move", false);
                _monster.Animator.SetBool("damage", true);
               Bullet b = ObjectsController.InstantiateAntity(_bullet, _pivot.position, _pivot.rotation);
               b.SetUp(_monster.Damage);
               
                _lastGunTime = Time.time;
            }
        }
        else
        {
            _monster.Animator.SetBool("move", true);
            _monster.Animator.SetBool("damage", false);
        }
    }
}