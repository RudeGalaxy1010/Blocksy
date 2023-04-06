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
    }

    private void Move(Vector2 direction)
    {
        Vector3 direction3D = new Vector3(direction.x, 0, direction.y);
        _characterController.Move(direction3D * _speed * Time.deltaTime);
        transform.position = _moveLimits.GetClampedPosition(transform.position);
    }
}
