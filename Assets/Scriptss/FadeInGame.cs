using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInGame : MonoBehaviour
{
    public Image image;
    public bool fade;
    public float colorAlpha = 255;
    // Start is called before the first frame update
    void Start()
    {
        image.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(fade == true)
        {
            if (colorAlpha > 0)
            {
                colorAlpha -= 255 * Time.deltaTime;
            }
            Color32 color = new Color32(0, 0, 0, (byte)colorAlpha);
            image.color = color;
            if (colorAlpha <= 0)
            {
                image.gameObject.SetActive(false);
                fade = false;
                colorAlpha = 0;
            }
        }
        
    }
}
