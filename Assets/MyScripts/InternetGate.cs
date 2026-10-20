using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class InternetGate : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private string checkUrl = "https://www.google.com/generate_204";
    [SerializeField] private float checkInterval = 5f;
    [SerializeField] private float timeoutSeconds = 5f;

    [Header("UI")]
    [SerializeField] private GameObject noInternetPanel; // full-screen overlay with "No internet connection" text + Retry button

    public static bool IsOnline { get; private set; }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (noInternetPanel != null) noInternetPanel.SetActive(true); // block immediately, before first check even runs
        StartCoroutine(CheckLoop());
    }

    private IEnumerator CheckLoop()
    {
        while (true)
        {
            yield return CheckOnce();
            yield return new WaitForSecondsRealtime(checkInterval);
        }
    }

    public void RetryNow()
    {
        StopAllCoroutines();
        StartCoroutine(CheckLoop());
    }

    private IEnumerator CheckOnce()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            SetOnline(false);
            yield break;
        }

        using (UnityWebRequest req = UnityWebRequest.Head(checkUrl))
        {
            req.timeout = (int)timeoutSeconds;
            yield return req.SendWebRequest();
            SetOnline(req.result == UnityWebRequest.Result.Success);
        }
    }

    private void SetOnline(bool online)
    {
        IsOnline = online;
        if (noInternetPanel != null) noInternetPanel.gameObject.SetActive(!online);
        Time.timeScale = online ? 1f : 0f; // pause the game while offline
        AudioListener.pause = !online;
    }
}