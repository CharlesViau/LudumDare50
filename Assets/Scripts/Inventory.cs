using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    public int capacity;

    public Dictionary<Item, int> content;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int Size()
    {
        int size = 0;
        foreach (KeyValuePair<Item, int> couple in content)
        {
            size += couple.Value;
        }
        return size;
    }


    public void AddItem(Item item, int quantity)
    {
        int currentSize = Size();
        if (currentSize + quantity <= capacity)
        {
            content[item] += quantity;
        }
        else
        {
            content[item] += capacity - currentSize;
        }
    }

    public void RemoveItem(Item item, int quantity)
    {
        if (IsIn(item)){
            if (content[item] - quantity <= 0)
            {
                content[item] = 0;
            }
            else
            {
                content[item] -= quantity;
            }
        }
    }

    public bool IsIn(Item item)
    {
        bool isin = false;
        foreach (KeyValuePair<Item, int> couple in content)
        {
            if (couple.Value.Equals(item))
            {
                isin = true;
            }
        }
        return isin;
    }
}
