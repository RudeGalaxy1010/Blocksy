using UnityEngine;

public class BlocksBootstrap : MonoBehaviour
{
    [SerializeField] private BlocksPool _blocksPoolPrefab;

    public BlocksPool CreatePool()
    {
        BlocksPool blocksPool = Instantiate(_blocksPoolPrefab);
        blocksPool.Construct();
        return blocksPool;
    }
}
