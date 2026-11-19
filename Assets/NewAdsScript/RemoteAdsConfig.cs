using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.RemoteConfig;
using UnityEngine;

public class RemoteAdsConfig : MonoBehaviour
{
    public static RemoteAdsConfig Instance { get; private set; }

    public static bool IsReady { get; private set; }

    [Header("Firebase Settings")]
    [SerializeField] private int maxFetchRetries = 5;
    [SerializeField] private float retryDelaySeconds = 5f;
    [SerializeField] private float perStepTimeoutSeconds = 12f;
    [SerializeField] private float readyTimeoutSeconds = 15f;

    private int _fetchRetryCount;

    // Safe defaults: all ads OFF until Firebase values are available.
    private bool _blockAllAds = true;
    private bool _blockBannerAd = true;
    private bool _blockInterstitialAd = true;
    private bool _blockRewardedAd = true;
    private bool _blockAppOpenAd = true;
    private bool _blockNativeAd = true;
    private bool _blockMRecAd = true;
    private bool _blockRewardedInterstitialAd = true;

    private string _reviewBuildVersion = "";

    // True once a fetch + activate has actually succeeded.
    private bool _pipelineCompleted;

    // True once Firebase dependencies are available and defaults are set,
    // meaning FirebaseRemoteConfig.DefaultInstance is safe to read.
    private bool _firebaseConfigUsable;

    private void Awake()
    {
        // Reset statics so Enter Play Mode without domain reload behaves.
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
        if (Instance != this)
            return;

        StartCoroutine(RunPipeline());

        Invoke(nameof(ForceReadyIfStillWaiting), readyTimeoutSeconds);
    }

    private void ForceReadyIfStillWaiting()
    {
        if (IsReady)
            return;

        Debug.LogWarning(
            "[RemoteAdsConfig] Firebase timeout. " +
            "Continuing with safe defaults (ALL ADS OFF)."
        );

        // Deliberately does NOT set _pipelineCompleted, so a late successful
        // fetch can still apply real values afterwards.
        ApplyToAdsManager();

        IsReady = true;
    }

    private IEnumerator WaitForTask(
        Task task,
        string label,
        float timeoutSeconds)
    {
        Debug.Log("[RemoteAdsConfig] Waiting for " + label);

        float elapsed = 0f;

        while (!task.IsCompleted)
        {
            elapsed += Time.unscaledDeltaTime;

            if (elapsed >= timeoutSeconds)
            {
                Debug.LogWarning(
                    "[RemoteAdsConfig] " + label +
                    " timed out after " + timeoutSeconds + " seconds."
                );

                yield break;
            }

            yield return null;
        }

        Debug.Log(
            "[RemoteAdsConfig] " + label +
            " completed. Faulted=" + task.IsFaulted +
            " Canceled=" + task.IsCanceled
        );

        if (task.IsFaulted)
        {
            Debug.LogError(
                "[RemoteAdsConfig] " + label +
                " Error: " + task.Exception
            );
        }
    }

    private IEnumerator RunPipeline()
    {
        Debug.Log("[RemoteAdsConfig] Checking Firebase dependencies...");

        // FIX: must be Task<DependencyStatus> so that .Result is available.
        Task<Firebase.DependencyStatus> depsTask =
            Firebase.FirebaseApp.CheckAndFixDependenciesAsync();

        yield return WaitForTask(
            depsTask,
            "CheckAndFixDependenciesAsync",
            perStepTimeoutSeconds
        );

        if (!depsTask.IsCompleted ||
            depsTask.IsFaulted ||
            depsTask.IsCanceled)
        {
            FinishWithSafeDefaults();
            yield break;
        }

        if (depsTask.Result != Firebase.DependencyStatus.Available)
        {
            Debug.LogError(
                "[RemoteAdsConfig] Firebase dependencies unavailable: " +
                depsTask.Result
            );

            FinishWithSafeDefaults();
            yield break;
        }

        Debug.Log("[RemoteAdsConfig] Firebase dependencies available.");

        Dictionary<string, object> defaults =
            new Dictionary<string, object>
            {
                { "BlockAllAds", true },
                { "BlockBannerAd", true },
                { "BlockInterstitialAd", true },
                { "BlockRewardedAd", true },
                { "BlockMRecAd", true },
                { "BlockAppOpenAd", true },
                { "BlockNativeAd", true },
                { "BlockRewardedInterstitialAd", true },
                { "ReviewBuildVersion", "" }
            };

        Task defaultsTask =
            FirebaseRemoteConfig.DefaultInstance.SetDefaultsAsync(defaults);

        yield return WaitForTask(
            defaultsTask,
            "SetDefaultsAsync",
            perStepTimeoutSeconds
        );

        if (!defaultsTask.IsCompleted ||
            defaultsTask.IsFaulted ||
            defaultsTask.IsCanceled)
        {
            FinishWithSafeDefaults();
            yield break;
        }

        // From here on it is safe to read DefaultInstance values
        // (defaults, or previously activated values).
        _firebaseConfigUsable = true;

        yield return StartCoroutine(FetchAndActivateCoroutine());
    }

