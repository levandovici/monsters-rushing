using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impact : Destroyer
{
    [SerializeField]
    protected AudioSource _audio;
    [SerializeField]
    protected AudioClip[] _bump;



    private void Awake()
    {
        OnAwake();
    }



    protected override void OnAwake()
    {
        base.OnAwake();
        _audio.volume = SoundController.SFXVolume;
        if(_bump.Length > 0)
        _audio.PlayOneShot(_bump[UnityEngine.Random.Range(0, _bump.Length)]);
    }
}