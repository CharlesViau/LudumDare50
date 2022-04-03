using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeBarilComponent : Item
{
    [Header("Unity Setup")]
    public ParticleSystem woodParticles;

    public override void Interact(IInteract person)
    {
        if (person.Inventory.AddItem(Type, 1, out var over))
        {
            Destroy();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Player")) return;
        Interact(collision.gameObject.GetComponent<Player>());
        Destroy();
    }

    private void Destroy()
    {
        Instantiate(woodParticles, transform.position, Quaternion.identity);
        GameObject.Destroy(this);
        
    }

    public void Awake()
    {
        ObjectSpawner.BarrelCounter += 1;

    }

    public void OnDestroy()
    {
        ObjectSpawner.BarrelCounter -= 1;
    }
}
