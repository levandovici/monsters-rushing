using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MonsterMoveComponent)), RequireComponent(typeof(MonsterTargetComponent))]
public class MonsterMoverComponent : MonoBehaviour
{
    private Monster _monster;
    private MonsterTargetComponent _main;
    private float _lastAttackTime = 0f;
    [SerializeField]
    private LineRenderer _laser;

    [SerializeField]
    private float _moveObjSpeed = 8f;

    private Transform _target = null;



    private void Awake()
    {
        _monster = GetComponent<Monster>();
        _main = GetComponent<MonsterTargetComponent>();
        _laser = GetComponent<LineRenderer>();
        _laser.enabled = false;
    }

    private void Update()
    {
        if(_main.Target != null)
        if(Time.time >= _lastAttackTime + _monster.CoolDown && _target == null)
        {
            GameObject[] arr = GameObject.FindGameObjectsWithTag("Obj");
            
            List<GameObject> list = new List<GameObject>();
            List<GameObject> free =  new List<GameObject>();

            foreach(GameObject go in arr)
            {
                if(go.transform.position.z > _main.Target.position.z)
                {
                    list.Add(go);
                }
                
                if(Mathf.Abs(go.transform.position.z - transform.position.z) <= _monster.VisionRadius / 5f)
                {
                    free.Add(go);
                }
            }
        
            if(free.Count > 0)
            {
                float z = UnityEngine.Random.Range(_main.Target.position.z + 2 * Move.CellSize,
                transform.position.z - 2 * Move.CellSize);

                    float posX = 
                        GameObject.FindGameObjectWithTag("MapController").GetComponent<MapController>().Car.transform.position.x;

                bool isFree = true;

                foreach(GameObject go in list)
                {
                    if(go.transform.position.x == posX && go.transform.position.z == z)
                    {
                        isFree = false;
                        break;
                    }
                }

                    if (isFree)
                    {
                        StartCoroutine(Mover(free[UnityEngine.Random.Range(0, free.Count)].transform,
                            new Vector3(posX, 0f, z), _moveObjSpeed));
                    }
            }
        }
    }


    private void OnDisable()
    {
        StopAllCoroutines(); 
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obj")
        {
            GameObject[] arr = GameObject.FindGameObjectsWithTag("Obj");

            List<GameObject> nearest = new List<GameObject>();

            foreach(GameObject go in arr)
            {
                if(Mathf.Abs(go.transform.position.z - transform.position.z) <= 7.5f)
                {
                    nearest.Add(go);
                }
            }
        
            float x = 0f, z = 0f;

            int count = 16;
            while(count > 0)
            {
                count--;
                bool isFree = true;

                x = UnityEngine.Random.Range(Move.FirstLineID, Move.LastLineID + 1) * Move.CellSize;
                z = UnityEngine.Random.Range(-1, 2) * Move.CellSize;

                foreach(GameObject go in nearest)
                {
                    if(go.transform.position.x == x && go.transform.position.z == z)
                    {
                        isFree = false;
                        break;
                    }
                }

                if(isFree)
                    break;
            }

            StartCoroutine(Mover(other.transform, new Vector3(x, 0f, transform.position.z + z), _moveObjSpeed));
        }
    }



    private IEnumerator Mover(Transform target, Vector3 to, float speed)
    {
        if(target != null && _target == null)
        {
            _target = target;

            while(target != null && Vector3.Distance(target.position, to) > 0.1f)
            {
                target.transform.position = Vector3.MoveTowards(target.position, to, speed * Time.deltaTime);
                _laser.enabled = true;
                _laser.SetPosition(0, transform.position + Vector3.up * 2f);
                _laser.SetPosition(1, target.transform.position);

                yield return null;
            }

            if(target != null)
            target.transform.position = to;
            _target = null;
            _laser.enabled = false;
        }
    }
}