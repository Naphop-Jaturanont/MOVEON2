using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrigerToNext : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            movement Move = GameObject.Find("MainCharacter1").GetComponent<movement>();
            Move.OnApplicationFocus(false);
        }
    }
}
