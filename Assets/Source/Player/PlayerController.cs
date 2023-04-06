using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CharacterController _characterController;
    [Header("Parameters")]
    [SerializeField] private float _speed;

    private IInput _input;
    private IMoveLimits _moveLimits;

    public void Construct(IInput input, IMoveLimits moveLimits)
    {
        _moveLimits = moveLimits;
        _input = input;
    }

    private void Update()
    {
        if (_input == null || _input.Velocity == Vector2.zero)
        {
            return;
        }

        Move(_input.Velocity);
        Rotate(_input.Velocity);
    }

    private void Move(Vector2 direction)
    {
        _characterController.Move(direction.To3D() * _speed * Time.deltaTime);
        transform.position = _moveLimits.GetClampedPosition(transform.position);
    }

    private void Rotate(Vector2 lookDirection)
    {
        transform.LookAt(transform.position + lookDirection.To3D());
    }
}
