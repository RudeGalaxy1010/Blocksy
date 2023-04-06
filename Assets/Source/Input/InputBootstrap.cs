using UnityEngine;

public class InputBootstrap : MonoBehaviour
{
    [SerializeField] private MobileInput _mobileInputPrefab;

    private IInput _input;

    public IInput Input => _input ??= CreateInput();

    private IInput CreateInput()
    {
        return Instantiate(_mobileInputPrefab);
    }
}
