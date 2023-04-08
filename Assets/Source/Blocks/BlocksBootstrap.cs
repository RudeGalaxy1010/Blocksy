using UnityEngine;

public class BlocksBootstrap : MonoBehaviour
{
    [SerializeField] private BlockPool _blocksPoolPrefab;
    [SerializeField] private BlockSpawner _blocksSpawnerPrefab;
    [SerializeField] private BlockPlacer _blockPlacerPrefab;

    private BlockPool _blockPool;

    private BlockPool BlockPool => _blockPool ??= CreatePool();

    public BlockSpawner CreateSpawnerFor(Map map)
    {
        BlockSpawner blocksSpawner = Instantiate(_blocksSpawnerPrefab);
        blocksSpawner.Construct(BlockPool, map.BlocksSpawnPoint);
        return blocksSpawner;
    }

    public BlockPlacer CreatePlacerFor(Map map)
    {
        BlockPlacer blockPlacer = 
            Instantiate(_blockPlacerPrefab, map.BlocksPlacerSpawnPosition, Quaternion.identity);
        blockPlacer.Construct(BlockPool);
        return blockPlacer;
    }

    private BlockPool CreatePool()
    {
        BlockPool blocksPool = Instantiate(_blocksPoolPrefab);
        blocksPool.Construct();
        return blocksPool;
    }
}
