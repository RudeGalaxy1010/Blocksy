using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;

    public Vector3 SpawnPosition => _spawnPoint.position;
}
