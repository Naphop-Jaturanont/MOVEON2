using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PointFade
{
    Start,
    End
}
public class changeMusic : MonoBehaviour
{
    public PointFade pointFade;
    public AudioManager audioManager;
    public string musicName;
    public bool when;
    public bool fadeout;
    public bool fadein;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        if(pointFade == PointFade.Start)
        {
            if (when == true && musicName != null)
            {
                audioManager.PlayMusic(musicName);
            }
            else
            {
                audioManager.musicSource.Stop();
            }
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fadeout == true)
        {
            audioManager.musicSource.volume -= 1 * Time.deltaTime;
            if(audioManager.musicSource.volume <= 0)
            {
                audioManager.musicSource.volume = 0;
                fadeout = false;
            }
        }

        if(fadein == true)
        {
            audioManager.PlayMusic(musicName);
            audioManager.musicSource.volume += PlayerPrefs.GetFloat("save music") * Time.deltaTime;
            if (audioManager.musicSource.volume >= PlayerPrefs.GetFloat("save music"))
            {
                audioManager.musicSource.volume = PlayerPrefs.GetFloat("save music");
                fadein = false;
            }
        }
    }
}
