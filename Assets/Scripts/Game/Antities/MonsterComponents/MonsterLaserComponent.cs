using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MonsterLookAtComponent)), RequireComponent(typeof(LineRenderer))]
public class MonsterLaserComponent : MonoBehaviour
{
    private Monster _monster;
    private MonsterLookAtComponent _main;
    private LineRenderer _line;



    private void Awake()
    {
        _monster = GetComponent<Monster>();
        _main = GetComponent<MonsterLookAtComponent>();
        _line = GetComponent<LineRenderer>();
        _line.enabled = false;
    }

    private void Update()
    {
        Fire(Time.deltaTime);
    }



    private void Fire(float time)
    {
        Transform target = _main.Target;


        if(target != null)
        {
            _line.enabled = true;
            _line.SetPosition(0, _main.Head.position);
            _line.SetPosition(1, _main.Target.position);
             target.GetComponent<Health.IDamageTakeable>().TakeDamage(_monster.Damage * time);
        }
        else
        {
            _line.enabled = false;
        }
    }
}
