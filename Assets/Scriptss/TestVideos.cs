using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum typePlay
{
    playOnce,
    loop,
    playOneFrame
}

public class TestVideos : MonoBehaviour
{
    public typePlay type;
    public VideoPlayer videoPlayer;
    public VideoClip[] videoClip;
    public VideoCheckpoint videoCheckpoint;
    private Checkpoint checkpoint;
    private QuickTimeEvent quickTime;
    private DialogOnVDO dialog;
    public GameObject inGame = null;
    public GameObject loopWhileChoose = null;
    public GameObject choice1 = null;
    public GameObject choice2 = null;
    public stage1 Stage1;
    public PauseGame pauseGame;

    [Space(10)]
    [Header("Timer")]
    [Tooltip("if you want timer when choose")]
    public Image imageValue = null;
    public Image imageValue1 = null;
    public bool timer = false;
    public float time = 0;
    private float maxTime = 0;
    public float timeWhenChoose = 20;

    [Space(10)]
    [Header("Loop")]
    [Tooltip("if you want loop Video in Array")]
    public bool loopArray = false;

    [Space(10)]
    [Header("oneFrame")]
    [Tooltip("if you want play Video each frame")]
    public bool oneFrame = false;

    [Space(10)]
    [Header("oneFrame")]
    [Tooltip("if you want play final Video before ingame")]
    public Image fadeImage = null;
    float colorAlpha = 0;
    public Color myColor;
    public bool finalVdoBeforeInGame = false;
    public bool finalVdo = false;

    //public VideoClip videoClipchose1;
    //public VideoClip videoClipchose2;
    public int i = 0;
    bool chose;

    private void Awake()
    {
        checkpoint = GameObject.Find("checkpointmanager").GetComponent<Checkpoint>();
        quickTime = GetComponent<QuickTimeEvent>();
        dialog = gameObject.transform.GetComponentInChildren<DialogOnVDO>();
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
        if(pauseGame == null)
        {
            pauseGame = GameObject.Find("CanvasPause").GetComponent<PauseGame>();
            pauseGame.vidoplayer = gameObject.GetComponent<TestVideos>();
        }
        switch (type)
        {
            case typePlay.playOnce:
                if (videoPlayer.isPaused == true && chose == false)
                {
                    if (loopArray == false)
                    {
                        if (i < videoClip.Length - 1)
                        {
                            i++;
                            videoCheckpoint.indexVideo = i;
                        }
                        else if (i >= videoClip.Length - 1)
                        {
                            if(finalVdoBeforeInGame == true)
                            {
                                
                                if(fadeImage != null)
                                {
                                    myColor.a = 0;
                                    if (colorAlpha < 255)
                                    {
                                        colorAlpha += 255  * Time.deltaTime;
                                    }
                                    Color32 color = new Color32(0,0,0,(byte)colorAlpha);
                                    fadeImage.color = color;
                                    if(colorAlpha >= 255)
                                    {
                                        inGame.SetActive(true);
                                        gameObject.SetActive(false);
                                        return;
                                    }
                                }
                                else
                                {
                                    inGame.SetActive(true);
                                    gameObject.SetActive(false);
                                }
                                return;
                            }else if(finalVdo == true)
                            {
                                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                            }
                            else
                            {
                                gameObject.SetActive(false);
                                checkpoint.PassVideoWantCheck++;
                                loopWhileChoose.SetActive(true);
                                return;
                            }
                            
                        }
                    }
                    videoPlayer.clip = videoClip[i];
                    videoPlayer.Play();                    
                }
                break;
            case typePlay.loop:
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
                    videoPlayer.clip = videoClip[i];
                    videoPlayer.Play();

                }
                break;
            case typePlay.playOneFrame:
                if (videoPlayer.isPaused == true && !Input.anyKeyDown)
                {
                    videoPlayer.clip = videoClip[i];
                    videoPlayer.Play();
                }
                if (Input.GetKeyDown(quickTime.key1) && dialog.maxLine == true)
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

                    videoPlayer.clip = videoClip[i];
                    videoPlayer.Play();

                }
                break;
        }
        

        if (timer == true)
        {
            imageValue.fillAmount = time / maxTime;
            if(imageValue1)
            {
                imageValue1.fillAmount = time / maxTime;
            }            
            time -= timeWhenChoose * Time.deltaTime;            
            if(time <= 0)
            {
                timer = false;
            }
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
