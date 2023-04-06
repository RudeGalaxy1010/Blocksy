using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private InputBootstrap _inputBootstrap;
    [SerializeField] private MapBootstrap _mapBootstrap;
    [SerializeField] private Player _playerPrefab;

    private IInput _input;
    private Map _map;
    private Player _player;

    private void Start()
    {
        _input = _inputBootstrap.Input;
        _map = _mapBootstrap.Map;
        _player = CreatePlayer(_map.SpawnPosition, _input, _map.MoveLimits);
    }

    private Player CreatePlayer(Vector3 at, IInput input, IMoveLimits moveLimits)
    {
        Player player = Instantiate(_playerPrefab, at, Quaternion.identity);
        player.Construct(input, moveLimits);
        return player;
    }
}
