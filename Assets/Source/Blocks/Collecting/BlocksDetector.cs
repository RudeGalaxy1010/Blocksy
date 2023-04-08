using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BlocksDetector : MonoBehaviour
{
    public event Action<Block> BlockDetected;

    private void Start()
    {
        Collider collider = GetComponent<Collider>();

        if (collider.isTrigger == false)
        {
            collider.isTrigger = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Block block))
        {
            BlockDetected?.Invoke(block);
        }
    }
}
