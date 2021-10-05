using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Target;
using static Health;

public class Bullet : Antity
{
    [SerializeField]
    protected ETarget _targetTypes;

    [SerializeField]
    protected float _damage = 10f;
    [SerializeField]
    protected float _speed = 30f;

    [SerializeField]
    protected BulletsImpact[] _bulletsImpacts;


    private float _startLifeTime;
    private bool _setuped = false;



    private float LifeTime => Time.time - _startLifeTime;



    private void Update()
    {
        if (LifeTime >= 5f && _setuped)
        {
            _setuped = false; 
           ObjectsController.DestroyAntity(this);
        }
    }

    void FixedUpdate()
    {
        Move();
    }



    private void OnTriggerEnter(Collider other)
    {
        string[] tags = Tags(_targetTypes);

        foreach(string s in tags)
        {
            if (other.gameObject.tag == s)
            {
                IDamageTakeable idt = other.gameObject.GetComponent<IDamageTakeable>();
                if (idt != null)
                {
                    idt.TakeDamage(_damage);

                    Vector3 pos = transform.position;
                    pos.y = (transform.position.y + other.transform.position.y) * 0.5f;
    
                    DestroingAnim(idt as Obj.IObjType, pos); 


                    _setuped = false;
                    ObjectsController.DestroyAntity(this);
                }

                Bump.IBumpable bumpable = other.gameObject.GetComponent<Bump.IBumpable>();
                if (bumpable != null)
                    bumpable.Bump(0f);

                break;
            }
        }
    }



    protected virtual void Move()
    {
        transform.Translate(Vector3.forward * _speed * Time.fixedDeltaTime, Space.Self);
    }



    public void SetUp(float damage)
    {
        _damage = damage;
        _startLifeTime = Time.time;
        _setuped = true;
    }



    private void DestroingAnim(Obj.IObjType objType, Vector3 pos)
    {
        BulletImpact prefab = null;

        foreach(BulletsImpact bi in _bulletsImpacts)
        {
            if((bi.types & Obj.EObjType.defaultObj) == (objType.Type & Obj.EObjType.defaultObj) ||
            (bi.types & Obj.EObjType.monster) == (objType.Type & Obj.EObjType.monster) ||
            (bi.types & Obj.EObjType.rock) == (objType.Type & Obj.EObjType.rock) ||
            (bi.types & Obj.EObjType.wood) == (objType.Type & Obj.EObjType.wood))
            {
                prefab = bi.bulletImpact;
                break;
            }
        }
        

        if(prefab != null)
            ObjectsController.InstantiateAntity(prefab, pos);
    }



    [System.Serializable]
    public struct BulletsImpact
    {
        public BulletImpact bulletImpact;
        public Obj.EObjType types;
    }
}