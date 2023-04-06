using UnityEngine;

public class BlocksSpawner : MonoBehaviour
{
    private const int InfiniteLoops = -1;

    [SerializeField] private float _spawnTime;

    private Transform _spawnPoint;
    private BlocksPool _blocksPool;

    public void Construct(BlocksPool blocksPool, Transform spawnPoint)
    {
        _spawnPoint = spawnPoint;
        _blocksPool = blocksPool;
        SpawnInfinite();
    }

    private void SpawnInfinite()
    {
        this.StartTimer(() => CreateBlock(), _spawnTime, InfiniteLoops);
    }

    private void CreateBlock()
    {
        Block block = _blocksPool.Get();
        block.transform.position = _spawnPoint.position;
        block.Construct(_blocksPool);
    }
}
