using UnityEngine;

public interface IMoveLimits
{
    void Construct(Transform walkable, float _maxHeight);
    Vector3 GetClampedPosition(Vector3 positionToClamp);
}