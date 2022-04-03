using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : Item
{
    [SerializeField] int timePerHole = 3;
    public override void Interact(IInteract person)
    {
        bool possible = person.Inventory.RemoveItem(ObjectType.Wood, 1);
        if (possible)
        {
            ObjectSpawner.holeCounter -= 1;
            //make something pop up when time is added?
            TimeManager.currentTime += timePerHole;
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

    public void Awake()
    {
        ObjectSpawner.holeCounter += 1;
    }


    // Start is called before the first frame update
}
