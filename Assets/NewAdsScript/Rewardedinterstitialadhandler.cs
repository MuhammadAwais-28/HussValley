using System;
using GoogleMobileAds.Api;
using UnityEngine;


public class RewardedInterstitialAdHandler : MonoBehaviour
{
    private RewardedInterstitialAd _ad;
    private Action _pendingCompleteCallback;
    private Action _pendingRewardCallback;

    public bool IsReady => _ad != null && _ad.CanShowAd();

    public void LoadAd()
    {
        DestroyAd();

        AdRequest request = new AdRequest();
        RewardedInterstitialAd.Load(AdUnitIds.RewardedInterstitial, request, (RewardedInterstitialAd ad, LoadAdError error) =>
        {
            if (error != null || ad == null)
            {
                Debug.LogWarning("[RewardedInterstitialAdHandler] Load failed: " + error);
                return;
            }

            _ad = ad;
            RegisterEvents(ad);
            Debug.Log("[RewardedInterstitialAdHandler] Ad loaded.");
        });
    }

    /// <summary>
    /// Shows the rewarded interstitial if ready. onComplete fires exactly once —
    /// whether the ad was shown and closed, failed to show, or wasn't ready at
    /// all — so callers (e.g. a Play button) can always safely proceed.
    /// onUserRewarded fires only if the player watches the ad to completion.
    /// </summary>
    public void Show(Action onComplete = null, Action onUserRewarded = null)
    {
        if (IsReady)
        {
            _pendingCompleteCallback = onComplete;
            _pendingRewardCallback = onUserRewarded;

            _ad.Show((Reward reward) =>
            {
                Debug.Log($"[RewardedInterstitialAdHandler] User rewarded: {reward.Amount} {reward.Type}");
                var rewardCb = _pendingRewardCallback;
                _pendingRewardCallback = null;
                // Reward callback can also arrive off the main thread — dispatch it too.
                UnityMainThreadDispatcher.Enqueue(() => rewardCb?.Invoke());
            });
        }
        else
        {
            Debug.LogWarning("[RewardedInterstitialAdHandler] Ad not ready, skipping show and reloading.");
            LoadAd();
            onComplete?.Invoke();
        }
    }

    private void RegisterEvents(RewardedInterstitialAd ad)
    {
        ad.OnAdFullScreenContentClosed += () =>
        {
            // This callback arrives on a native JNI thread, not Unity's main
            // thread — any Unity API work (including whatever onComplete
            // ends up calling, like SetActive or loading a scene) must be
            // dispatched back to the main thread or it throws.
            UnityMainThreadDispatcher.Enqueue(() =>
            {
                Debug.Log("[RewardedInterstitialAdHandler] Closed. Loading next ad.");
                LoadAd();
                InvokePendingComplete();
            });
        };

        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            UnityMainThreadDispatcher.Enqueue(() =>
            {
                Debug.LogWarning("[RewardedInterstitialAdHandler] Show failed: " + error);
                LoadAd();
                InvokePendingComplete();
            });
        };

        ad.OnAdPaid += (AdValue value) =>
            Debug.Log($"[RewardedInterstitialAdHandler] Paid {value.Value} {value.CurrencyCode}");
    }

    private void InvokePendingComplete()
    {
        var cb = _pendingCompleteCallback;
        _pendingCompleteCallback = null;
        cb?.Invoke();
    }

    public void DestroyAd()
    {
        if (_ad != null)
        {
            _ad.Destroy();
            _ad = null;
        }
    }

    private void OnDestroy() => DestroyAd();
}