using System.Collections.Generic;
using System.Linq;


public class Inventory
{
    private readonly int _capacity;
    public int Count => content.Sum(couple => couple.Value);

    private Dictionary<Item, int> content;

    public Inventory(int capacity)
    {
        _capacity = capacity;
    }

    public void AddItem(Item item, int quantity)
    {
        var currentSize = Count;
        content[item] += currentSize + quantity <= _capacity ? quantity : _capacity - currentSize;
    }

    public bool RemoveItem(Item item, int quantity)
    {
        if (!content.ContainsKey(item) || content[item] - quantity <= 0) return false;
        content[item] -= quantity;
        return true;
    }
}