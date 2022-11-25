using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrigerToNext : MonoBehaviour
{    
    public GameObject vdoWantPlay;
    public GameObject inGame;
    public movement Movement;
    public bool check = false;

    public GameObject animaCamera;
    public GameObject Camera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            animaCamera.SetActive(true);
            
            
        }
    }

    private void Update()
    {
        //Debug.Log(animaCamera.transform.position.sqrMagnitude - Camera.transform.position.sqrMagnitude);
        if (animaCamera.transform.position.sqrMagnitude - Camera.transform.position.sqrMagnitude > -1
            && check == false && animaCamera.activeSelf == true)
        {
            inGame.SetActive(false);
            vdoWantPlay.SetActive(true);
            check = true;
        }
    }
    /*public levelPass level;
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Player")
        {
            level.UnlockWay(0);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            movement Move = GameObject.Find("MainCharacter1").GetComponent<movement>();
            Move.OnApplicationFocus(false);
        }
    }*/
}
