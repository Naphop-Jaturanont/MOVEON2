using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum interactsomething { handright,handleft,handboth,mouseleft,mouseright }
public interface IInteractable
{
    public interactsomething interactsomething { get; }
    public string InteractionPrompt { get; }

    public bool Interact(Interactor interactor);
}
