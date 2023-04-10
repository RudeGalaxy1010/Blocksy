using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Block : CollectableItem
{
    private BlockPool _pool;
    private Vector3 _baseScale;

    public void Construct(BlockPool pool)
    {
        _baseScale = transform.localScale;
        _pool = pool;
    }

    public void ResetScale()
    {
        transform.localScale = _baseScale;
    }

    public void Destroy()
    {
        _pool.Return(this);
    }
}
