using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : Item
{
    public override void Interact(IInteract person)
    {
        bool possible = person.Inventory.RemoveItem(ObjectType.Wood, 1);
        if (possible)
        {
            ObjectSpawner.holeCounter -= 1;
            GameObject.Destroy(this);
        }

    }

    public void Update()
    {
        //afficher l'asset
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Interact(collision.gameObject.GetComponent<Player>());
        }
    }


    // Start is called before the first frame update
}
