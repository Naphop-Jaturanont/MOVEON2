using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnTaovun : MonoBehaviour
{
    public GameObject prefabTaovun;
    public Transform[] spawnPoint;

    private KeepTaovun keepTaovun;
    private void Start()
    {
        for (int i = 0; i < spawnPoint.Length; i++)
        {
            Instantiate(prefabTaovun, spawnPoint[i].position, Quaternion.identity);
            /*keepTaovun = prefabTaovun.GetComponent<KeepTaovun>();
            keepTaovun.panelFinish = GameObject.Find("PanelFinish");
            keepTaovun.panelKeepTaovun = GameObject.Find("PanelkeepTaovun");
            keepTaovun.panelEnough = GameObject.Find("PanelkeepEnough");*/
        }
    }

    public void clearObject()
    {
        GameObject[] gameObject = GameObject.FindGameObjectsWithTag("Taovun");
        for (int i = 0; i < gameObject.Length; i++)
        {            
            Destroy(gameObject[i].gameObject);
        }
    }
}
