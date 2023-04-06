using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolObject<T>
    where T : MonoBehaviour
{
    void SetPool(Pool<T> pool);
    void Return();
}
