using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepTaovun : MonoBehaviour, IInteractable
{
    public interactsomething interactomething;
    public keep keepStick;
    public bool keep = false;

    public GameObject panelKeepTaovun;
    public GameObject panelFinish;
    public GameObject panelEnough;

    public DialogOnVDO vDO;

    
    public interactsomething interactsomething => interactomething;

    public string InteractionPrompt => throw new System.NotImplementedException();

    private void Awake()
    {
        keepStick = GameObject.Find("manager").GetComponent<keep>();
        panelKeepTaovun = GameObject.Find("PanelkeepTaovun");
        panelFinish = GameObject.Find("PanelFinish");
        panelEnough = GameObject.Find("PanelkeepEnough");
    }
    public bool Interact(Interactor interactor)
    {
        Destroy(gameObject);
        if (keepStick.keepStick == true)
        {
            panelFinish.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (keepStick.keepTaovun == true)
        {
            panelEnough.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            panelKeepTaovun.transform.GetChild(0).gameObject.SetActive(true);            
        }

        keepStick.keepTaovun = true;
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DelayToVDO()
    {

    }
}
