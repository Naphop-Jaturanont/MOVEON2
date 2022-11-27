using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InDemoScene : MonoBehaviour
{
    public UnityEvent unityEvent;
    public Image image;
    float colorAlpha = 255;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (colorAlpha > 0)
        {
            colorAlpha -= 255 * Time.deltaTime;
            Color32 color = new Color32(0, 0, 0, (byte)colorAlpha);
            image.color = color;
        }
        else if (colorAlpha <= 0)
        { 
        
        }
            if (Input.GetKeyDown(KeyCode.Space))
        {
            unityEvent.Invoke();
        }
    }
}
