using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CheckNote : MonoBehaviour
{
    private bool canBePressed;
    public Image img = null;
    public GameObject First = null;
    public GameObject Second = null;
    Color color1 = Color.green;
    public NoteObject noteObject;

    public QuickTimeEvent quickTime;
    private Notemanager notemanager;
    private state State;

    private void Awake()
    {
        notemanager = GameObject.Find("notemanager").GetComponent<Notemanager>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(notemanager.changePress[0] == true)
        {
            State = state.FirstBtn;
        }
        else
        {
            State = state.SecondBtn;
        }

        switch (State)
        {
            case state.FirstBtn:
                if (Input.GetKeyDown(quickTime.key1) && notemanager.changePress[0] == true)
                {
                    if (canBePressed)
                    {
                        noteObject.k = true;
                        img.color = color1;
                        if (noteObject.finalNote == true)
                        {
                            quickTime.checkRhythm("finish");
                            return;
                        }
                    }
                    if (this.canBePressed == false)
                    {
                        quickTime.checkRhythm("fail");
                        Debug.Log("Miss2");
                    }
                }
                break;
            case state.SecondBtn:
                if (Input.GetKeyDown(quickTime.key2) && notemanager.changePress[1] == true)
                {
                    if (canBePressed)
                    {
                        noteObject.k = true;
                        img.color = color1;
                        if (noteObject.finalNote == true)
                        {
                            quickTime.checkRhythm("finish");
                            return;
                        }
                    }
                    if (this.canBePressed == false)
                    {
                        quickTime.checkRhythm("fail");
                        Debug.Log("Miss2");
                    }
                }
                break;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Note")
        {
            canBePressed = true;
            img = collision.GetComponent<Image>();
            noteObject = collision.GetComponent<NoteObject>();
            if(noteObject.finalNote == true)
            {
                Debug.Log("final");
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Note")
        {
            canBePressed = false;
            if(noteObject.change == true)
            {
                notemanager.changePress[0] = !notemanager.changePress[0];
                notemanager.changePress[1] = !notemanager.changePress[1];
                if (notemanager.changePress[0] == false)
                {
                    Second.SetActive(notemanager.changePress[1]);
                }
                else
                {
                    First.SetActive(notemanager.changePress[0]);
                }
            }
        }
    }
}
