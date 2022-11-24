using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PauseGame : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject settingUI;
    public GameObject pauseMenu;
    public GameObject exitToMain;
    public GameObject exitToDesktop;

    public TestVideos vidoplayer;
    public GameObject canvas;

    public bool isPause;
    public movement Movement;
    void Start()
    {
        pausePanel = transform.GetChild(0).gameObject;
        //Movement = GameObject.Find("MainCharacter1").GetComponent<movement>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                Resume();

            }
            else
            {
                Pause();
                
            }
        }

    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        if (vidoplayer != null)
        {
            vidoplayer.videoPlayer.playbackSpeed = 0;
        }
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (vidoplayer != null)
        {
            vidoplayer.videoPlayer.playbackSpeed = 1;
        }
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        isPause = false;

        if (settingUI.activeSelf == true)
        {
            pauseMenu.SetActive(true);
            settingUI.SetActive(false);
        }

        if(exitToDesktop.activeSelf == true)
        {
            pauseMenu.SetActive(true);
            exitToDesktop.SetActive(false);
        }

        if(exitToMain.activeSelf == true)
        {
            pauseMenu.SetActive(true);
            exitToMain.SetActive(false);
        }
    }
}
