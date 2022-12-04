using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractWhite : MonoBehaviour
{
    public GameObject inGame;
    public GameObject vdo;

    public GameObject mainCamera;
    public GameObject cameraForVDO;

    public bool interact = false;

    public Image image;

    float colorAlpha = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(interact == true)
        {
            image.gameObject.SetActive(true);
            if (colorAlpha < 255)
            {
                colorAlpha += 255 * Time.deltaTime;
                Color32 color = new Color32(0, 0, 0, (byte)colorAlpha);
                Debug.Log(colorAlpha);
                image.color = color;
            }
            else if (colorAlpha >= 255)
            {
                
                image.gameObject.SetActive(false);
                inGame.SetActive(false);
                mainCamera.SetActive(false);
                cameraForVDO.SetActive(true);
                vdo.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            interact = true;
            Rigidbody rigidbody = GameObject.Find("MainCharacter1").GetComponent<Rigidbody>();
            rigidbody.useGravity = false;
            movement Movement = GameObject.Find("MainCharacter1").GetComponent<movement>();
            Movement.enable = true;
            Movement.animator.SetFloat("speed", 0);
        }
    }

}
