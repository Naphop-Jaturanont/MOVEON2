using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public DialogueTrigger dialogueTrigger;
    private movement Movement = null;
    private CharacterController character = null;
    private bool open = false;
    public string InteractionPrompt => _prompt;

    public interactsomething interactsomething => throw new System.NotImplementedException();

    private void Awake()
    {
        //dialogueTrigger = dialogueTrigger.GetComponent<DialogueTrigger>();
    }
    public bool Interact(Interactor interactor)
    {
        if(open == false)
        {
            Movement = GameObject.Find("MainCharacter1").GetComponent<movement>();
            character = GameObject.Find("MainCharacter1").GetComponent<CharacterController>();
            Movement.OnApplicationFocus(false);
            character.enabled = false;
            Movement.enabled = false;
            Movement.rb.useGravity = false;
            Movement.rb.isKinematic = true;
            Debug.Log(dialogueTrigger);
            dialogueTrigger.TriggerDialogue();
            open = true;
            return true;
        }else if(open == true)
        {
            Movement = GameObject.Find("MainCharacter1").GetComponent<movement>();
            character = GameObject.Find("MainCharacter1").GetComponent<CharacterController>();
            Movement.OnApplicationFocus(true);
            character.enabled = true;
            Movement.enabled = true;
            Movement.rb.useGravity = true;
            Movement.rb.isKinematic = false;
            Debug.Log("close door!");
            dialogueTrigger.TriggerDialogueEnd();
            open = false;
            return true;
        }        
        return true;
    }
}