    private IEnumerator FetchAndActivateCoroutine()
    {
        Debug.Log("[RemoteAdsConfig] Fetching Remote Config...");

        Task fetchTask =
            FirebaseRemoteConfig.DefaultInstance.FetchAsync(TimeSpan.Zero);

        yield return WaitForTask(
            fetchTask,
            "FetchAsync",
            perStepTimeoutSeconds
        );

        if (!fetchTask.IsCompleted ||
            fetchTask.IsFaulted ||
            fetchTask.IsCanceled)
        {
            yield return StartCoroutine(RetryFetchOrGiveUp());
            yield break;
        }

        Debug.Log("[RemoteAdsConfig] Activating Remote Config...");

        Task activateTask =
            FirebaseRemoteConfig.DefaultInstance.ActivateAsync();

        yield return WaitForTask(
            activateTask,
            "ActivateAsync",
            perStepTimeoutSeconds
        );

        if (!activateTask.IsCompleted ||
            activateTask.IsFaulted ||
            activateTask.IsCanceled)
        {
            yield return StartCoroutine(RetryFetchOrGiveUp());
            yield break;
        }

        _fetchRetryCount = 0;

        Debug.Log("[RemoteAdsConfig] Remote Config successfully activated.");

        // Mark complete BEFORE applying so no fallback path can overwrite
        // these real values afterwards.
        _pipelineCompleted = true;

        ApplyToAdsManager();

        IsReady = true;
        CancelInvoke(nameof(ForceReadyIfStillWaiting));
    }

    private IEnumerator RetryFetchOrGiveUp()
    {
        _fetchRetryCount++;

        if (_fetchRetryCount > maxFetchRetries)
        {
            Debug.LogError(
                "[RemoteAdsConfig] Maximum fetch retries reached. " +
                "Using safe defaults."
            );

            FinishWithSafeDefaults();
            yield break;
        }

        Debug.LogWarning(
            "[RemoteAdsConfig] Retrying fetch in " +
            retryDelaySeconds + " seconds. Attempt " +
            _fetchRetryCount + "/" + maxFetchRetries
        );

        yield return new WaitForSecondsRealtime(retryDelaySeconds);

        yield return StartCoroutine(FetchAndActivateCoroutine());
    }

    private void FinishWithSafeDefaults()
    {
        if (_pipelineCompleted)
            return;

        ApplyToAdsManager();

        IsReady = true;
        _pipelineCompleted = true;
        CancelInvoke(nameof(ForceReadyIfStillWaiting));
    }

    private void ApplyToAdsManager()
    {
        // Only read from Firebase when it is known to be usable.
        // Otherwise the private _block... fields keep their safe defaults (all true).
        if (_firebaseConfigUsable)
        {
            try
            {
                FirebaseRemoteConfig config =
                    FirebaseRemoteConfig.DefaultInstance;

                _blockAllAds =
                    config.GetValue("BlockAllAds").BooleanValue;

                _blockBannerAd =
                    config.GetValue("BlockBannerAd").BooleanValue;

                _blockInterstitialAd =
                    config.GetValue("BlockInterstitialAd").BooleanValue;

                _blockRewardedAd =
                    config.GetValue("BlockRewardedAd").BooleanValue;

                _blockAppOpenAd =
                    config.GetValue("BlockAppOpenAd").BooleanValue;

                _blockNativeAd =
                    config.GetValue("BlockNativeAd").BooleanValue;

                _blockMRecAd =
                    config.GetValue("BlockMRecAd").BooleanValue;

                _blockRewardedInterstitialAd =
                    config.GetValue("BlockRewardedInterstitialAd").BooleanValue;

                string reviewValue =
                    config.GetValue("ReviewBuildVersion").StringValue;

                _reviewBuildVersion =
                    string.IsNullOrEmpty(reviewValue) ? "" : reviewValue.Trim();
            }
            catch (Exception e)
            {
                Debug.LogError(
                    "[RemoteAdsConfig] Failed reading Remote Config values. " +
                    "Using safe defaults (ALL ADS OFF). " + e
                );

                SetAllBlocked();
            }
        }
        else
        {
            SetAllBlocked();
        }

        string currentVersion = Application.version.Trim();

        bool isReviewBuild =
            !string.IsNullOrEmpty(_reviewBuildVersion) &&
            string.Equals(
                currentVersion,
                _reviewBuildVersion,
                StringComparison.OrdinalIgnoreCase
            );

        if (isReviewBuild)
        {
            Debug.LogWarning(
                "[RemoteAdsConfig] Review version matched: " +
                currentVersion + ". ALL ADS DISABLED."
            );

            SetAllBlocked();
        }

        // Push updated values into AdsManager.
        if (AdsManager.Instance != null)
        {
            PushValuesInto(AdsManager.Instance);

            if (AdsManager.Instance.IsSdkInitialized)
            {
                AdsManager.Instance.ApplyBlockFlags();
            }
        }

        Debug.Log(
            "[RemoteAdsConfig] Configuration Applied | " +
            "CurrentVersion=" + currentVersion +
            " | ReviewVersion=" + _reviewBuildVersion +
            " | IsReviewBuild=" + isReviewBuild +
            " | BlockAllAds=" + _blockAllAds +
            " | Banner=" + _blockBannerAd +
            " | Interstitial=" + _blockInterstitialAd +
            " | Rewarded=" + _blockRewardedAd +
            " | AppOpen=" + _blockAppOpenAd +
            " | Native=" + _blockNativeAd +
            " | MRec=" + _blockMRecAd +
            " | RewardedInterstitial=" + _blockRewardedInterstitialAd
        );
    }

    private void SetAllBlocked()
    {
        _blockAllAds = true;
        _blockBannerAd = true;
        _blockInterstitialAd = true;
        _blockRewardedAd = true;
        _blockAppOpenAd = true;
        _blockNativeAd = true;
        _blockMRecAd = true;
        _blockRewardedInterstitialAd = true;
    }

    public void PushValuesInto(AdsManager ads)
    {
        if (ads == null)
            return;

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