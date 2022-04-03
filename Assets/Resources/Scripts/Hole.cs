using UnityEngine;

public class Hole : Item
{
    [SerializeField] private int timePerHole = 3;
    public override void Interact(IInteract person)
    {
        var possible = person.Inventory.RemoveItem(ObjectType.Wood, 1);
        if (!possible) return;
        ObjectSpawner.HoleCounter -= 1;
      
        TimeManager._remainingTime += timePerHole;
        Destroy(this);

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
