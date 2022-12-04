using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public enum typePlay
{
    playOnce,
    loop,
    playOneFrame
}

public class TestVideos : MonoBehaviour
{
    public UnityEvent unityEvent = null;
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
    public AudioController audioController;

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
    [Header("Fade in && Fade out")]
    [Tooltip("if you want Fade in Video")]
    public bool FadeIn = false;
    public bool FadeOut = false;
    public bool CheckFadeOut = false;

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
    public float colorAlpha = 255;
    public Color myColor;
    [SerializeField]private bool colorBoolAlpha = false;
    public bool finalVdoBeforeInGame = false;
    public bool finalVdo = false;
    private bool isPause;

    //public VideoClip videoClipchose1;
    //public VideoClip videoClipchose2;
    public int i = 0;
    public string nameVideo1 = null;
    public string nameVideo2 = null;
    public VideoClip[] idleVideo = null;

    bool chose;

    //solve camera
    public GameObject mainCamera;
    public GameObject cameraForVideo;

    private void Awake()
    {
        checkpoint = GameObject.Find("checkpointmanager").GetComponent<Checkpoint>();
        quickTime = GetComponent<QuickTimeEvent>();
        dialog = gameObject.transform.GetComponentInChildren<DialogOnVDO>();
        videoPlayer.loopPointReached += changeVdo;

        if (pauseGame == null)
        {
            pauseGame = GameObject.Find("CanvasPause").GetComponent<PauseGame>();
            pauseGame.vidoplayer = gameObject.GetComponent<TestVideos>();
        }

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
        if (pauseGame.isPause == false)
        {
            if (FadeIn == true)
            {
                if (colorAlpha > 0)
                {
                    if (fadeImage.gameObject.activeInHierarchy == false)
                    {
                        fadeImage.gameObject.SetActive(true);
                    }
                    colorAlpha -= 255 * Time.deltaTime;
                }
                Color32 color = new Color32(0, 0, 0, (byte)colorAlpha);
                fadeImage.color = color;
                if (colorAlpha <= 0)
                {
                    fadeImage.gameObject.SetActive(false);
                    FadeIn = false;
                    colorAlpha = 0;
                }
            }


            if (colorBoolAlpha == true)
            {
                if (finalVdoBeforeInGame == true)
                {
                    if (fadeImage != null && FadeOut == true)
                    {
                        myColor.a = 0;
                        if (colorAlpha < 255)
                        {
                            if (fadeImage.gameObject.activeInHierarchy == false)
                            {
                                fadeImage.gameObject.SetActive(true);
                            }
                            colorAlpha += 255 * Time.deltaTime;
                        }
                        Color32 color = new Color32(0, 0, 0, (byte)colorAlpha);
                        fadeImage.color = color;
                        if (colorAlpha >= 255)
                        {
                            if (unityEvent != null)
                            {
                                unityEvent.Invoke();
                            }
                            mainCamera.SetActive(true);
                            cameraForVideo.SetActive(false);
                            fadeImage.gameObject.SetActive(false);
                            inGame.SetActive(true);
                            gameObject.SetActive(false);
                            return;
                        }
                    }
                    else
                    {
                        mainCamera.SetActive(true);
                        cameraForVideo.SetActive(false);
                        inGame.SetActive(true);
                        gameObject.SetActive(false);
                    }
                    return;
                }
                else if (finalVdo == true)
                {
                    if (fadeImage != null)
                    {
                        myColor.a = 0;
                        if (colorAlpha < 255)
                        {
                            colorAlpha += 255 * Time.deltaTime;
                        }
                        Color32 color = new Color32(0, 0, 0, (byte)colorAlpha);
                        fadeImage.color = color;
                        if (colorAlpha >= 255)
                        {
                            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                            return;
                        }
                    }

                }
                else if (FadeOut == true)
                {
                    if (colorAlpha < 255)
                    {
                        if (fadeImage.gameObject.activeInHierarchy == false)
                        {
                            fadeImage.gameObject.SetActive(true);
                        }
                        colorAlpha += 255 * Time.deltaTime;
                    }
                    Color32 color = new Color32(0, 0, 0, (byte)colorAlpha);
                    fadeImage.color = color;
                    if (colorAlpha >= 255)
                    {
                        fadeImage.gameObject.SetActive(false);
                        gameObject.SetActive(false);
                        checkpoint.PassVideoWantCheck++;
                        audioController.ChangeVideoScripts(loopWhileChoose);
                        loopWhileChoose.SetActive(true);
                        FadeOut = false;
                        colorAlpha = 255;
                        return;
                    }
                }
                else
                {
                    gameObject.SetActive(false);
                    checkpoint.PassVideoWantCheck++;
                    audioController.ChangeVideoScripts(loopWhileChoose);
                    loopWhileChoose.SetActive(true);
                    return;

                }
            }


            if (type == typePlay.playOneFrame)
            {
                if (videoPlayer.isPaused == true && !Input.anyKeyDown)
                {
                    if(nameVideo1 != null || nameVideo2 != null)
                    {
                        if (videoClip[i].name == nameVideo1)
                        {
                            Debug.Log(videoPlayer.clip);
                            videoPlayer.clip = idleVideo[0];
                            Debug.Log(videoPlayer.clip);
                            videoPlayer.Play();
                            videoPlayer.isLooping = true;
                        }
                        else if (videoClip[i].name == nameVideo2)
                        {
                            videoPlayer.clip = idleVideo[1];
                            videoPlayer.Play();
                            videoPlayer.isLooping = true;
                        }
                    }                    
                    else
                    {
                        videoPlayer.clip = videoClip[i];
                        videoPlayer.Play();
                    }
                    
                }
                if (Input.anyKeyDown && dialog.maxLine == true && !Input.GetKeyDown(KeyCode.Escape))
                {
                    videoPlayer.isLooping = false;
                    if (i < videoClip.Length - 1)
                    {
                        i++;
                        videoCheckpoint.indexVideo = i;
                    }
                    else if (i >= videoClip.Length - 1)
                    {
                        if(FadeOut == true)
                        {
                            CheckFadeOut = true;
                        }
                        else
                        {
                            gameObject.SetActive(false);
                            checkpoint.PassVideoWantCheck++;
                            audioController.ChangeVideoScripts(loopWhileChoose);
                            loopWhileChoose.SetActive(true);
                        }                       
                        return;
                    }

                    videoPlayer.clip = videoClip[i];
                    videoPlayer.Play();

                }
                if (CheckFadeOut == true)
                {
                    if (colorAlpha < 255)
                    {
                        if (fadeImage.gameObject.activeInHierarchy == false)
                        {
                            fadeImage.gameObject.SetActive(true);
                        }
                        colorAlpha += 255 * Time.deltaTime;
                    }
                    Color32 color = new Color32(0, 0, 0, (byte)colorAlpha);
                    fadeImage.color = color;
                    if (colorAlpha >= 255)
                    {
                        fadeImage.gameObject.SetActive(false);
                        gameObject.SetActive(false);
                        checkpoint.PassVideoWantCheck++;
                        audioController.ChangeVideoScripts(loopWhileChoose);
                        loopWhileChoose.SetActive(true);
                        FadeOut = false;
                        colorAlpha = 255;
                        return;
                    }
                }
            }



            if (timer == true)
            {
                imageValue.fillAmount = time / maxTime;
                if (imageValue1)
                {
                    imageValue1.fillAmount = time / maxTime;
                }
                time -= timeWhenChoose * Time.deltaTime;
                if (time <= 0)
                {
                    timer = false;
                }
            }
        }
    }
    
    public void changeVdo(VideoPlayer vp)
    {
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
                            colorBoolAlpha = true;
                            return;

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
                               
                break;
        }

    }

    public void chooseChoice(int index)
    {
        switch (index)
        {
            case 1:
                gameObject.SetActive(false);
                videoPlayer.Stop();
                audioController.ChangeVideoScripts(choice1);
                choice1.SetActive(true);
                break;
            case 2:
                gameObject.SetActive(false);
                videoPlayer.Stop();
                audioController.ChangeVideoScripts(choice2);
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

    public void ResetIndex(float timeed)
    {
        i = 0;
        videoPlayer.clip = videoClip[i];
        videoPlayer.Play();
        time = timeed;
        colorBoolAlpha = false;
        colorAlpha = 0;
        if(timeed > 0)
        {
            timer = true;
        }
        
    }

}
