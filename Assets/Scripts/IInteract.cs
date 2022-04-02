using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteract
{


}



public interface IInteractable
{
    public abstract void Interact(Player player);
}