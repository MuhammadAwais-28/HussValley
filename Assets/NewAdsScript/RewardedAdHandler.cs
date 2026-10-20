using System;
using GoogleMobileAds.Api;
using UnityEngine;


public class RewardedAdHandler : MonoBehaviour
{
    private RewardedAd _rewardedAd;
    private Action _pendingCompleteCallback;

    public bool IsReady => _rewardedAd != null && _rewardedAd.CanShowAd();

    public void LoadAd()
    {
        DestroyAd();

        AdRequest request = new AdRequest();
        RewardedAd.Load(AdUnitIds.Rewarded, request, (RewardedAd ad, LoadAdError error) =>
        {
            if (error != null || ad == null)
            {
                Debug.LogWarning("[RewardedAdHandler] Load failed: " + error);
                return;
            }

            _rewardedAd = ad;
            RegisterEvents(ad);
            Debug.Log("[RewardedAdHandler] Ad loaded.");
        });
    }

    /// <summary>
    /// Shows the rewarded ad if ready. onComplete fires exactly once —
    /// whether the ad was shown and closed, failed to show, or wasn't ready
    /// at all — so callers (e.g. a Play button) can always safely proceed.
    /// onUserRewarded fires only if the player watches the ad to completion.
    /// </summary>
    public void Show(Action onComplete = null, Action onUserRewarded = null)
    {
        if (IsReady)
        {
            _pendingCompleteCallback = onComplete;

            _rewardedAd.Show((Reward reward) =>
            {
                Debug.Log($"[RewardedAdHandler] User rewarded: {reward.Amount} {reward.Type}");
                onUserRewarded?.Invoke();
            });
        }
        else
        {
            Debug.LogWarning("[RewardedAdHandler] Ad not ready, skipping show and reloading.");
            LoadAd();
            onComplete?.Invoke();
        }
    }

    private void RegisterEvents(RewardedAd ad)
    {
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("[RewardedAdHandler] Closed. Loading next ad.");
            LoadAd();
            InvokePendingComplete();
        };

        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogWarning("[RewardedAdHandler] Show failed: " + error);
            LoadAd();
            InvokePendingComplete();
        };

        ad.OnAdPaid += (AdValue value) =>
            Debug.Log($"[RewardedAdHandler] Paid {value.Value} {value.CurrencyCode}");
    }

    private void InvokePendingComplete()
    {
        var cb = _pendingCompleteCallback;
        _pendingCompleteCallback = null;
        cb?.Invoke();
    }

    public void DestroyAd()
    {
        if (_rewardedAd != null)
        {
            _rewardedAd.Destroy();
            _rewardedAd = null;
        }
    }

    private void OnDestroy() => DestroyAd();
}