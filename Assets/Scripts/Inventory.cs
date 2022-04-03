using System.Collections.Generic;
using System.Linq;


public class Inventory
{
    private readonly int _capacity;
    public int Count => _content.Sum(couple => couple.Value);

    private Dictionary<ObjectType, int> _content;

    public Inventory(int capacity)
    {
        _capacity = capacity;
    }

    public bool AddItem(ObjectType item, int quantity, out int over)
    {
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

        return true;
    }

    public bool RemoveItem(ObjectType item, int quantity)
    {
        if (!_content.ContainsKey(item) || _content[item] - quantity <= 0) return false;
        _content[item] -= quantity;
        return true;
    }

    public int GetCountSpecificItem(ObjectType type)
    {
        return !_content.ContainsKey(type) ? 0 : _content[type];
    }
}