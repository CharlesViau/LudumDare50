using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    public string id;
    public Item(string itemId)
    {
        id = itemId;
    }
    public void Interact(Player player)
    {
        //picking up
        player.inventory.AddItem(this, 1);
        //TODO: destroy on the
        
    }

    public bool Equals(Item other)
    {
        return id == other.id;
    }
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
