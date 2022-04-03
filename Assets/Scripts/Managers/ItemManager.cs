using General;

namespace Managers
{
    public class ItemManager : Manager<Item, ObjectType, Item.ConstructionArgs, ItemManager>
    {
        protected override string PrefabLocation => "Prefabs/Items";
    }

    public enum ObjectType{
        Wood,
        Hole
    }
}