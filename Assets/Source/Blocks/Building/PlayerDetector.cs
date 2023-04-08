using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlayerDetector : MonoBehaviour
{
    private Player _player;

    public Player Player => _player;

    private void Start()
    {
        Collider collider = GetComponent<Collider>();

        if (collider.isTrigger == false)
        {
            collider.isTrigger = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player) && _player == null)
        {
            _player = player;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player) && _player == player)
        {
            _player = null;
        }
    }
}
