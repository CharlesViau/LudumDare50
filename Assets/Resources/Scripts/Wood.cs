using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : Item
{
    // Start is called before the first frame update
    public override void Interact(IInteract person)
    {
        if (person.Inventory.AddItem(this.Type, 1, out var over))
        {
            //TODO delete game object or some other shinanigan.
        }
    }
    // Update is called once per frame

    public void Update()
    {
        //afficher asset
    }

}
