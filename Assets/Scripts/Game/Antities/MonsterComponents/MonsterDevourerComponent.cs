using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MonsterMoveComponent)), RequireComponent(typeof(MonsterLinesComponent))]
public class MonsterDevourerComponent : MonoBehaviour
{
    private Monster _monster;
    private MonsterMoveComponent _main;
    private MonsterLinesComponent _lines;

    [SerializeField]
    private Obj _target;

    private float _lastDamageTime = 0f;
    private float _damageCounter = 0f;



    private void Awake()
    {
        _monster = GetComponent<Monster>();
        _main = GetComponent<MonsterMoveComponent>();
        _lines = GetComponent<MonsterLinesComponent>();
        _lines.DoNotRebound();
    }

    private void Update()
    {
        if(_target != null && !_target.gameObject.activeSelf)
            {
                _target = null;
                _main.Move = true;
                _monster.Animator.SetBool("damage", false);
            }
    } 



    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obj")
        {
            _main.Move = false;
            _monster.Animator.SetBool("damage", true);
            _lines.DoNotRebound();
        }
        else if(other.tag == "Monster")
        {
            _lines.Rebound();

            MonsterLinesComponent component = other.GetComponent<MonsterLinesComponent>();
            if(component != null)
                component.DoNotRebound();
        }
        else if(other.tag == "Tower")
        {
            _lines.Rebound();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Obj")
        {
            _target = other.GetComponent<Obj>();

            _main.Move = false;
            _monster.Animator.SetBool("damage", true);
            
            if(_lastDamageTime + _monster.CoolDown <= Time.time)
            {
                _lastDamageTime = Time.time;
                Obj obj = other.GetComponent<Obj>();
                obj.TakeDamage(_monster.Damage);
                
                if(obj.Health <= 0f)
                {
                    _main.Move = true;
                    _monster.Animator.SetBool("damage", false);
                }

                _damageCounter += _monster.Damage;

                if(_monster.Health < _monster.MaxHealth)
                {
                        float need = _monster.MaxHealth - _monster.Health;
                        float heal = 0f;
                        while(_damageCounter > 0 && heal < need)
                        {
                            _damageCounter--;
                            heal++;
                        }
                        _monster.Heal(heal);
                }

                if(_damageCounter >= _monster.MaxHealth)
                {
                    _damageCounter -= _monster.MaxHealth;
                    ObjectsController.CloneAntity(_monster);
                }
            }
        }
        else if(other.tag == "Monster")
        {
            _lines.Rebound();

            MonsterLinesComponent component = other.GetComponent<MonsterLinesComponent>();
            if(component != null)
                component.DoNotRebound();
        }
        else if(other.tag == "Tower")
        {
            _lines.Rebound();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Obj")
        {
            _main.Move = true;
            _monster.Animator.SetBool("damage", false);
        }
    }
}