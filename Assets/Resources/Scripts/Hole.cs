using UnityEngine;

public class Hole : Item
{
    [SerializeField] private int timePerHole = 3;
    public override void Interact(IInteract person)
    {
        var possible = person.Inventory.RemoveItem(ObjectType.Wood, 1);
        if (!possible) return;
        ObjectSpawner.HoleCounter -= 1;
      
        TimeManager.CurrentTime += timePerHole;
        Destroy(this);

    }
    
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Interact(collision.gameObject.GetComponent<Player>());
        }
    }

    public void Awake()
    {
        ObjectSpawner.HoleCounter += 1;
    }


    // Start is called before the first frame update
}
