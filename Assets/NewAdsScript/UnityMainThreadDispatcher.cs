using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Google Mobile Ads' Android full-screen-content callbacks (OnAdFullScreenContentClosed,
/// OnAdFullScreenContentFailed, etc.) fire directly from a native JNI callback thread, not
/// Unity's main thread. Any Unity API call made from inside those callbacks — including
/// anything a game script does in response, like SetActive or SceneManager.LoadScene — throws
/// "can only be called from the main thread."
///
/// Call UnityMainThreadDispatcher.Enqueue(yourAction) from inside those callbacks instead of
/// running the code directly; it will run safely on the next Update() on the main thread.
///
/// The dispatcher's own GameObject is created eagerly at startup via
/// RuntimeInitializeOnLoadMethod, which Unity guarantees runs on the main thread — so Enqueue()
/// itself, even when called from a background thread, never needs to touch a Unity API (like
/// creating a GameObject) directly. Only queuing/dequeuing a plain C# Action happens there.
/// </summary>
public class UnityMainThreadDispatcher : MonoBehaviour
{
    private static UnityMainThreadDispatcher _instance;
    private static readonly object _lock = new object();
    private static readonly Queue<Action> _queue = new Queue<Action>();

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Bootstrap()
    {
        // Runs on the main thread automatically, before any scene loads —
        // guaranteed well before any ad callback could possibly fire.
        if (_instance != null) return;

        var go = new GameObject("UnityMainThreadDispatcher");
        _instance = go.AddComponent<UnityMainThreadDispatcher>();
        DontDestroyOnLoad(go);
    }

    public static void Enqueue(Action action)
    {
        if (action == null) return;

        if (_instance == null)
        {
            // Should not normally happen since Bootstrap() runs at startup,
            // but guard anyway rather than crash if somehow called too early.
            Debug.LogWarning("[UnityMainThreadDispatcher] Enqueue called before dispatcher initialized — action dropped: " + action.Method.Name);
            return;
        }

        lock (_lock)
        {
            _queue.Enqueue(action);
        }
    }

    private void Update()
    {
        while (true)
        {
            Action action;
            lock (_lock)
            {
                if (_queue.Count == 0) return;
                action = _queue.Dequeue();
            }

            try
            {
                action.Invoke();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}