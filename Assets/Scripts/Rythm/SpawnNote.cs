using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNote : MonoBehaviour
{
    public GameObject prefab;
    public Transform[] spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < spawnPoint.Length; i++)
        {
            Instantiate(prefab, spawnPoint[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
