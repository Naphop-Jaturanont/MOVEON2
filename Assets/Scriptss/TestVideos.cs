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
    public GameObject loopWhileChoose = null;
    public GameObject choice1 = null;
    public GameObject choice2 = null;
    public stage1 Stage1;

    [Space(10)]
    [Header("Timer")]
    [Tooltip("if you want timer when choose")]
    public Image imageValue = null;
    public bool timer = false;
    public float time = 0;
    private float maxTime = 0;
    public float timeWhenChoose = 20;

    [Space(10)]
    [Header("Loop")]
    [Tooltip("if you want loop Video in Array")]
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
        maxTime = time;
    }
    private void Update()
    {
        if(timer == true)
        {
            imageValue.fillAmount = time / maxTime;
            time -= timeWhenChoose * Time.deltaTime;            
            if(time <= 0)
            {
                timer = false;
            }
        }

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

    public void addScore(int score)
    {
        switch (score)
        {
            case 1:
                Stage1.scoreOfChoice += 1;
                break;
            case 2:
                Stage1.scoreOfChoice -= 1;
                break;
        }
    }

    public void checkScore(string typeChoice)
    {
        switch (typeChoice)
        {
            case "noCheckScore":
                Debug.Log(Stage1.scoreOfChoice);
                break;
            case "CheckScore":
                Debug.Log(Stage1.scoreOfChoice);
                //if(score < Stage1.scoreOfChoice)
                //else
                break;
        }
    }
}
