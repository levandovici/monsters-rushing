using UnityEngine;

[RequireComponent(typeof(TowerUI))]
public class Tower : Obj, Health.IDamageTakeable
{
    protected TowerUI _towerUI;



    [SerializeField]
    protected float _damage;
    [SerializeField]
    protected float _coolDown;
    [SerializeField]
    protected float _visionRadius;



    public float Damage => _damage;

    public float CoolDown => _coolDown;

    public float VisionRadius => _visionRadius;



    protected override void SetUpUI()
    {
        base.SetUpUI();
        _towerUI = (TowerUI)base._objUI;
    }

    public void SetUp(float health, int bumpDamage, int waterPrice, float damage, float coolDown, float visionRadius)
    {
        base.SetUp(health, bumpDamage, waterPrice);
        _damage = damage;
        _coolDown = coolDown;
        _visionRadius = visionRadius;
    }


    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
    }



    private void Awake()
    {
        base.OnAwake();
    }
}