using System;
using System.Collections.Generic;

public class Inventory
{
    private const string CantAddItemErrorMessage = "Can't add item";
    private const string CantRemoveItemErrorMessage = "Can't remove item";
    private const int OneItem = 1;

    private int _capacity;
    private Dictionary<Type, int> _items;

    public Inventory(int capacity)
    {
        _capacity = capacity;
        _items = new Dictionary<Type, int>();
    }

    public bool CanAdd(Type item, int value = 1) => _items.ContainsKey(item) == false || _items[item] + value <= _capacity;
    public bool CanRemove(Type item, int value = 1) => _items.ContainsKey(item) && _items[item] - value >= 0;
    public int ItemsCount(Type item) => _items.ContainsKey(item) ? _items[item] : 0;

    public void Add(Type item)
    {
        if (CanAdd(item) == false)
        {
            throw new ArgumentException($"{CantAddItemErrorMessage} {nameof(item)}");
        }

        if (_items.ContainsKey(item) == false)
        {
            _items.Add(item, OneItem);
        }
        else
        {
            _items[item] += OneItem;
        }
    }

    public void Remove(Type item)
    {
        if (CanRemove(item) == false)
        {
            throw new ArgumentException($"{CantRemoveItemErrorMessage} {nameof(item)}");
        }

        _items[item] -= OneItem;

        if (_items[item] == 0)
        {
            _items.Remove(item);
        }
    }
}
