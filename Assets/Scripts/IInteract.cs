using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteract
{
    // Start is called before the first frame update

    Inventory Inventory{ get; set; }
}



public interface IInteractable
{
    public abstract void Interact(IInteract person);
}