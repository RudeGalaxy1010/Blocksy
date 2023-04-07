using System;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class BlocksDetector : MonoBehaviour
{
    public event Action<Block> BlockDetected;

    private void Start()
    {
        SphereCollider collider = GetComponent<SphereCollider>();

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
