using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractWhite : MonoBehaviour, IInteractable
{
    public GameObject inGame;
    public GameObject vdo;

    public bool interact = false;

    public Image image;

    float colorAlpha = 0;
    public interactsomething interactsomething => throw new System.NotImplementedException();

    public string InteractionPrompt => throw new System.NotImplementedException();

    public bool Interact(Interactor interactor)
    {
        interact = true;
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(interact == true)
        {
            if (colorAlpha < 255)
            {
                colorAlpha += 255 * Time.deltaTime;
                Color32 color = new Color32(0, 0, 0, (byte)colorAlpha);
                Debug.Log(colorAlpha);
                image.color = color;
            }
            else if (colorAlpha >= 255)
            {
                inGame.SetActive(false);
                vdo.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}
