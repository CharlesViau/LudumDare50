using UnityEngine;

public class Hole : Item
{
    [SerializeField] private int timePerHole = 3;
    
    public override void Interact(IInteract person)
    {
        if (!person.Inventory.RemoveItem(ItemType.Wood, 0)) return;
        UIBehaviour.staticWoodCount -= 1;
        ObjectSpawner.HoleCounter -= 1;
        TimeManager._remainingTime += timePerHole;
        
        Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Interact(other.gameObject.GetComponent<Player>());
        }
    }

    public void Awake()
    {
        ObjectSpawner.HoleCounter += 1;
    }


    // Start is called before the first frame update
}
