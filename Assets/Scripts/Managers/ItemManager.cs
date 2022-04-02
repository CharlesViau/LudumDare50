using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using General;

public class ItemManager : Manager<Item, ObjectType, Item.ConstructionArgs, ItemManager>
{
    // Start is called before the first frame update
    protected override string PrefabLocation => throw new System.NotImplementedException();

    //
}

public enum ObjectType{
    Wood,
    Hole
}