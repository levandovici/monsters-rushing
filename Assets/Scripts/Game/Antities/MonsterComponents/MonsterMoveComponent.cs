using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Monster))]
public class MonsterMoveComponent : MonoBehaviour
{
    private Monster _main;
    [SerializeField]
    private bool _move = true;



    public bool Move 
    {
        get => _move;
        set 
        {
            _main.Animator.SetBool("move", value);
            _move = value;
        }
    }



    private void Awake()
    {
        _main = GetComponent<Monster>();
    }

    private void Start()
    {
        _move = true;
        _main.Animator.SetBool("move", true);
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(_move)
        transform.position = Vector3.MoveTowards(transform.position,
            transform.position + Vector3.back, _main.MoveSpeed * Time.fixedDeltaTime);
    }
}