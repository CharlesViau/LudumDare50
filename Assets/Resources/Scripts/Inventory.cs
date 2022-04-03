using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Inventory
{
    private readonly int _capacity;
    private int Count => _content.Sum(couple => couple.Value);

    private readonly Dictionary<ItemType, int> _content;

    public Inventory(int capacity)
    {
        _capacity = capacity;
        _content = new Dictionary<ItemType, int>();
    }

    public bool AddItem(ItemType item, int quantity, out int over)
    {
        Debug.Log("Attempt to add");
        Debug.Log(Count);
        if (Count >= _capacity)
        {
            over = 0;
            return false;
        }
        
        if (!_content.ContainsKey(item))
        {
            Debug.Log("Create Key " + item);
            _content.Add(item, 0);
        }

        if (Count + quantity <= _capacity)
        {
            
            _content[item] += quantity;
            Debug.Log(_content[item]);
            over = 0;
            return true;
        }
        over = Count + quantity - _capacity;
        _content[item] += _capacity - Count;
        Debug.Log(Count);
        return true;
    }

    public bool RemoveItem(ItemType item, int quantity)
    {
        if (!_content.ContainsKey(item) || _content[item] - quantity <= 0) return false;
        _content[item] -= quantity;
        return true;
    }

    public int GetCountSpecificItem(ItemType type)
    {
        return !_content.ContainsKey(type) ? 0 : _content[type];
    }
}