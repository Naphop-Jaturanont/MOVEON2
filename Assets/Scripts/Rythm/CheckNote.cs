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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canBePressed)
            {
                noteObject.k = true;
                img.color = color1;
            }
            if (this.canBePressed == false)
            {
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
