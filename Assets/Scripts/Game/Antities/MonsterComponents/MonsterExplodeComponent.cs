using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MonsterMoveComponent)), RequireComponent(typeof(MonsterLinesComponent))]
public class MonsterExplodeComponent : MonoBehaviour
{
    private Monster _monster;
    private MonsterMoveComponent _main;
    private MonsterLinesComponent _lines;



    private void Awake()
    {
        _monster = GetComponent<Monster>();
        _main = GetComponent<MonsterMoveComponent>();
        _lines = GetComponent<MonsterLinesComponent>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _monster.Kill();
        }
    }
}