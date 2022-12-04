using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showUIinWorld : MonoBehaviour
{
    public GameObject uiInW;
    public Transform player;

    private void Awake()
    {
        player = GameObject.Find("head").GetComponent<Transform>();
    }
    private void Update()
    {
        
    }

    private void LateUpdate()
    {
        uiInW.transform.LookAt(player);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            uiInW.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            uiInW.SetActive(false);
        }
    }
}
