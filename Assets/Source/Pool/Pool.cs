using System.Collections.Generic;
using UnityEngine;

public class Pool<T> : MonoBehaviour
    where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    [SerializeField] private int _startCount;

    private List<T> _objects;

    public void Construct()
    {
        _objects = new List<T>();

        for (int i = 0; i < _startCount; i++)
        {
            CreateObject();
        }
    }

    public T Get()
    {
        T obj = null;

        for (int i = 0; i < _objects.Count; i++)
        {
            if (_objects[i].gameObject.activeInHierarchy == false)
            {
                obj = _objects[i];
                break;
            }
        }

        if (obj == null)
        {
            obj = CreateObject();
        }
        
        _objects.Remove(obj);
        obj.transform.SetParent(null);
        obj.gameObject.SetActive(true);

        return obj;
    }

    public void Return(T obj)
    {
        obj.transform.SetParent(transform);
        obj.gameObject.SetActive(false);
        _objects.Add(obj);
    }

    private T CreateObject()
    {
        T obj = Instantiate(_prefab, transform.position, Quaternion.identity, transform);
        obj.gameObject.SetActive(false);
        _objects.Add(obj);
        return obj;
    }
}
