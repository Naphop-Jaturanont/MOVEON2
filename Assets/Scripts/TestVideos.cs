using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class TestVideos : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public VideoClip[] videoClip;
    public VideoCheckpoint videoCheckpoint;
    public Checkpoint checkpoint;
    public GameObject loopWhileChoose;
    public GameObject choice1 = null;
    public GameObject choice2 = null;
    public bool loopArray = false;
    //public VideoClip videoClipchose1;
    //public VideoClip videoClipchose2;
    public int i = 0;
    bool chose;

    private void Awake()
    {
        checkpoint = GameObject.Find("checkpointmanager").GetComponent<Checkpoint>();
    }
    private void Start()
    {
        i = 0;
        videoPlayer.clip = videoClip[i];
        videoPlayer.Play();
    }
    private void Update()
    {

        if (videoPlayer.isPaused == true && chose == false)
        {
            Debug.Log("gonext");

            if (loopArray == true)
            {
                if (i <= videoClip.Length - 1)
                {
                    i++;
                    if (i > videoClip.Length - 1)
                    {
                        i = 0;
                    }
                }
            }
            if (loopArray == false)
            {
                if (i < videoClip.Length - 1)
                {
                    i++;
                    videoCheckpoint.indexVideo = i;
                }
                else if (i >= videoClip.Length - 1)
                {
                    gameObject.SetActive(false);
                    checkpoint.PassVideoWantCheck++;
                    loopWhileChoose.SetActive(true);
                    return;
                }
            }
            videoPlayer.clip = videoClip[i];
            videoPlayer.Play();


            //new clip to videoplayer
            //videoplayer play

        }
    }

    public void chooseChoice(int index)
    {
        switch (index)
        {
            case 1:
                gameObject.SetActive(false);
                videoPlayer.Stop();
                choice1.SetActive(true);

                break;
            case 2:
                gameObject.SetActive(false);
                videoPlayer.Stop();
                choice2.SetActive(true);
                break;
        }
    }
}
