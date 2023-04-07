using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;

    private Inventory<Block> _inventory;

    public void Construct(IInput input, IMoveLimits moveLimits, Inventory<Block> inventory)
    {
        _inventory = inventory;
        _playerController.Construct(input, moveLimits);
    }
}