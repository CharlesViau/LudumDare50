using UnityEngine;


public abstract class Item : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemType itemType; 

    public static bool operator ==(Item a, Item b)
    {
        return b != null && a != null && a.itemType == b.itemType;
    }

    public static bool operator !=(Item a, Item b)
    {
        return b != null && a != null && a.itemType != b.itemType;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((Item) obj);
    }
    
    public override int GetHashCode()
    {
        unchecked
        {
            //return (base.GetHashCode() * 397) ^ (int) Type;
            return 0;
        }
    }

    public abstract void Interact(IInteract person);
    
}

public enum ItemType
{
    Wood,
    Hole,
    Hammer
}