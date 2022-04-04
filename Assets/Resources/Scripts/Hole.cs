using System;
using UnityEngine;

public class Hole : Item
{
    [SerializeField] private int timePerHole = 3;
    [SerializeField] GameObject DestructionSound;
    
    public override void Interact(IInteract person)
    {
        if (!person.Inventory.RemoveItem(ItemType.Wood, 1)) return;
        UIBehaviour.staticWoodCount -= 1;
        ObjectSpawner.HoleCounter -= 1;
        TimeManager._remainingTime += timePerHole;
        Instantiate(DestructionSound);
        Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        Interact(other.gameObject.GetComponent<Player>());
    }

    public void Awake()
    {
        ObjectSpawner.HoleCounter += 1;
    }
    


    // Start is called before the first frame update
}
