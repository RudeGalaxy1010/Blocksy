using UnityEngine;

public class BlocksBootstrap : MonoBehaviour
{
    [SerializeField] private BlocksPool _blocksPoolPrefab;
    [SerializeField] private BlocksSpawner _blocksSpawnerPrefab;

    public BlocksSpawner CreateSpawnerFor(Map map)
    {
        BlocksPool blocksPool = CreatePool();
        BlocksSpawner blocksSpawner = Instantiate(_blocksSpawnerPrefab);
        blocksSpawner.Construct(blocksPool, map.BlocksSpawnPoint);
        return blocksSpawner;
    }

    private BlocksPool CreatePool()
    {
        BlocksPool blocksPool = Instantiate(_blocksPoolPrefab);
        blocksPool.Construct();
        return blocksPool;
    }
}
