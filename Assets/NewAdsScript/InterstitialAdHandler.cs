using System;
using GoogleMobileAds.Api;
using UnityEngine;


public class InterstitialAdHandler : MonoBehaviour
{
    private InterstitialAd _interstitialAd;
    private Action _pendingCallback;

    public bool IsReady => _interstitialAd != null && _interstitialAd.CanShowAd();

    public void LoadAd()
    {
        DestroyAd();

        AdRequest request = new AdRequest();
        InterstitialAd.Load(AdUnitIds.Interstitial, request, (InterstitialAd ad, LoadAdError error) =>
        {
            if (error != null || ad == null)
            {
                Debug.LogWarning("[InterstitialAdHandler] Load failed: " + error);
                return;
            }

            _interstitialAd = ad;
            RegisterEvents(ad);
            Debug.Log("[InterstitialAdHandler] Ad loaded.");
        });
    }

    /// <summary>
    /// Shows the interstitial if ready. onComplete fires once, whether the ad
    /// was shown and closed, failed to show, or wasn't ready at all — so callers
    /// (e.g. a Play button) can safely proceed either way.
    /// </summary>
    public void Show(Action onComplete = null)
    {
        if (IsReady)
        {
            _pendingCallback = onComplete;
            _interstitialAd.Show();
        }
        else
        {
            Debug.LogWarning("[InterstitialAdHandler] Ad not ready, skipping show and reloading.");
            LoadAd();
            onComplete?.Invoke();
        }
    }

    private void RegisterEvents(InterstitialAd ad)
    {
        ad.OnAdFullScreenContentClosed += () =>
        {
            // Arrives on a native JNI thread, not Unity's main thread —
            // dispatch before touching LoadAd()/callbacks that may call
            // into Unity APIs (SetActive, scene loads, etc.).
            UnityMainThreadDispatcher.Enqueue(() =>
            {
                Debug.Log("[InterstitialAdHandler] Closed. Loading next ad.");
                LoadAd();
                InvokePendingCallback();
            });
        };

        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            UnityMainThreadDispatcher.Enqueue(() =>
            {
                Debug.LogWarning("[InterstitialAdHandler] Show failed: " + error);
                LoadAd();
                InvokePendingCallback();
            });
        };

        ad.OnAdPaid += (AdValue value) =>
            Debug.Log($"[InterstitialAdHandler] Paid {value.Value} {value.CurrencyCode}");
    }

    private void InvokePendingCallback()
    {
        var callback = _pendingCallback;
        _pendingCallback = null;
        callback?.Invoke();
    }

    public void DestroyAd()
    {
        if (_interstitialAd != null)
        {
            _interstitialAd.Destroy();
            _interstitialAd = null;
        }
    }

    private void OnDestroy() => DestroyAd();
}