using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MonsterLookAtComponent)), RequireComponent(typeof(LineRenderer))]
public class MonsterInfernoComponent : MonoBehaviour
{
    private Monster _monster;
    private MonsterLookAtComponent _main;
    private LineRenderer _line;

    [SerializeField]
    private float _damage = 0f;



    private void Awake()
    {
        _monster = GetComponent<Monster>();
        _main = GetComponent<MonsterLookAtComponent>();
        _line = GetComponent<LineRenderer>();
        _line.enabled = false;
        _damage = 0f;
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
            _damage += time * _monster.Damage;

            target.GetComponent<Health.IDamageTakeable>().TakeDamage(_damage);
        }
        else
        {
            _damage = 0f;
            _line.enabled = false;
        }
    }
}