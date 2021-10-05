using System;
using UnityEngine;

[RequireComponent(typeof(MonsterUI))]
public class Monster : Obj, Health.IDamageTakeable
{
    protected MonsterUI _monsterUI;


    [SerializeField]
    protected Animator _animator;


    [SerializeField]
    protected AudioClip takeDamageSfx;


    [SerializeField]
    protected float _damage;
    [SerializeField]
    protected float _coolDown;
    [SerializeField]
    protected float _speed;
    [SerializeField]
    protected float _visionRadius;

    [SerializeField]
    protected EMonsterType _monsterType;



    public Animator Animator => _animator;

    public float Damage => _damage;

    public float CoolDown => _coolDown;

    public float MoveSpeed => _speed;

    public float VisionRadius => _visionRadius;



    protected override void SetUpUI()
    {
        base.SetUpUI();
        _monsterUI = (MonsterUI)base._objUI;
    }

    public void SetUp(float health, int bumpDamage, int waterPrice, float damage, float coolDown, float speed, float visionRadius)
    {
        base.SetUp(health, bumpDamage, waterPrice);
        _damage = damage;
        _coolDown = coolDown;
        _speed = speed;
        _visionRadius = visionRadius;
    }


    public override void TakeDamage(float damage)
    {
        if (_health - damage <= 0f)
        {
            if (_monsterType == EMonsterType.monster)
            {
                Tasks.TasksHelper.Trigger(Tasks.ETaskPoint.kills, 1);
            }
            else if (_monsterType == EMonsterType.zombie)
            {
                Tasks.TasksHelper.Trigger(Tasks.ETaskPoint.kills, 1);
                Tasks.TasksHelper.Trigger(Tasks.ETaskPoint.kill_zombies, 1);
            }
            else throw new NotFiniteNumberException();
        }

        base.TakeDamage(damage);
    }



    private void Awake()
    {
        base.OnAwake();
    }


    private void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;

        Bump.IBumpable bumpable = null;
        Move.IBounce bounce = null;

        if (go.tag == "Player")
        {
            bumpable = go.GetComponent<Bump.IBumpable>();
            bounce = go.GetComponent<Move.IBounce>();
            ObjectsController.InstantiateAntity<Impact>(Resources.Load<Impact>("Impacts/Blood"),
                transform.position + Vector3.up * 2f);
        }

        if(bounce != null)
        {
            if (bumpable == null || _health > bumpable.BumpDamage || !_isDestructable)
                bounce.Rebound();
        }

        if (bumpable != null)
        {
            bumpable.Bump(_bumpDamage * _health / _maxHealth);
            TakeDamage(bumpable.BumpDamage);
        }
    }


    public enum EMonsterType
    {
        monster, zombie,
    }
}