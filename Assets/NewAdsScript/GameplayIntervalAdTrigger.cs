using System.Collections;
using UnityEngine;

/// <summary>
/// Attach to any GameObject in GameplayScene (e.g. a "GameplayAds" empty
/// object, or your existing gameplay manager). Shows an interstitial every
/// Interval Seconds while this component is active. Automatically stops when
/// the scene unloads (this object is destroyed) — no manual cleanup needed.
/// </summary>
public class GameplayIntervalAdTrigger : MonoBehaviour
{
    [Tooltip("How often to show an interstitial, in seconds.")]
    public float intervalSeconds = 30f;

    private Coroutine _loopCoroutine;

    private void OnEnable()
    {
        _loopCoroutine = StartCoroutine(AdLoop());
    }

    private void OnDisable()
    {
        if (_loopCoroutine != null)
        {
            StopCoroutine(_loopCoroutine);
            _loopCoroutine = null;
        }
    }

    private IEnumerator AdLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(intervalSeconds);

            bool adComplete = false;

            if (AdsManager.Instance != null)
            {
                AdsManager.Instance.ShowInterstitial(() => adComplete = true);
            }
            else
            {
                adComplete = true;
            }

            // Don't start counting the next interval until this attempt is
            // fully done (ad shown-and-closed, or skipped because it wasn't
            // available/blocked) — this prevents two shows from ever stacking.
            yield return new WaitUntil(() => adComplete);
        }
    }
}