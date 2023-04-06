using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private InputBootstrap _inputBootstrap;
    [SerializeField] private MapBootstrap _mapBootstrap;
    [SerializeField] private MoveLimitsBootstrap _moveLimitsBootstrap;
    [SerializeField] private BlocksBootstrap _blocksBootstrap;
    [SerializeField] private Player _playerPrefab;

    private IInput _input;
    private Map _map;
    private IMoveLimits _moveLimits;
    private BlocksPool _blocksPool;
    private Player _player;

    private void Start()
    {
        _input = _inputBootstrap.Input;
        _map = _mapBootstrap.Map;
        _moveLimits =_moveLimitsBootstrap.CreateMoveLimitsFor(_map.transform, _playerPrefab.transform.localScale.y);
        _blocksPool = _blocksBootstrap.CreatePool();
        _player = CreatePlayer(_map.SpawnPosition, _input, _moveLimits);
    }

    private Player CreatePlayer(Vector3 at, IInput input, IMoveLimits moveLimits)
    {
        Player player = Instantiate(_playerPrefab, at, Quaternion.identity);
        player.Construct(input, moveLimits);
        return player;
    }
}
