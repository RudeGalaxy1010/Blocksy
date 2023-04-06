using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;

    public void Construct(IInput input, IMoveLimits moveLimits)
    {
        _playerController.Construct(input, moveLimits);
    }
}