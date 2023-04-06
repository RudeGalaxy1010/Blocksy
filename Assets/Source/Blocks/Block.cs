using UnityEngine;

public class Block : MonoBehaviour
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
