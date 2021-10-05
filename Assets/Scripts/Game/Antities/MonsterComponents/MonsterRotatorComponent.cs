using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRotatorComponent : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    [SerializeField]
    private Vector3 _degrees;
    [SerializeField]
    private float _speed;



    private void Update()
    {
        _target.Rotate(_degrees * _speed * Time.deltaTime);
    }
}