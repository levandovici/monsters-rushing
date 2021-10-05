using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixPosition : MonoBehaviour
{
    [SerializeField]
    private Vector3 _startLocalPosition;



    private void Awake()
    {
        _startLocalPosition = transform.localPosition;
    }

    private void Update() 
    {
        transform.localPosition = _startLocalPosition;
    }
}