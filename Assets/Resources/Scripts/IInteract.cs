public interface IInteract
{
    // Start is called before the first frame update

    public abstract void Interact();
    Inventory Inventory{ get; set; }
}



public interface IInteractable
{
    public abstract void Interact(IInteract person);
}