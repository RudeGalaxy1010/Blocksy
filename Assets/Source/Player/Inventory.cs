using System;
using System.Collections.Generic;

public class Inventory<T>
    where T : class
{
    private const string CantAddItemErrorMessage = "Can't add item";
    private const string CantRemoveItemErrorMessage = "Can't remove item";

    private int _capacity;
    private List<T> _items;

    public Inventory(int capacity)
    {
        _capacity = capacity;
        _items = new List<T>(_capacity);
    }

    public bool CanAdd(T item) => _items.Count < _capacity && _items.Contains(item) == false;
    public bool CanRemove(T item) => _items.Count > 0 && _items.Contains(item);
    public int ItemsCount => _items.Count;

    public void Add(T item)
    {
        if (CanAdd(item) == false)
        {
            throw new ArgumentException($"{CantAddItemErrorMessage} {nameof(item)}");
        }

        _items.Add(item);
    }

    public T TryGetRandomItem()
    {
        return ItemsCount > 0 ? _items[UnityEngine.Random.Range(0, _items.Count)] : null;
    }

    public void Remove(T item)
    {
        if (CanRemove(item) == false)
        {
            throw new ArgumentException($"{CantRemoveItemErrorMessage} {nameof(item)}");
        }

        _items.Remove(item);
    }
}
