using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Block : CollectableItem
{
    private BlockPool _pool;

    public void Construct(BlockPool pool)
    {
        _pool = pool;
    }

    public void Destroy()
    {
        _pool.Return(this);
    }
}
