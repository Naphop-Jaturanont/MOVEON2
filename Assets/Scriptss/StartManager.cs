using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartManager : MonoBehaviour
{
    public UnityEvent unityEvent;
    // Start is called before the first frame update
    void Start()
    {
        //unityEvent.Invoke(); 
    }

    private void Awake()
    {
        unityEvent.Invoke();
        Debug.Log("sdddddddddddddddddddddddddddddddddddddddddddddddddddddd");
    }
    private void OnValidate()
    {
        //unityEvent.Invoke();
        //Debug.Log("sdddddddddddddddddddddddddddddddddddddddddddddddddddddd");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
