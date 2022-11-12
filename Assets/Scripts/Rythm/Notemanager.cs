using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum state
{
    FirstBtn,
    SecondBtn
}
public class Notemanager : MonoBehaviour
{
    public bool[] changePress;
    // Start is called before the first frame update
    void Start()
    {
        changePress[0] = true;
        changePress[1] = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
