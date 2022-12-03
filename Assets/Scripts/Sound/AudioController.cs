using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class AudioController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;
    public Slider videoSlider;
    public float musicValue, sfxValue;
    public float videoValue;

    public VideoPlayer videoplayer;

    public void Start()
    {
        PlayerPrefs.SetFloat("save music",1f);
        PlayerPrefs.SetFloat("save sfx",1f);
        
    }
    private void Update()
    {
        _musicSlider.value = PlayerPrefs.GetFloat("save music");
        _sfxSlider.value = PlayerPrefs.GetFloat("save sfx");
        videoSlider.value = videoplayer.GetDirectAudioVolume(0);
        
    }
    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(_musicSlider.value);
        
    }

    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(_sfxSlider.value);
        
    }
    public void VideoVolume()
    {
        AudioManager.Instance.MusicVolume(_musicSlider.value);

    }
    public void ChangeMusicSlider(float value)
    {
        //musicValue = value;
        PlayerPrefs.SetFloat("save music", value);
    }
    public void ChangeSfxSlider(float value)
    {
        //sfxValue = value;
        PlayerPrefs.SetFloat("save sfx", value);
    }

    public void ChangeVDOSlider(float value)
    {
        //sfxValue = value;
        videoplayer.SetDirectAudioVolume(0, value);
        PlayerPrefs.SetFloat("save videoSound", value);
    }

    public void ChangeVideoScripts(GameObject gameObject)
    {
        videoplayer = gameObject.GetComponent<VideoPlayer>();
    }
}
