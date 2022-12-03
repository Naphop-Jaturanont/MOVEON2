using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeMusic : MonoBehaviour
{
    public AudioManager audioManager;
    public string musicName;
    public bool when;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        if(when == true && musicName != null)
        {
            audioManager.PlayMusic(musicName);
        }
        else
        {
            audioManager.musicSource.Stop();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
