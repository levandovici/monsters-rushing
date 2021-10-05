using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using static Health;

[RequireComponent(typeof(ObjUI))]
public class Obj : Antity, IDamageTakeable, IKillable, Obj.IObjType
{
    protected ObjUI _objUI;

    [SerializeField]
    protected float _maxHealth = 100f;
    [SerializeField]
    protected float _health = 0f;
    [SerializeField]
    protected int _bumpDamage = 20;
    [SerializeField]
    protected int _waterPrice = 100;
    [SerializeField]
    protected bool _isSpecial = false;

    [SerializeField]
    protected EObjType _type;
    [SerializeField]
    protected Impact _onDestroy;

    [SerializeField]
    protected bool _isDestructable = true;

    [SerializeField]
    private bool _BGLine1 = false;
    [SerializeField]
    private bool _BGLine2 = false;
    [SerializeField]
    private bool _BGLine3 = false;
    [SerializeField]
    private bool _BGLine4 = false;



    public bool BGLine1 => _BGLine1;
    public bool BGLine2 => _BGLine2;
    public bool BGLine3 => _BGLine3;
    public bool BGLine4 => _BGLine4;




    public EObjType Type
    {
        get => _type;
    }
    
    public float BumpDamage => _bumpDamage;

    public float Health => _health;

    public float MaxHealth => _maxHealth;



    private void Awake()
    {
        OnAwake();
    }

    protected virtual void OnAwake()
    {
        SetUpUI();
        _health = _maxHealth;
    }

    private void Start()
    {
        _objUI.SetHealth(_health, _maxHealth);
    }



    public void SetUp(float maxHealth, int bumpDamage, int waterPrice)
    {
        _health = _maxHealth = maxHealth;
        _bumpDamage = bumpDamage;
        _waterPrice = waterPrice;

        _objUI.SetHealth(_health, _maxHealth);
    }

    protected virtual void SetUpUI()
    {
        _objUI = GetComponent<ObjUI>();
    }

    
    public virtual void TakeDamage(float damage)
    {
       if (_isDestructable)
        {
            _health -= damage;
            
            Tasks.TasksHelper.Trigger(Tasks.ETaskPoint.damage, (int)damage);


            if (_health <= 0f)
            {
                MapController map = GameObject.FindGameObjectWithTag("MapController").GetComponent<MapController>();

                if (_isSpecial)
                    map.AddWater(0, _waterPrice);
                else
                    map.AddWater(_waterPrice, 0);

                ObjectsController.InstantiateAntity(_onDestroy, transform.position);
                ObjectsController.DestroyAntity((Antity)this);
                return;
            }

            _objUI.SetHealth(_health, _maxHealth);
        }
    }

    public void Kill()
    {
        ObjectsController.InstantiateAntity(_onDestroy, transform.position);
        ObjectsController.DestroyAntity((Antity)this);
    }

    public void Heal(float health)
    {
        _health = Mathf.Clamp(_health + health, _health, _maxHealth);
    }



    private void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;

        Bump.IBumpable bumpable = null;
        Move.IBounce bounce = null;

        if (go.tag == "Player" || go.tag == "Monster")
        {
            bumpable = go.GetComponent<Bump.IBumpable>();
            bounce = go.GetComponent<Move.IBounce>();
        }

        if(bounce != null)
        {
            if (bumpable == null || _health > bumpable.BumpDamage || !_isDestructable)
                bounce.Rebound();
        }

        if (bumpable != null)
        {
            bumpable.Bump(_bumpDamage);
            TakeDamage(bumpable.BumpDamage);
        }
    }



    public interface IObjType
    {
        EObjType Type {get;}
    }



    [System.Flags]
    public enum EObjType
    {
       defaultObj = 1, rock = 2, wood = 4, monster = 8,  metal = 16
    }
}