using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhenInGame : MonoBehaviour
{
    public Image image;
    public movement Movement;
    public Rigidbody rigidbody = null;
    public GameObject cinemachine;
    float colorAlpha = 255;

    private void Start()
    {
        image = gameObject.GetComponent<Image>();
        Movement = GameObject.Find("MainCharacter1").GetComponent<movement>();
        cinemachine = GameObject.Find("TPSCM FreeLook");
        if (rigidbody == null)
        {
            rigidbody = GameObject.Find("MainCharacter1").GetComponent<Rigidbody>();
            rigidbody.useGravity = false;
        }

        cinemachine.SetActive(false);
        Movement.enabled = false;
    }
    private void Update()
    {
        if (colorAlpha > 0)
        {
            
            
            colorAlpha -= 255 * Time.deltaTime;
            Color32 color = new Color32(0, 0, 0, (byte)colorAlpha);
            image.color = color;
        }else if (colorAlpha <= 0)
        {
            rigidbody.useGravity = true;
            cinemachine.SetActive(true);
            Movement.enabled = true;
            Destroy(gameObject);
        }

        
    }
}

