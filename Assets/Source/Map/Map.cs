using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private Transform _blocksSpawnPoint;
    [SerializeField] private Transform _blocksPlacerSpawnPoint;

    public Vector3 PlayerSpawnPosition => _playerSpawnPoint.position;
    public Transform BlocksSpawnPoint => _blocksSpawnPoint;
    public Vector3 BlocksPlacerSpawnPosition => _blocksPlacerSpawnPoint.position;
}
