using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private Bullet _bulletPrefab;
    [SerializeField]
    private Transform[] _bulletPivot;
    private int _id = 0;
    private int _shellID = 0;
    [SerializeField]
    private EShoot _eShoot = EShoot.stack;
    [SerializeField]
    private int _magMaxCapacity = 3;
    [SerializeField]
    private float _magReloadTime = 2f;
    [SerializeField]
    private float _gunTime = 1f;
    private int _magCapacity = 0;
    private float _lastGunTime = 0f;
    [SerializeField]
    private float _damage = 0;
    private bool _reload = false;
    private bool _shoot = false;

    [SerializeField]
    private GameObject[] _fire;
    [SerializeField]
    private GameObject[] _shell;

    [SerializeField]
    private AudioSource _source;
    [SerializeField]
    private AudioClip _gun;
    [SerializeField]
    private AudioClip _noneBullets;
    [SerializeField]
    private AudioClip _relaoded;

    [SerializeField]
    private CameraShake _cam;



    public CameraShake Cam => _cam;

    public int Bullets => _magCapacity;

    public int MaxBullets => _magMaxCapacity;

    public float Reload01 => _reload ? Mathf.Clamp01((Time.time - _lastGunTime) / _magReloadTime) : _magCapacity >= 0 ? 1f : 0f;



    public void OneShoot()
    {
        if (!_reload && _magCapacity > 0 && Time.time >= _lastGunTime + _gunTime)
        {
            _lastGunTime = Time.time;

            if (_eShoot == EShoot.all)
            {
                _magCapacity -= _bulletPivot.Length;

                for (int i = 0; i < _bulletPivot.Length; i++)
                {
                    Bullet b = ObjectsController.InstantiateAntity(_bulletPrefab, _bulletPivot[i].position, _bulletPivot[i].rotation) as Bullet;
                    b.SetUp(_damage);
                }
            }
            else
            {
                _magCapacity--;

                _id++;
                _shellID++;
                if (_id < 0 || _id >= _bulletPivot.Length)
                {
                    _id = 0;
                }
                if (_shellID < 0 || _shellID >= _shell.Length)
                {
                    _shellID = 0;
                }

                Bullet b = ObjectsController.InstantiateAntity(_bulletPrefab, _bulletPivot[_id].position, _bulletPivot[_id].rotation) as Bullet;
                b.SetUp(_damage);
            }

            if (_magCapacity == 0)
            {
                _source.Stop();
                _source.PlayOneShot(_noneBullets);
                Reload();
            }


            if(_eShoot == EShoot.all)
            StopAllCoroutines();
            StartCoroutine(ShootAnim(_id, _shellID));
        }
    }

    public void Shoot(bool shoot)
    {
        _shoot = shoot;

      // if (!shoot)
         //   Reload();
    }


    public void Reload()
    {
        _reload = true;
    }



    public void SetUp(float damage, int maxBullets)
    {
        _damage = damage;
        _magMaxCapacity = maxBullets;
        _magCapacity = 0;
    }



    private void Awake()
    {
        _lastGunTime = -_magReloadTime;
        _reload = true;
        _source.volume = SoundController.SFXVolume;
        SoundController.OnSFXVolumeChanged += (f) => _source.volume = f;
    }


    private void Update()
    {
        if (_reload && Time.time >= _lastGunTime + _magReloadTime)
        {
            _source.PlayOneShot(_relaoded);
            _magCapacity = _magMaxCapacity;
            _reload = false;
        }

        if (_shoot)
            OneShoot();

        LookAtNearestEnimy();
    }

    private void LookAtNearestEnimy()
    {
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");

        int target = -1;

        float distance = Mathf.Infinity;

        for(int i = 0; i < monsters.Length; i++)
        {
            if (monsters[i].transform.position.z > transform.position.z)
            {
                float dist = Vector3.Distance(transform.position, monsters[i].transform.position);

                if (dist < distance)
                {
                    distance = dist;

                    target = i;
                }
            }
        }

        if(target < 0)
        {
            transform.localEulerAngles = Vector3.zero;
        }
        else
        {
            transform.LookAt(monsters[target].transform);
        }
    }




    private IEnumerator ShootAnim(int id, int shellID)
    {
        if (_eShoot == EShoot.all)
        {
            for (int i = 0; i < _fire.Length; i++)
            {
                _fire[i].SetActive(true);
                _source.PlayOneShot(_gun);
            }
            for (int i = 0; i < _shell.Length; i++)
            {
                _shell[i].SetActive(true);
            } 


            yield return new WaitForSeconds(0.1f);

            for (int i = 0; i < _fire.Length; i++)
            {
                _fire[i].SetActive(false);
            }

            yield return new WaitForSeconds(0.1f);

            for (int i = 0; i < _shell.Length; i++)
            {
                _shell[i].SetActive(false);
            }
        }
        else
        {
            _fire[id].SetActive(true);
            _shell[shellID].SetActive(true);

            _source.PlayOneShot(_gun);

            yield return new WaitForSeconds(0.1f);

            _fire[id].SetActive(false);

            yield return new WaitForSeconds(0.1f);

            _shell[shellID].SetActive(false);
        }
    }



    private void OnDestroy()
    {
        SoundController.OnSFXVolumeChanged -= (f) => _source.volume = f;
    }


    public enum EShoot
    {
        all, stack
    }
}