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
    private BlockSpawner _blocksSpawner;
    private BlockPlacer _blocksPlacer;
    private Player _player;

    private void Start()
    {
        _input = _inputBootstrap.Input;
        _map = _mapBootstrap.Map;
        _moveLimits =_moveLimitsBootstrap.CreateMoveLimitsFor(_map.transform, _playerPrefab.transform.localScale.y);
        _blocksSpawner = _blocksBootstrap.CreateSpawnerFor(_map);
        _blocksPlacer = _blocksBootstrap.CreatePlacerFor(_map);
        _player = CreatePlayer(_map.PlayerSpawnPosition, _input, _moveLimits, new Inventory(10));
    }

    private Player CreatePlayer(Vector3 at, IInput input, IMoveLimits moveLimits, Inventory inventory)
    {
        Player player = Instantiate(_playerPrefab, at, Quaternion.identity);
        player.Construct(input, moveLimits, inventory);
        return player;
    }
}
