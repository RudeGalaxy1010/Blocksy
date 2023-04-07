using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class CollectableItem : MonoBehaviour 
{
    private Collider _collider;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        if (_collider == null)
        {
            _collider = GetComponent<Collider>();
        }

        if (_rigidbody == null)
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
    }

    public void Grab()
    {
        _collider.enabled = false;
        _rigidbody.useGravity = false;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.isKinematic = true;
    }

    public void Release()
    {
        _collider.enabled = true;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.isKinematic = false;
        _rigidbody.useGravity = true;
    }
}
