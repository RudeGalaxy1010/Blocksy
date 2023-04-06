using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _blocksSpawnPoint;

    public Vector3 SpawnPosition => _spawnPoint.position;
    public Transform BlocksSpawnPoint => _blocksSpawnPoint;
}
