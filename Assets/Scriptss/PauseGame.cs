using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject settingUI;
    public GameObject pauseMenu;
    public GameObject exitToMain;
    public GameObject exitToDesktop;

    public bool isPause;
    void Start()
    {
        pausePanel = transform.GetChild(0).gameObject;

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
        pausePanel.SetActive(true);
        //Time.timeScale = 0f;
        isPause = true;
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        //Time.timeScale = 1;
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
