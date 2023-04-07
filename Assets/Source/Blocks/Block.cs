using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Block : CollectableItem
{
    private BlocksPool _pool;

    public void Construct(BlocksPool pool)
    {
        _pool = pool;
    }

    public void Destroy()
    {
        _pool.Return(this);
    }
}
