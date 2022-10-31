using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class TestVideos : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public VideoClip[] videoClip;

    //public VideoClip videoClipchose1;
    //public VideoClip videoClipchose2;

    public GameObject button;
    int i = 0;
    bool chose;

    void Awake()
    {
        videoPlayer.clip = videoClip[0];
        //videoPlayer.clip = videoClip[i];
        videoPlayer.Play();
        /*
        i = 0;
        videoPlayer.clip = videoClip[i];
        videoPlayer.Play();
        */
        
    }


     void Update()
    {
       
        
        if (videoPlayer.isPaused == true && chose == false)
        {
            i++;
            if (i > videoClip.Length - 1)
            {
                i = 0;
            }
            //new clip to videoplayer
            videoPlayer.clip = videoClip[i];
            //Debug.Log(videoPlayer.clip);
            //videoplayer play
            videoPlayer.Play();
            if(videoPlayer.clip = videoClip[1])
            {
                videoPlayer.isLooping = true;
                button.gameObject.SetActive(true);
            }

     
        }
            
        
    }

    
}
