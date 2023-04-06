using UnityEngine;

public class Timer
{
    public readonly MonoBehaviour Source;
    public readonly Coroutine Coroutine;

    public Timer(MonoBehaviour source, Coroutine coroutine)
    {
        Source = source;
        Coroutine = coroutine;
    }
}
