using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;
    public float musicValue, sfxValue;

    public void Start()
    {
        _musicSlider.value = PlayerPrefs.GetFloat("save music", musicValue);
        _sfxSlider.value = PlayerPrefs.GetFloat("save sfx", sfxValue);
    }
    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(_musicSlider.value);
        
    }

    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(_sfxSlider.value);
        
    }
    public void ChangeMusicSlider(float value)
    {
        musicValue = value;
        PlayerPrefs.SetFloat("save music", musicValue);
    }
    public void ChangeSfxSlider(float value)
    {
        sfxValue = value;
        PlayerPrefs.SetFloat("save sfx", sfxValue);
    }
}
