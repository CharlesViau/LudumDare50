using General;
using UnityEngine;

public abstract class Item : MonoBehaviour, IUpdatable, IInteractable, ICreatable<Item.ConstructionArgs>, IPoolable
{
    [SerializeField]public readonly ObjectType Type;
    
    public class ConstructionArgs : IArgs
    {
        public Vector3 SpawningPosition;
        public ConstructionArgs(Vector3 spawningPosition)
        {
            SpawningPosition = spawningPosition;
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

    public abstract void Interact(IInteract person);
    
}

