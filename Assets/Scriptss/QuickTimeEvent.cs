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
    QuiclPress,
    Dialogue
}


public class QuickTimeEvent : MonoBehaviour
{
    public TypeQuickEvent typeQuickEvent;
    public TestVideos videos;
    public GameObject panelQuicktime;
    private Image imagePanelQ;//add animation
    public Image imagePanelQ2 = null;//add animation
    public Sprite whenTrue = null;//add animation
    public Animator animator = null;//add animation
    public bool checkChoose = false;

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
    public DraggableUI draggableUI = null;

    float colorAlpha = 0;
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
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(key1) && videos.timer == true)
            {
                videos.chooseChoice(success);
                Debug.Log("success");
                return;
            }
            else if (Input.anyKeyDown)
            {
                videos.chooseChoice(fail);
                Debug.Log("fail");
            }
        }else if( videos.timer == false)
        {
            videos.chooseChoice(fail);
            Debug.Log("fail");
        }

        
    }

    public void checkPress()
    {
        if (Input.GetKeyDown(key1))
        {
            animator = panelQuicktime.transform.GetChild(0).GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetTrigger("success");//add animation
            }
            if (whenTrue)
            {
                if(imagePanelQ2 != null)
                {
                    imagePanelQ2.gameObject.SetActive(false);
                }                
                imagePanelQ = panelQuicktime.transform.GetChild(0).GetComponent<Image>();//add animation
                imagePanelQ.sprite = whenTrue;//add animation
                
                if (colorAlpha < 255)
                {
                    colorAlpha += 255 * Time.deltaTime;
                }
                Color32 color = new Color32(0, 0, 0, (byte)colorAlpha);
                imagePanelQ.color = color;
                if (colorAlpha >= 255)
                {
                    imagePanelQ.gameObject.SetActive(false);//add animation
                }
                
            }
            Invoke("closeDelay", 1.5f);//add animation
            videos.chooseChoice(1);
        }
        if (Input.GetKeyDown(key2))
        {
            animator = panelQuicktime.transform.GetChild(0).GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetTrigger("success");//add animation
            }
            if (whenTrue)
            {
                imagePanelQ = panelQuicktime.transform.GetChild(0).GetComponent<Image>();//add animation
                imagePanelQ.gameObject.SetActive(false);
                imagePanelQ2 = panelQuicktime.transform.GetChild(1).GetComponent<Image>();//add animation
                imagePanelQ2.sprite = whenTrue;//add animation
                imagePanelQ2.gameObject.SetActive(true);//add animation
                if (colorAlpha < 255)
                {
                    colorAlpha += 255 * Time.deltaTime;
                }
                Color32 color = new Color32(0, 0, 0, (byte)colorAlpha);
                imagePanelQ.color = color;
                if (colorAlpha >= 255)
                {
                    imagePanelQ2.gameObject.SetActive(false);
                }
                
            }
            Invoke("closeDelay", 1.5f);//add animation
            videos.chooseChoice(2);
        }        
    }

    public void checkRepeatPress()
    {
        if (Input.GetKeyDown(key1))
        {
            fillImage.fillAmount += (float)0.175;
            Debug.Log(fillImage.fillAmount);
            if(fillImage.fillAmount >= 1 && videos.timer == true)
            {
                Invoke("closeDelay", 1.5f);
                videos.chooseChoice(success);
            }
            else if(fillImage.fillAmount < 1 && videos.timer == false && videos.time <=0)
            {
                fillImage.color = Color.red;
                panelQuicktime.SetActive(false);
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
            fillImage.color = Color.red;
            Debug.Log("fail");
            Invoke("closeDelay", 1.5f);
            videos.chooseChoice(fail);
        }
    }
    public void ResetImage()
    {
        fillImage.fillAmount = 0;
        colorAlpha = 0;
        animator.CrossFadeInFixedTime("SpacebarUICtrl", 0.1f);
    }

    public void checkRhythm(string type)
    {
        switch (type)
        {
            case "finish":
                videos.chooseChoice(success);
                break;
            case "fail":
                videos.chooseChoice(fail);
                break;
        }
    }

    public void checkAim()
    {
        if(draggableUI.checkPosition == true)
        {
            videos.chooseChoice(success);
        }else if(draggableUI.checkPosition == false && videos.time <= 0)
        {
            videos.chooseChoice(fail);
        }
    }

    public void closeDelay()
    {
        
        panelQuicktime.SetActive(false);        
    }
}
