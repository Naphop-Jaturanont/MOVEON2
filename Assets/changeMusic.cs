using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeMusic : MonoBehaviour
{
    public AudioManager audioManager;
    public bool when;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        if(when == true)
        {
            audioManager.PlayMusic("IngameChapter0");
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
