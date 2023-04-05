using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CharacterController _characterController;
    [Header("Parameters")]
    [SerializeField] private float _speed;

    private IInput _input;

    public void Construct(IInput input)
    {
        _input = input;
    }

    private void Update()
    {
        if (_input == null || _input.Velocity == Vector2.zero)
        {
            return;
        }

        Move(_input.Velocity);
    }

    private void Move(Vector2 direction)
    {
        Vector3 direction3D = new Vector3(direction.x, 0, direction.y);
        _characterController.Move(direction3D * _speed * Time.deltaTime);
    }
}
