using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeQuickEvent
{
    Press,
    RepeatPress,
    Rhythm,
    Aim
}


public class QuickTimeEvent : MonoBehaviour
{
    public TypeQuickEvent typeQuickEvent;
    public GameObject panelQuicktime;
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

        }
    }

    public void checkPress()
    {

    }

    public void checkRepeatPress()
    {

    }

    public void checkRhythm()
    {

    }

    public void checkAim()
    {

    }
}
