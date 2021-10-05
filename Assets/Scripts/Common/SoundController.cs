using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Text;
using System;

public class SoundController : MonoBehaviour
{
    public static event Action<float> OnMusicVolumeChanged;
    public static event Action<float> OnSFXVolumeChanged;
    public static float MusicVolume;
    public static float SFXVolume;

    public static void Clear()
    {
        OnMusicVolumeChanged = null;
        OnSFXVolumeChanged = null;
    }



    [SerializeField]
    private AudioSource _music;
    [SerializeField]
    private AudioSource _sfx;

    [SerializeField]
    private AudioClip _musicClip;
    [SerializeField]
    private AudioClip _holidayClip;

    private Dictionary<ESFXClip, AudioClip> _sfxClips = new Dictionary<ESFXClip, AudioClip>();



    private void PlayMusic(AudioClip music)
    {
        _music.loop = true;
        _music.clip = music;
        _music.Play();
    }

    public void PlayMusic(EMusicClip music)
    {
        switch(music)
        {
            case EMusicClip.Music:
                PlayMusic(_musicClip);
                break;

            case EMusicClip.HolidayMusic:
                PlayMusic(_holidayClip);
                break;

            default:
                throw new NotImplementedException();
        }
    }


    public void PlaySFX(ESFXClip sfx)
    {
        _sfx.PlayOneShot(GetSFX(sfx));
    }

    private AudioClip GetSFX(ESFXClip sfx)
    {
        AudioClip clip = null;

        if (!_sfxClips.TryGetValue(sfx, out clip))
        {
            clip = LoadSFX(sfx);
            _sfxClips.Add(sfx, clip);
        }

        return clip;
    }

    private AudioClip LoadSFX(ESFXClip sfx)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("SFX/");

        switch(sfx)
        {
            case ESFXClip.AddGems:
                sb.Append("EarnWater");
                break;

            case ESFXClip.UseKey:
                sb.Append("UseKey");
                break;

            case ESFXClip.NotEnougthResources:
                sb.Append("NotEnougthResources");
                break;

            case ESFXClip.Click:
                sb.Append("Click");
                break;
                
           case ESFXClip.OverNext:
                sb.Append("OverNext");
                break;

            case ESFXClip.chestNext:
                sb.Append("ChestNext");
                break;


            default:
                throw new NotImplementedException();
        }

        return Resources.Load<AudioClip>(sb.ToString());
    }


    public void SetMusicVolume(float value)
    {
        _music.volume = value;
        MusicVolume = value;
        if(OnMusicVolumeChanged != null)
        OnMusicVolumeChanged.Invoke(value);
    }

    public void SetSfxVolume(float value, bool withOutMainSfx)
    {
        if (!withOutMainSfx)
            _sfx.volume = value;

        SFXVolume = value;
        if (OnSFXVolumeChanged != null)
            OnSFXVolumeChanged.Invoke(value);
    }



    public enum EMusicClip
    {
        Music, HolidayMusic,
    }

    public enum ESFXClip
    {
        AddGems, UseKey, NotEnougthResources, Click, OverNext, chestNext
    }
}