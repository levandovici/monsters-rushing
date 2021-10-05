using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Target;

[RequireComponent(typeof(Monster))]
public class MonsterTargetComponent : MonoBehaviour
{
    private Monster _main;

    [SerializeField]
    private Transform _target = null;

    [SerializeField]
    private EFindTarget _findTargetType = EFindTarget.Forward;
    [SerializeField]
    private ETarget _targetTypes = ETarget.Player;



    public Transform Target => _target;

    public EFindTarget FindTargetType => _findTargetType;

    public Target.ETarget TargetTypes => _targetTypes;



    private void Awake()
    {
        _main = GetComponent<Monster>();
    }

    private void Update()
    {
            if(_target == null)
            {
                FindTarget();
            }
            else
            {
                CheckTarget();
            }
    }



    private void FindTarget()
    {
       float radius = _main.VisionRadius;

        GameObject[] arr = Targets(TargetTypes);
        

        float dist = radius;

        foreach(GameObject g in arr)
        {
            if(g.transform.position.z < transform.position.z)
            {
                float distance = Vector3.Distance(g.transform.position, transform.position);
                if(distance <= dist)
                {
                    if(_findTargetType == EFindTarget.Forward && transform.position.x != g.transform.position.x)
                    continue;

                    dist = distance;
                    _target = g.transform;
                }
            }
        }
    }

    private void CheckTarget()
    {
        if(Vector3.Distance(_target.position, transform.position) > _main.VisionRadius)
        {
            _target = null;
        }
        else if(_findTargetType == EFindTarget.Forward)
        {
            if(_target.transform.position.x != transform.position.x)
            {
                _target = null;
            }
        }
    }



    private void OnDrawGizmos()
    {
        _main = GetComponent<Monster>();    

        if(FindTargetType == EFindTarget.Radius)
        DrawCircle(DrawCircle(_main.VisionRadius, 36, 0.6f));

        if(FindTargetType == EFindTarget.Forward)
            DrawLine(new Vector3(transform.position.x, 0.6f, transform.position.z), 
            new Vector3(transform.position.x, 0.6f, transform.position.z - _main.VisionRadius));
    }


    private void DrawLine(Vector3 at, Vector3 to)
    {
        Gizmos.matrix = this.transform.localToWorldMatrix;
        Gizmos.DrawLine(at, to);
    }


    private void DrawCircle(Vector3[] arr)
    {
        Gizmos.matrix = this.transform.localToWorldMatrix;

        for (int i = 0; i < arr.Length -1; ++i)
            Gizmos.DrawLine(arr[i], arr[i + 1]);
        Gizmos.DrawLine(arr[arr.Length - 1], arr[0]);
    }
    
    private Vector3[] DrawCircle(float radius, int steps, float height)
    {
        float angle = (Mathf.PI * 2f) / steps;
        var arr = new Vector3[steps];

        for (int i = 0; i < steps; i++)
        {
            float currAngle = i * angle;
            float x = Mathf.Sin(currAngle) * radius;
            float y = Mathf.Cos(currAngle) * radius;

            Vector3 nextPos = new Vector3(x, height, y);
            arr[i] = nextPos;
        }
        return arr;

    }
}