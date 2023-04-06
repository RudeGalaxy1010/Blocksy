using UnityEngine;

public interface IMoveLimits
{
    Vector3 GetClampedPosition(Vector3 positionToClamp);
}