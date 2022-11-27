using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnTaovun : MonoBehaviour
{
    public GameObject prefabTaovun;
    public Transform[] spawnPoint;

    private void Start()
    {
        for (int i = 0; i < spawnPoint.Length; i++)
        {
            Instantiate(prefabTaovun, spawnPoint[i].position, Quaternion.identity);
        }
    }
}
