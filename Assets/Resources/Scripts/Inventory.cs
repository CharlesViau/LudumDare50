using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Inventory
{
    private readonly int _capacity;
    public int Count => _content.Sum(couple => couple.Value);

    public Dictionary<string, int> _content;

    public Inventory(int capacity)
    {
        _capacity = capacity;
        _content = new Dictionary<string, int>();
    }

    public bool AddItem(string item, int quantity, out int over)
    {
        Debug.Log(Count);
        if (Count >= _capacity)
        {
            over = 0;
            return false;
        }
        
        if (!_content.ContainsKey(item))
        {
            _content.Add(item, 0);
        }

        if (Count + quantity <= _capacity)
        {
            
            _content[item] += quantity;
            over = 0;
            return true;
        }
        over = Count + quantity - _capacity;
        _content[item] += _capacity - Count;
        Debug.Log(Count);
        return true;
    }

    public bool RemoveItem(string item, int quantity)
    {
        if (!_content.ContainsKey(item) || _content[item] - quantity <= 0) return false;
        _content[item] -= quantity;
        return true;
    }

    public int GetCountSpecificItem(string type)
    {
        if (!_content.ContainsKey(type))
            return 0;
        return _content[type];
    }
}