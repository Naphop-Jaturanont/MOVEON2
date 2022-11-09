using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckNote : MonoBehaviour
{
    private bool canBePressed;
    public Image img = null;
    Color color1 = Color.green;
    public NoteObject noteObject;

    public QuickTimeEvent quickTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(quickTime.key1))
        {
            if (canBePressed)
            {
                noteObject.k = true;
                img.color = color1;
                if(noteObject.finalNote == true)
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
        }
    }
}
