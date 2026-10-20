using System;
using GoogleMobileAds.Api;
using UnityEngine;

public class AppOpenAdHandler : MonoBehaviour
{
    private const double AdExpiryHours = 4.0;

    private AppOpenAd _appOpenAd;
    private DateTime _loadTime;
    private Action _pendingCallback;

    /// <summary>
    /// Fires every time a fresh ad successfully finishes loading (including
    /// reloads after each show). AdsManager uses this once, on the very
    /// first load, to trigger the cold-start App Open ad — then unsubscribes.
    /// </summary>
    public event Action OnAdLoadedEvent;

    public bool IsReady =>
        _appOpenAd != null &&
        _appOpenAd.CanShowAd() &&
        (DateTime.UtcNow - _loadTime).TotalHours < AdExpiryHours;

    public void LoadAd()
    {
        DestroyAd();

        AdRequest request = new AdRequest();
        AppOpenAd.Load(AdUnitIds.AppOpen, request, (AppOpenAd ad, LoadAdError error) =>
        {
            if (error != null || ad == null)
            {
                Debug.LogWarning("[AppOpenAdHandler] Load failed: " + error);
                return;
            }

            _appOpenAd = ad;
            _loadTime = DateTime.UtcNow;
            RegisterEvents(ad);
            Debug.Log("[AppOpenAdHandler] Ad loaded.");
            OnAdLoadedEvent?.Invoke();
        });
    }

    /// <summary>
    /// Shows the app open ad if ready. onComplete fires exactly once — whether
    /// the ad was shown and closed, failed to show, or wasn't ready at all —
    /// so the caller (AdsManager, on app resume) always knows when it's safe
    /// to continue normally.
    /// </summary>
    public void Show(Action onComplete = null)
    {
        if (IsReady)
        {
            _pendingCallback = onComplete;
            _appOpenAd.Show();
        }
        else
        {
            Debug.LogWarning("[AppOpenAdHandler] Ad not ready or expired, reloading.");
            LoadAd();
            onComplete?.Invoke();
        }
    }

    private void RegisterEvents(AppOpenAd ad)
    {
        ad.OnAdFullScreenContentClosed += () =>
        {
            // Arrives on a native JNI thread, not Unity's main thread —
            // dispatch before touching LoadAd()/callbacks that may call
            // into Unity APIs (SetActive, scene loads, etc.).
            UnityMainThreadDispatcher.Enqueue(() =>
            {
                Debug.Log("[AppOpenAdHandler] Closed. Loading next ad.");
                LoadAd();
                InvokePendingCallback();
            });
        };

        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            UnityMainThreadDispatcher.Enqueue(() =>
            {
                Debug.LogWarning("[AppOpenAdHandler] Show failed: " + error);
                LoadAd();
                InvokePendingCallback();
            });
        };

        ad.OnAdPaid += (AdValue value) =>
            Debug.Log($"[AppOpenAdHandler] Paid {value.Value} {value.CurrencyCode}");
    }

    private void InvokePendingCallback()
    {
        var cb = _pendingCallback;
        _pendingCallback = null;
        cb?.Invoke();
    }

    public void DestroyAd()
    {
        if (_appOpenAd != null)
        {
            _appOpenAd.Destroy();
            _appOpenAd = null;
        }
    }

    private void OnDestroy() => DestroyAd();
}