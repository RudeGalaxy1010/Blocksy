using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private MoveLimits _moveLimits;

    public Vector3 SpawnPosition => _spawnPoint.position;
    public IMoveLimits MoveLimits => _moveLimits;
}
