using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteObject : MonoBehaviour
{
    public CheckNote checkNote;
    public BeatScoller beatScoller;
    private bool canBePressed;

    public Image img;//
    public Color pressedColor = Color.green;//
    public Color missColor = Color.red;//

    public bool k;
    public bool change;
    public bool finalNote;


    private void Start()
    {
        checkNote = GameObject.Find("Check").GetComponent<CheckNote>();
        beatScoller = GetComponentInParent<BeatScoller>();
    }

    private void Update()
    {
        if(beatScoller.hasStarted == false)
        {
            if(img == null)
            {
                img = GetComponent<Image>();
            }            
            img.color = missColor;
        }
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
                beatScoller.hasStarted = false;
                Invoke("closePanel", 1.5f);
                checkNote.quickTime.checkRhythm("fail");
                Debug.Log("Miss");
            }
        }
        
    }

    public void closePanel()
    {
        checkNote.closePanel();
    }
}
