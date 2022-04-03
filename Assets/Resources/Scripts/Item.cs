using UnityEngine;


public abstract class Item : MonoBehaviour, IInteractable
{
    [SerializeField]public readonly string Type; 

    public static bool operator ==(Item a, Item b)
    {
        return b != null && a != null && a.Type == b.Type;
    }

    public static bool operator !=(Item a, Item b)
    {
        return b != null && a != null && a.Type != b.Type;
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
            return (base.GetHashCode() * 397) ^ (int) Type;
        }
    }

    public abstract void Interact(IInteract person);
    
}

