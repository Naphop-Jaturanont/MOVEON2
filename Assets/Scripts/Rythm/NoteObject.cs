using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteObject : MonoBehaviour
{
    public CheckNote checkNote;
    private bool canBePressed;

    public Image img;//
    public Color pressedColor = Color.green;//

    public bool k;
    public bool finalNote;

    private void Start()
    {
        checkNote = GameObject.Find("Check").GetComponent<CheckNote>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Destroy")
        {
            DestroyObject(gameObject);//
        }
    }
    private void OnTriggerExit2D(Collider2D collision)//
    {
        if(collision.tag == "A")
        {
            canBePressed = false;
            if (k == false)
            {
                checkNote.quickTime.checkRhythm("fail");
                Debug.Log("Miss");
            }
        }
        
    }
}
