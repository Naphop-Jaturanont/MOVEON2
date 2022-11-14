using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrigerToNext : MonoBehaviour
{
    public GameObject vdoWantPlay;
    public GameObject inGame;
    public movement Movement;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inGame.SetActive(false);
            vdoWantPlay.SetActive(true);
            Movement.OnApplicationFocus(false);
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
