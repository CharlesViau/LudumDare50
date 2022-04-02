using General;
using UnityEngine;

public class Item : MonoBehaviour, IUpdatable, IInteractable, ICreatable<Item.ConstructionArgs>, IPoolable
{
    [SerializeField]public readonly ItemType Type;
    
    public class ConstructionArgs : IArgs
    {
        public Vector3 SpawningPosition;
        public ConstructionArgs(Vector3 spawningPosition)
        {
            SpawningPosition = spawningPosition;
        }
    }
    public void Interact(IInteract person)
    {
        if (person.Inventory.AddItem(this.Type, 1, out var over))
        {
            //TODO delete game object or some other shinanigan.
        }
    }

    public static bool operator ==(Item a, Item b)
    {
        return b != null && a != null && a.Type == b.Type;
    }

    public static bool operator !=(Item a, Item b)
    {
        return b != null && a != null && a.Type != b.Type;
    }

    public void Construct(ConstructionArgs constructionArgs)
    {
        transform.position = constructionArgs.SpawningPosition;
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
    
    public void Pool()
    {
        throw new System.NotImplementedException();
    }

    public void Depool()
    {
        throw new System.NotImplementedException();
    }

    public void Init()
    {
        throw new System.NotImplementedException();
    }

    public void PostInit()
    {
        throw new System.NotImplementedException();
    }

    public void Refresh()
    {
        throw new System.NotImplementedException();
    }

    public void FixedRefresh()
    {
        throw new System.NotImplementedException();
    }
}

public enum ItemType
{
    Wood
}