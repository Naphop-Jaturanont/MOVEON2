using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TypeQuickEvent
{
    Press,
    RepeatPress,
    Rhythm,
    Aim,
    QuiclPress
}


public class QuickTimeEvent : MonoBehaviour
{
    public TypeQuickEvent typeQuickEvent;
    public TestVideos videos;
    public GameObject panelQuicktime;

    [Space(10)]
    [Header("Important")]
    [Tooltip("!!Must Have!!")]
    public KeyCode key1 = KeyCode.None;
    public int success;
    public int fail;

    [Space(10)]
    [Header("Have or Not Have")]
    public KeyCode key2 = KeyCode.None;
    public Image fillImage = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (typeQuickEvent)
        {
            case TypeQuickEvent.Press:
                panelQuicktime.SetActive(true);
                checkPress();
                break;
            case TypeQuickEvent.RepeatPress:
                panelQuicktime.SetActive(true);
                //animator
                checkRepeatPress();
                break;
            case TypeQuickEvent.Rhythm:
                panelQuicktime.SetActive(true);
                checkRhythm();
                break;
            case TypeQuickEvent.Aim:
                panelQuicktime.SetActive(true);
                checkAim();
                break;
            case TypeQuickEvent.QuiclPress:
                panelQuicktime.SetActive(true);
                checkQuickPress();
                break;

        }
    }

    public void checkQuickPress()
    {
        if (Input.GetKeyDown(key1) && videos.timer == true)
        {
            videos.chooseChoice(success);
        }
        else if (!Input.GetKeyDown(key1) || videos.timer == false)
        {
            videos.chooseChoice(fail);
        }
    }

    public void checkPress()
    {
        if (Input.GetKeyDown(key1))
        {
            videos.chooseChoice(1);
        }
        if (Input.GetKeyDown(key2))
        {
            videos.chooseChoice(2);
        }
    }

    public void checkRepeatPress()
    {
        if (Input.GetKeyDown(key1))
        {
            fillImage.fillAmount += (float)0.125;
            Debug.Log(fillImage.fillAmount);
            if(fillImage.fillAmount >= 1 && videos.timer == true)
            {
                videos.chooseChoice(success);
            }
            else if(fillImage.fillAmount < 1 && videos.timer == false && videos.time <=0)
            {
                Debug.Log("fail");
                videos.chooseChoice(fail);
            }
        }        

        if (fillImage.fillAmount > 0)
        {
            fillImage.fillAmount -= (float)0.5 * Time.deltaTime;
        }

        if (fillImage.fillAmount < 1 && videos.timer == false && videos.time <= 0)
        {
            Debug.Log("fail");
            videos.chooseChoice(fail);
        }
    }

    public void checkRhythm()
    {

    }

    public void checkAim()
    {

    }
}
