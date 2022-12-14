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
    public BeatScoller beatScoller;
    private Notemanager notemanager;
    public GameObject parent;
    private state State;

    public Animator animator;
    public bool canPress = true;

    private void Awake()
    {
        notemanager = GameObject.Find("notemanager").GetComponent<Notemanager>();
        animator = gameObject.GetComponent<Animator>();
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
                if (Input.GetKeyDown(quickTime.key1) && notemanager.changePress[0] == true && canPress == true)
                {
                    animator.SetTrigger("Press");
                    if (canBePressed)
                    {
                        noteObject.k = true;
                        img.color = color1;
                        if (noteObject.finalNote == true)
                        {
                            //animator.ResetTrigger("Press");
                            quickTime.checkRhythm("finish");
                            Invoke("closePanel", 1.5f);
                            return;
                        }
                    }
                    if (this.canBePressed == false)
                    {
                        //animator.ResetTrigger("Press");
                        beatScoller.hasStarted = false;
                        quickTime.checkRhythm("fail");
                        Invoke("closePanel", 1.5f);
                        Debug.Log("Miss2");
                        Debug.Log(beatScoller.hasStarted);
                    }
                }               
                break;
            case state.SecondBtn:
                if (Input.GetKeyDown(quickTime.key2) && notemanager.changePress[1] == true && canPress == true)
                {
                    animator.SetTrigger("Press");
                    if (canBePressed)
                    {
                        noteObject.k = true;
                        img.color = color1;
                        //animator.ResetTrigger("Press");
                        if (noteObject.finalNote == true)
                        {
                            quickTime.checkRhythm("finish");
                            Invoke("closePanel", 1.5f);
                            return;
                        }
                    }
                    if (this.canBePressed == false)
                    {
                        //animator.ResetTrigger("Press");
                        beatScoller.hasStarted = false;
                        quickTime.checkRhythm("fail");
                        Invoke("closePanel", 1.5f);
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

    public void closePanel()
    {
        parent.SetActive(false);
    }
}
