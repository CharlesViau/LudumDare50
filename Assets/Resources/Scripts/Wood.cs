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
            GameObject.Destroy(this);
        }
    }
    // Update is called once per frame

    public void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Interact(collision.gameObject.GetComponent<Player>());
        }
    }

}
