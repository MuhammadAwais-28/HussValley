using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.RemoteConfig;
using UnityEngine;

public class RemoteAdsConfig : MonoBehaviour
{
    public static RemoteAdsConfig Instance { get; private set; }

    // AdsManager waits on this before initializing the SDK, so ad loads
    // always use real remote values instead of local Inspector defaults.
    public static bool IsReady { get; private set; }

    private int _fetchRetryCount;
    private const int MaxFetchRetries = 5;
    private const float RetryDelaySeconds = 5f;
    private const float PerStepTimeoutSeconds = 12f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(RunPipeline());

        // Absolute safety net: if nothing above completes within 15s
        // (success, failure, or retry-exhaustion), unblock AdsManager anyway.
        Invoke(nameof(ForceReadyIfStillWaiting), 15f);
    }

    private void ForceReadyIfStillWaiting()
    {
        if (!IsReady)
        {
            Debug.LogWarning("[RemoteAdsConfig] Timed out waiting for Firebase/Remote Config — forcing IsReady with local/default values.");
            IsReady = true;
        }
    }

    /// <summary>
    /// Waits for a Task by polling Task.IsCompleted every frame via Unity's own
    /// coroutine scheduler — deliberately NOT using ContinueWithOnMainThread,
    /// since that relies on Firebase's internal dispatcher ticking, and we've
    /// seen cases where that dispatcher never fires even though the Task
    /// itself completed. Logs exactly which outcome happened, every time.
    /// </summary>
    private IEnumerator WaitForTask(Task task, string label, float timeoutSeconds)
    {
        Debug.Log($"[RemoteAdsConfig] Waiting for {label}...");
        float elapsed = 0f;

        while (!task.IsCompleted)
        {
            elapsed += Time.unscaledDeltaTime;
            if (elapsed >= timeoutSeconds)
            {
                Debug.LogWarning($"[RemoteAdsConfig] {label} did NOT complete within {timeoutSeconds}s (Task.IsCompleted is still false). This points to a hung native call or a stuck Firebase dispatcher, not your code.");
                yield break;
            }
            yield return null;
        }

        Debug.Log($"[RemoteAdsConfig] {label} completed after {elapsed:F1}s. IsFaulted={task.IsFaulted}, IsCanceled={task.IsCanceled}");
        if (task.IsFaulted)
        {
            Debug.LogError($"[RemoteAdsConfig] {label} exception: {task.Exception}");
        }
    }

    private IEnumerator RunPipeline()
    {
        var depsTask = Firebase.FirebaseApp.CheckAndFixDependenciesAsync();
        yield return WaitForTask(depsTask, "CheckAndFixDependenciesAsync", PerStepTimeoutSeconds);

        if (!depsTask.IsCompleted || depsTask.IsFaulted || depsTask.IsCanceled)
        {
            IsReady = true;
            yield break;
        }

        if (depsTask.Result != Firebase.DependencyStatus.Available)
        {
            Debug.LogError("[RemoteAdsConfig] Firebase dependency error: " + depsTask.Result);
            IsReady = true;
            yield break;
        }

        Debug.Log("[RemoteAdsConfig] Dependencies available — calling SetDefaultsAsync...");
        var defaults = new Dictionary<string, object>
        {
            { "BlockAllAds",                 false },
            { "BlockBannerAd",               false },
            { "BlockInterstitialAd",         false },
            { "BlockRewardedAd",             false },
            { "BlockMRecAd",                 false },
            { "BlockAppOpenAd",              false },
            { "BlockNativeAd",               false },
            { "BlockRewardedInterstitialAd", false },
        };

        var setDefaultsTask = FirebaseRemoteConfig.DefaultInstance.SetDefaultsAsync(defaults);
        yield return WaitForTask(setDefaultsTask, "SetDefaultsAsync", PerStepTimeoutSeconds);

        if (!setDefaultsTask.IsCompleted || setDefaultsTask.IsFaulted || setDefaultsTask.IsCanceled)
        {
            IsReady = true;
            yield break;
        }

        yield return StartCoroutine(FetchAndActivateCoroutine());
    }

    private IEnumerator FetchAndActivateCoroutine()
    {
        Debug.Log("[RemoteAdsConfig] Calling FetchAsync...");
        var fetchTask = FirebaseRemoteConfig.DefaultInstance.FetchAsync(TimeSpan.Zero);
        yield return WaitForTask(fetchTask, "FetchAsync", PerStepTimeoutSeconds);

        if (!fetchTask.IsCompleted || fetchTask.IsFaulted || fetchTask.IsCanceled)
        {
            yield return StartCoroutine(RetryFetchOrGiveUp());
            yield break;
        }

        Debug.Log("[RemoteAdsConfig] Calling ActivateAsync...");
        var activateTask = FirebaseRemoteConfig.DefaultInstance.ActivateAsync();
        yield return WaitForTask(activateTask, "ActivateAsync", PerStepTimeoutSeconds);

        if (!activateTask.IsCompleted || activateTask.IsFaulted)
        {
            yield return StartCoroutine(RetryFetchOrGiveUp());
            yield break;
        }

        _fetchRetryCount = 0;
        ApplyToAdsManager();
    }

    private IEnumerator RetryFetchOrGiveUp()
    {
        _fetchRetryCount++;

        if (_fetchRetryCount > MaxFetchRetries)
        {
            Debug.LogError($"[RemoteAdsConfig] Giving up after {MaxFetchRetries} failed fetch attempts — using last-known/default values.");
            ApplyToAdsManager();
            yield break;
        }

        Debug.LogWarning($"[RemoteAdsConfig] Retrying fetch in {RetryDelaySeconds}s (attempt {_fetchRetryCount}/{MaxFetchRetries}).");
        yield return new WaitForSeconds(RetryDelaySeconds);
        yield return StartCoroutine(FetchAndActivateCoroutine());
    }

    private void ApplyToAdsManager()
    {
        var config = FirebaseRemoteConfig.DefaultInstance;

        _blockAllAds = config.GetValue("BlockAllAds").BooleanValue;
        _blockBannerAd = config.GetValue("BlockBannerAd").BooleanValue;
        _blockInterstitialAd = config.GetValue("BlockInterstitialAd").BooleanValue;
        _blockRewardedAd = config.GetValue("BlockRewardedAd").BooleanValue;
        _blockAppOpenAd = config.GetValue("BlockAppOpenAd").BooleanValue;
        _blockNativeAd = config.GetValue("BlockNativeAd").BooleanValue;
        _blockMRecAd = config.GetValue("BlockMRecAd").BooleanValue;
        _blockRewardedInterstitialAd = config.GetValue("BlockRewardedInterstitialAd").BooleanValue;

        IsReady = true;

        if (AdsManager.Instance != null && AdsManager.Instance.IsSdkInitialized)
        {
            PushValuesInto(AdsManager.Instance);
            AdsManager.Instance.ApplyBlockFlags();
        }

        Debug.Log($"[RemoteAdsConfig] Platform={Application.platform} | " +
         $"BlockAllAds={_blockAllAds} | " +
         $"BlockBannerAd={_blockBannerAd} | " +
         $"BlockInterstitialAd={_blockInterstitialAd} | " +
         $"BlockRewardedAd={_blockRewardedAd} | " +
         $"BlockAppOpenAd={_blockAppOpenAd} | " +
         $"BlockNativeAd={_blockNativeAd} | " +
         $"BlockMRecAd={_blockMRecAd} | " +
         $"BlockRewardedInterstitialAd={_blockRewardedInterstitialAd}");
    }

    private bool _blockAllAds, _blockBannerAd, _blockInterstitialAd, _blockRewardedAd,
                 _blockAppOpenAd, _blockNativeAd, _blockMRecAd, _blockRewardedInterstitialAd;

    public void PushValuesInto(AdsManager ads)
    {
        ads.BlockAllAds = _blockAllAds;
        ads.BlockBannerAd = _blockBannerAd;
        ads.BlockInterstitialAd = _blockInterstitialAd;
        ads.BlockRewardedAd = _blockRewardedAd;
        ads.BlockAppOpenAd = _blockAppOpenAd;
        ads.BlockNativeAd = _blockNativeAd;
        ads.BlockMRecAd = _blockMRecAd;
        ads.BlockRewardedInterstitialAd = _blockRewardedInterstitialAd;
    }
}