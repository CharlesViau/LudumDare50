using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using General;

public class Player : MonoBehaviour, IUpdatable, IInteract
{
    public Inventory Inventory { get; set; }
    [SerializeField] private int inventoryCapacity;

    public void FixedRefresh()
    {
    }

    public void Init()
    {
        Inventory = new Inventory(inventoryCapacity);
    }

    public void PostInit()
    {
    }

    public void Refresh()
    {
    }
}