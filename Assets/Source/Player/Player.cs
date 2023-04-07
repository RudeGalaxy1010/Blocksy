using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private BlocksCollector _blocksCollector;

    private Inventory _inventory;

    public void Construct(IInput input, IMoveLimits moveLimits, Inventory inventory)
    {
        _inventory = inventory;
        _playerController.Construct(input, moveLimits);
        _blocksCollector.Construct(this, _inventory);
    }
}