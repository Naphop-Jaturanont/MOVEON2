using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInGame : MonoBehaviour
{
    public Image image;
    public bool fade;
    public bool fadeout = false;
    public float colorAlpha = 255;
    public GameObject vdoWantPlay = null;
    public GameObject inGame = null;
    public AudioController audioController;

    public GameObject mainCamera;
    public GameObject cameraForVideo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fade == true)
        {
            if (colorAlpha > 0)
            {
                if(image.gameObject.activeSelf == false)
                {
                    image.gameObject.SetActive(true);
                }
                
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
        if (fadeout == true)
        {
            if (colorAlpha < 255)
            {
                if (image.gameObject.activeSelf == false)
                {
                    image.gameObject.SetActive(true);
                }
                colorAlpha += 255 * Time.deltaTime;
            }
            Color32 color = new Color32(0, 0, 0, (byte)colorAlpha);
            image.color = color;
            if (colorAlpha >= 255)
            {
                inGame.SetActive(false);
                mainCamera.SetActive(false);
                cameraForVideo.SetActive(true);
                vdoWantPlay.SetActive(true);
                audioController.ChangeVideoScripts(vdoWantPlay);
                image.gameObject.SetActive(false);
                fadeout = false;
                colorAlpha = 255;
            }
        }

    }
}
