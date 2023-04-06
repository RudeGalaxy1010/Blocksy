using UnityEngine;

public class MoveLimits : MonoBehaviour, IMoveLimits
{
    private Vector3 _limits;
    private Vector3 _offset;

    private Vector3 _halfLimits => _limits / 2f;
    private Vector3 CenterPosition => transform.position + _offset;
    private Vector3 leftBottomLimits => CenterPosition - _halfLimits; // Nearest point
    private Vector3 rightUpperLimits => CenterPosition + _halfLimits; // Farest point

    public void Construct(Transform walkable, float _maxHeight)
    {
        _limits = new Vector3(walkable.localScale.x, _maxHeight, walkable.localScale.z);
        float yOffset = (_maxHeight + walkable.localScale.y) / 2f;
        _offset = new Vector3(0, yOffset, 0);
    }

    public Vector3 GetClampedPosition(Vector3 positionToClamp)
    {
        return new Vector3
        (
            Mathf.Clamp(positionToClamp.x, leftBottomLimits.x, rightUpperLimits.x),
            Mathf.Clamp(positionToClamp.y, leftBottomLimits.y, rightUpperLimits.y),
            Mathf.Clamp(positionToClamp.z, leftBottomLimits.z, rightUpperLimits.z)
        );
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(CenterPosition, _limits);
    }
}
