using UnityEngine;

public class ExplodeBarilComponent : Item
{
    [Header("Unity Setup")]
    public ParticleSystem woodParticles;

    public override void Interact(IInteract person)
    {
        
        if (!person.Inventory.AddItem(ItemType.Wood, 1, out var over)) return;
        UIBehaviour.staticWoodCount += 1;
        Destroy();
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
        Destroy(gameObject);
        
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
