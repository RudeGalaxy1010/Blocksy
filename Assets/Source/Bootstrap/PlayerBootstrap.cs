using UnityEngine;

public class PlayerBootstrap : MonoBehaviour
{
    [SerializeField] private MobileInput _input;
    [SerializeField] private PlayerController _playerController;

    private void Start()
    {
        _playerController.Construct(_input);
    }
}
