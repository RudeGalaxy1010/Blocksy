using UnityEngine;

public class MoveLimitsBootstrap : MonoBehaviour
{
    [SerializeField] private MoveLimits _moveLimitsPrefab;

    public IMoveLimits CreateMoveLimitsFor(Transform walkable, float _maxHeight)
    {
        IMoveLimits moveLimits = 
            Instantiate(_moveLimitsPrefab, walkable.transform.position, Quaternion.identity, walkable);
        moveLimits.Construct(walkable, _maxHeight);
        return moveLimits;
    }
}
