using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using static Health;
using UnityEngine;
using System;

public class Car : MonoBehaviour, Bump.IBumpable, Move.IBounce, IDamageTakeable, IKillable, Obj.IObjType
{
    [SerializeField]
    private Gun _gun;

    [SerializeField]
    private Axle[] _axles = new Axle[2];
    [SerializeField]
    private float _moveSpeed = 0f;
    [SerializeField]
    private float _health = 100f;
    [SerializeField]
    private float _maxHealth = 100f;

    [SerializeField]
    private float _fuel = 0f;
    [SerializeField]
    private float _maxFuel = 100f;

    private int _road = 0;

    private bool _brake = false;
    private Move.ELineInfo _lineInfo = Move.ELineInfo.stay;

    private bool _doNotRebound = false;

    [SerializeField]
    private Transform _smokeAnim;

    private bool _gameOver;



    public event Action OnGameOver;



    public Obj.EObjType Type => Obj.EObjType.defaultObj;
    

    public Gun Gun => _gun;

    public float MoveSpeed => _moveSpeed;

    public int Distance => (int)transform.position.z;

    public float Health => _health;

    public float Fuel => _fuel;

    public float MaxFuel => _maxFuel;

    public float MaxHealth => _maxHealth;

    public int Bullets => _gun.Bullets;

    public int MaxBullets => _gun.MaxBullets;

    public float Reload01 => _gun.Reload01;

    public bool Brake
    {
        set => _brake = value;
    }

    public float BumpDamage => _maxHealth * 0.1f;



    public void Kill()
    {
        TakeDamage(_maxHealth);
    }

    public void Alive()
    {
        _health = _maxHealth;
        _smokeAnim.gameObject.SetActive(false);
        _gun.Reload();
        _gameOver = false;
    }

    public void FillUp()
    {
         _fuel = MaxFuel;

        _smokeAnim.gameObject.SetActive(false);
        _gun.Reload();
        _gameOver = false;
    }

    public void Bump(float damage)
    {
        if (_gameOver)
            return;

        TakeDamage(damage);
        _gun.Cam.StartShake();
    }

    public void TakeDamage(float damage)
    {
        if (_gameOver)
            return;

        _health -= damage;
        if (_health <= 0f)
        {
            _health = 0f;
            _smokeAnim.gameObject.SetActive(true);
            OnGameOver.Invoke();
            _gameOver = true;
        }
    }

    private void UseFuel(float fuel)
    {
        if (_gameOver)
            return;

        _fuel -= fuel;
        if (_fuel <= 0f)
        {
            _fuel = 0f;
            _smokeAnim.gameObject.SetActive(true);
            OnGameOver.Invoke();
            _gameOver = true;
        }
    }

    public void SetUp(float maxHealth, float damage, int capacity, float maxFuel)
    {
        _health = _maxHealth = maxHealth;
        _fuel = _maxFuel = maxFuel;
        _smokeAnim.gameObject.SetActive(false);

        _gun.SetUp(damage, capacity);
    }

    public void SetMoveSpeed(float moveSpeed)
    {
        _moveSpeed = moveSpeed;
    }



    private IEnumerator ChangeLine()
    {
        Vector3 velocity = Vector3.zero;


        while (Vector3.Distance(transform.position, new Vector3(_road * Move.CellSize, transform.position.y, transform.position.z)) > 0.1f)
        {
            Vector3 to = new Vector3(_road * Move.CellSize, transform.position.y, transform.position.z);

            if(!_brake)
            transform.position =
                Vector3.SmoothDamp(transform.position, to, ref velocity, Time.smoothDeltaTime, _moveSpeed * 2f);
            else
                transform.position =
                Vector3.SmoothDamp(transform.position, to, ref velocity, Time.smoothDeltaTime, _moveSpeed * 0.8f);

            yield return null;
        }


        transform.position = new Vector3(_road * Move.CellSize, transform.position.y, transform.position.z);
        _lineInfo = Move.ELineInfo.stay;
    }

    public void ChangeLineLeft(bool isController)
    {
        if (CanChangeLeft() && (!isController ||
            _lineInfo == Move.ELineInfo.stay || _lineInfo == Move.ELineInfo.toLeft))
        {
            _road--;
            _lineInfo = Move.ELineInfo.toLeft;
            StopAllCoroutines();
            StartCoroutine(ChangeLine());
        }
    }

    public void ChangeLineRight(bool isController)
    {
        if (CanChangeRight() && (!isController ||
            _lineInfo == Move.ELineInfo.stay || _lineInfo == Move.ELineInfo.toRight))
        {
            _road++;
            _lineInfo = Move.ELineInfo.toRight;
            StopAllCoroutines();
            StartCoroutine(ChangeLine());
        }
    }


    private bool CanChangeLeft()
    {
        return _road > Move.FirstLineID;
    }
    private bool CanChangeRight()
    {
        return _road < Move.LastLineID;
    }



    public void Rebound()
    {
        if (_gameOver)
            return;

        if(!_doNotRebound)
        {
        if (_lineInfo == Move.ELineInfo.toLeft)
        {
            ChangeLineRight(false);
        }
        else if (_lineInfo == Move.ELineInfo.toRight)
        {
            ChangeLineLeft(false);
        }
        else
        {
            int b = UnityEngine.Random.Range(0, 2);

            if (b == 0)
            {
                if (CanChangeLeft())
                {
                    ChangeLineLeft(false);
                }
                else
                {
                    ChangeLineRight(false);
                }
            }
            else
            {
                if (CanChangeRight())
                {
                    ChangeLineRight(false);
                }
                else
                {
                    ChangeLineLeft(false);
                }
            }
        }
        }
        else _doNotRebound = false;
    }

    public void DoNotRebound()
    {
        _doNotRebound = true;
    }



    private void Update()
    {
        if (!_gameOver)
        {
            float moveSpeed = _brake ? _moveSpeed * 0.4f : _moveSpeed;

            for (int i = 0; i < _axles.Length; i++)
            {
                _axles[i].leftWheel.transform.Rotate(new Vector3(45f * moveSpeed, 0f, 0f) * Time.deltaTime);
                _axles[i].rightWheel.transform.Rotate(new Vector3(45f * moveSpeed, 0f, 0f) * Time.deltaTime);
            }
        }


#if UNITY_EDITOR
        if (!_gameOver)
        {
            if (Input.GetKey(KeyCode.Space))
                _gun.OneShoot();

            if (Input.GetKeyDown(KeyCode.A))
            {
                ChangeLineLeft(true);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                ChangeLineRight(true);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                Brake = true;
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                Brake = false;
            }
        }
#endif


        if(transform.position.y < -10f)
            Kill();

        UseFuel(Time.deltaTime * _moveSpeed);
    }

    private void FixedUpdate()
    {
        if (!_gameOver)
        {
            if (!_brake)
            {
                transform.position = Vector3.MoveTowards(transform.position,
                    transform.position + new Vector3(0f, 0f, 1f), _moveSpeed * Time.fixedDeltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position,
                    transform.position + new Vector3(0f, 0f, 1f), _moveSpeed * 0.4f * Time.fixedDeltaTime);
            }
        }
    }
}

[System.Serializable]
public class Axle
{
    [SerializeField]
    private Transform _leftWheel;
    [SerializeField]
    private Transform _rightWheel;
    [SerializeField]
    private bool _steering;



    public Transform leftWheel
    {
        get { return _leftWheel; }
    }

    public Transform rightWheel
    {
        get { return _rightWheel; }
    }


    public bool steering
    {
        get { return _steering; }
    }
}