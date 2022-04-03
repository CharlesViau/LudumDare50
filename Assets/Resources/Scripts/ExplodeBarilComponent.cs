using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeBarilComponent : Item
{
    [Header("Unity Setup")]
    public ParticleSystem woodParticles;

    public override void Interact(IInteract person)
    {
        if (person.Inventory.AddItem(this.Type, 1, out var over))
        {
            Destroy();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Interact(collision.gameObject.GetComponent<Player>());
            Destroy();
        }
    }

    public void Destroy()
    {
        Instantiate(woodParticles, transform.position, Quaternion.identity);
        GameObject.Destroy(this);
        
        


    }

    public void Awake()
    {
        ObjectSpawner.barrelCounter += 1;

    }

    public void OnDestroy()
    {
        ObjectSpawner.barrelCounter -= 1;
    }
}
