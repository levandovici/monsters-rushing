using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TowerTargetComponent))]
public class TowerLookAtComponent : MonoBehaviour
{
    private TowerTargetComponent _main;

    [SerializeField]
    private Transform _head;



    public Transform Target => _main.Target;

    public Transform Head => _head;



    private void Awake()
    {
        _main = GetComponent<TowerTargetComponent>();
    }

    private void Update()
    {
        if(_head != null)
        LookAtTarget();
    }



    private void LookAtTarget()
    {
        Transform target = _main.Target;

        if(target != null)
        {
            _head.LookAt(target);
        }
    }
}