using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNote : MonoBehaviour
{
    public GameObject prefab;
    public Transform[] spawnPoint;
    public NoteObject noteObject = null;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < spawnPoint.Length; i++)
        {            
            if(i == spawnPoint.Length-1)
            {
                Debug.Log("Final");
                noteObject = Instantiate(prefab, spawnPoint[i]).GetComponent<NoteObject>();
                noteObject.finalNote = true;
            }
            else
            {
                Instantiate(prefab, spawnPoint[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
