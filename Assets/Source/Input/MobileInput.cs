using UnityEngine;

public class MobileInput : MonoBehaviour, IInput
{
    [SerializeField] private Joystick _joystick;

    public Vector2 Velocity => _joystick.Direction;
}
