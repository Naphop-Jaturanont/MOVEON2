using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepStick : MonoBehaviour, IInteractable
{
    public interactsomething interactomething;
    public keep keepStick = null;
    public bool keep = false;

    public GameObject panelKeepTaovun;
    public GameObject panelFinish;
    public GameObject panelEnough;
    
    public interactsomething interactsomething => interactomething;

    public string InteractionPrompt => throw new System.NotImplementedException();

    public bool Interact(Interactor interactor)
    {
        movement Movement = GameObject.Find("MainCharacter1").GetComponent<movement>();
        Movement.enable = true;
        Movement.animator.SetFloat("speed", 0f);
        if (keepStick.keepTaovun == true)
        {
            panelFinish.SetActive(true);
            Destroy(gameObject);
        }
        else if(keepStick.keepStick == true)
        {
            panelEnough.SetActive(true);
        }
        else
        {
            Destroy(gameObject);
            panelKeepTaovun.SetActive(true);
        }
        keepStick.keepStick = true;
        return true;
    }
}
