using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MonobehaviourTimer
{
    private static Dictionary<MonoBehaviour, List<Coroutine>> _timers;

    static MonobehaviourTimer()
    {
        _timers = new Dictionary<MonoBehaviour, List<Coroutine>>();
    }

    public static Timer StartTimer(this MonoBehaviour source, Action callback, float time, int loops)
    {
        Coroutine coroutine = null;
        coroutine = source.StartCoroutine(
            ProcessTimer(callback, time, loops,
                () => RemoveTimer(source, coroutine)));

        if (_timers.ContainsKey(source))
        {
            _timers[source].Add(coroutine);
        }
        else
        {
            _timers.Add(source, new List<Coroutine>() { coroutine });
        }

        return new Timer(source, coroutine);
    }

    public static bool HasActiveTimer(this MonoBehaviour source)
    {
        return _timers.ContainsKey(source);
    }

    public static void StopTimer(Timer timer)
    {
        RemoveTimer(timer.Source, timer.Coroutine);
    }

    public static void StopAllTimers(this MonoBehaviour source)
    {
        if (_timers.ContainsKey(source) == false)
        {
            return;
        }

        for (int i = 0; i < _timers[source].Count; i++)
        {
            RemoveTimer(source, _timers[source][i]);
        }
    }

    private static IEnumerator ProcessTimer(Action callback, float time, int loops, Action removeAction)
    {
        bool isInfinite = loops < 0;

        do
        {
            if (isInfinite == false)
            {
                loops--;
            }

            yield return new WaitForSeconds(time);
            callback?.Invoke();
        }
        while (isInfinite || loops > 0);

        removeAction.Invoke();
    }

    private static void RemoveTimer(MonoBehaviour source, Coroutine coroutine)
    {
        if (_timers.ContainsKey(source) == false)
        {
            return;
        }

        source.StopCoroutine(coroutine);
        _timers[source].Remove(coroutine);

        if (_timers[source].Count == 0)
        {
            _timers.Remove(source);
        }
    }
}
