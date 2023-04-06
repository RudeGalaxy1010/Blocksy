using UnityEngine;

public class MapBootstrap : MonoBehaviour
{
    [SerializeField] private Map _mapPrefab;

    private Map _map;

    public Map Map => _map ??= CreateMap(Vector3.zero);

    private Map CreateMap(Vector3 at)
    {
        return Instantiate(_mapPrefab, at, Quaternion.identity);
    }
}
