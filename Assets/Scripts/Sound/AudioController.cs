using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class AudioController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;
    public Slider videoSlider = null;
    public float musicValue, sfxValue;
    public float videoValue;
    private float recordVideoSound = 1.0f;

    public VideoPlayer videoplayer=null;

    public void Start()
    {
        PlayerPrefs.SetFloat("save music",1f);
        PlayerPrefs.SetFloat("save sfx",1f);
        PlayerPrefs.SetFloat("save videoSound", recordVideoSound);

    }
    private void Update()
    {
        _musicSlider.value = PlayerPrefs.GetFloat("save music");
        _sfxSlider.value = PlayerPrefs.GetFloat("save sfx");
        if (videoSlider != null)
        {
            videoplayer.SetDirectAudioVolume(0, PlayerPrefs.GetFloat("save videoSound"));
            videoSlider.value = videoplayer.GetDirectAudioVolume(0);
            if(PlayerPrefs.GetFloat("save videoSound") == 0)
            {
                ChangeVDOSlider(recordVideoSound);
            }
        }
        Debug.Log(PlayerPrefs.GetFloat("save videoSound"));
        if(PlayerPrefs.GetFloat("save videoSound") != 1f)
        {
            recordVideoSound = PlayerPrefs.GetFloat("save videoSound");
        }


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
