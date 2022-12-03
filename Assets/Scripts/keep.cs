using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keep : MonoBehaviour
{
    public bool keepStick = false;
    public bool keepTaovun = false;

    public DialogOnVDO vDO;
    public bool finishline = false;
    public Image image;
    float colorAlpha = 0;
    public GameObject ingame;
    public GameObject vdo;
    public spawnTaovun spawn;
    public AudioController audioController;
    private void Start()
    {
        spawn = GetComponent<spawnTaovun>();
    }
    private void Update()
    {
        if (colorAlpha < 255 && finishline == true)
        {
            colorAlpha += 255 * Time.deltaTime;
            Color32 color = new Color32(0, 0, 0, (byte)colorAlpha);
            image.color = color;
        }
        else if (colorAlpha >= 255)
        {
            //spawn.clearObject();
            spawn.clearObject();
            audioController.ChangeVideoScripts(vdo);
            vdo.gameObject.SetActive(true);
            ingame.SetActive(false);
        }

        if (vDO.index >= vDO.lines.Length - 1 && vDO.maxLine == true)
        {
            if(vDO.gameObject.activeInHierarchy == false)
            {
                finishline = true;
            }
        }
    }

    
}
