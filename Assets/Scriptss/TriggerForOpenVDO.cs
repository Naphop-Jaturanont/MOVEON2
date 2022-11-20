using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForOpenVDO : MonoBehaviour
{
    public GameObject inGame;
    public GameObject vDOWanOpen;
    public Light lightInGame;
    public bool closeLight;

    private void Update()
    {
        if(closeLight == true)
        {
            if(lightInGame.intensity > 0.001)
            {
                lightInGame.intensity -= (lightInGame.intensity * 3) * Time.deltaTime;
            }
            if(lightInGame.intensity <= 0.001)
            {
                inGame.SetActive(false);
                vDOWanOpen.SetActive(true);
                closeLight = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            closeLight = true;
        }
    }
}
