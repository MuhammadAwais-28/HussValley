using GoogleMobileAds.Api;
using UnityEngine;

/// <summary>
/// Two ad slots: the one on screen (_currentAd) and one pre-fetching in the
/// background (_pendingAd). Position math is the original (unchanged);
/// only the custom-position height was increased so the Medium template's
/// media view is never squeezed below AdMob's minimum (validator error).
/// </summary>
public class NativeAdHandler : MonoBehaviour
{

    [Header("Template (set per screen by NativeAdScreenBinding)")]
    public bool useSmallTemplate = true;



    [Header("Template")]
    public AdPosition Position = AdPosition.Top;

    [Header("Custom Position (overrides Position above when enabled)")]
    public bool useCustomPosition = false;
    [Range(0f, 1f)] public float customXPercent = 0f;
    [Range(0f, 1f)] public float customYPercent = 0.5f;

    [Header("Size (non-custom mode)")]
    [Range(0.1f, 1f)] public float widthPercent = 0.6f;
    [Range(0.05f, 1f)] public float heightPercent = 0.15f;

    [Header("Custom mode size (base units, multiplied by device scale)")]
    public float customBaseWidth = 300f;
    [Tooltip("Was 250. Taller = media view never gets squeezed. Raise if validator still complains.")]
    public float customBaseHeight = 340f;

    [Tooltip("If the screen can't fit the Medium template at this height, the Small template (no media view) is used instead.")]
    public float minHeightForMedium = 300f;

    private NativeOverlayAd _currentAd;
    private NativeOverlayAd _pendingAd;
    private int _currentRequestId;
    private int _pendingRequestId;

    public bool HasPendingAd => _pendingAd != null;

    public void LoadAd()
    {
        Debug.Log("[NativeAdHandler] LoadAd() called (direct, will wait for network).");
        DestroyCurrentAd();

        if (AdsManager.Instance != null && AdsManager.Instance.BlockNativeAd)
        {
            Debug.Log("[NativeAdHandler] Blocked by AdsManager — skipping load.");
            return;
        }

        int thisRequestId = ++_currentRequestId;
        AdRequest request = new AdRequest();
        NativeAdOptions options = new NativeAdOptions();

        NativeOverlayAd.Load(AdUnitIds.Native, request, options, (ad, error) =>
        {
            if (error != null || ad == null)
            {
                Debug.LogWarning("[NativeAdHandler] Load failed: " + error);
                return;
            }

            if (this == null || thisRequestId != _currentRequestId)
            {
                Debug.Log("[NativeAdHandler] Stale current-ad load — discarding.");
                ad.Destroy();
                return;
            }

            if (AdsManager.Instance != null && AdsManager.Instance.BlockNativeAd)
            {
                Debug.Log("[NativeAdHandler] Blocked mid-load — discarding loaded ad.");
                ad.Destroy();
                return;
            }

            ad.OnAdPaid += (AdValue value) =>
                Debug.Log($"[NativeAdHandler] Paid {value.Value} {value.CurrencyCode}");

            _currentAd = ad;
            RenderAd(_currentAd);
            Debug.Log("[NativeAdHandler] Ad loaded and rendered (direct load).");

            PreloadNext();
        });
    }

    public void PreloadNext()
    {
        if (_pendingAd != null) return;
        if (AdsManager.Instance != null && AdsManager.Instance.BlockNativeAd) return;

        int thisRequestId = ++_pendingRequestId;
        AdRequest request = new AdRequest();
        NativeAdOptions options = new NativeAdOptions();

        NativeOverlayAd.Load(AdUnitIds.Native, request, options, (ad, error) =>
        {
            if (error != null || ad == null)
            {
                Debug.LogWarning("[NativeAdHandler] Preload failed: " + error);
                return;
            }

            if (this == null || thisRequestId != _pendingRequestId)
            {
                Debug.Log("[NativeAdHandler] Stale preload — discarding.");
                ad.Destroy();
                return;
            }

            if (AdsManager.Instance != null && AdsManager.Instance.BlockNativeAd)
            {
                Debug.Log("[NativeAdHandler] Blocked — discarding preloaded ad.");
                ad.Destroy();
                return;
            }

            ad.OnAdPaid += (AdValue value) =>
                Debug.Log($"[NativeAdHandler] Paid {value.Value} {value.CurrencyCode}");

            _pendingAd = ad;
            Debug.Log("[NativeAdHandler] Background preload ready.");
        });
    }

    public void ShowFresh()
    {
        Debug.Log($"[NativeAdHandler] ShowFresh() called. hasPending={_pendingAd != null}, useCustomPosition={useCustomPosition}, X%={customXPercent}, Y%={customYPercent}");

        if (_pendingAd != null)
        {
            DestroyCurrentAd();
            _currentAd = _pendingAd;
            _pendingAd = null;
            RenderAd(_currentAd);
            Debug.Log("[NativeAdHandler] Swapped in preloaded ad instantly.");
            PreloadNext();
        }
        else
        {
            Debug.Log("[NativeAdHandler] No preload ready — falling back to direct LoadAd() (will wait).");
            LoadAd();
        }
    }

    public void Show()
    {
        Debug.Log($"[NativeAdHandler] Show() called. hasExistingAd={_currentAd != null}");
        if (_currentAd == null)
        {
            ShowFresh();
            return;
        }
        RenderAd(_currentAd);
    }

    private void RenderAd(NativeOverlayAd ad)
    {
        float scaleFactor = Screen.dpi / 160f;
        if (scaleFactor <= 0f || float.IsNaN(scaleFactor)) scaleFactor = 1.0f;
        if (scaleFactor > 3.0f) scaleFactor = 2.0f;

        // Minimum sizes in dp. Raise minMediumH if the validator still complains.
        const float minSmallW = 280f, minSmallH = 100f;
        const float minMediumW = 320f, minMediumH = 380f;

        bool small = useSmallTemplate;
        int maxW = Screen.width - 20;
        int maxH = Screen.height - 20;

        // Medium can't fit on a short landscape screen, so fall back to Small
        if (!small && maxH < Mathf.RoundToInt(minMediumH * scaleFactor))
            small = true;

        float minW = (small ? minSmallW : minMediumW) * scaleFactor;
        float minH = (small ? minSmallH : minMediumH) * scaleFactor;

        int width = Mathf.Min(maxW, Mathf.Max(Mathf.RoundToInt(Screen.width * widthPercent), Mathf.RoundToInt(minW)));
        int height = Mathf.Min(maxH, Mathf.Max(Mathf.RoundToInt(Screen.height * heightPercent), Mathf.RoundToInt(minH)));

        NativeTemplateStyle style = new NativeTemplateStyle
        {
            TemplateId = small ? NativeTemplateId.Small : NativeTemplateId.Medium,
            MainBackgroundColor = Color.white
        };

        AdSize size = new AdSize(width, height);

        if (useCustomPosition)
        {
            // customX/YPercent = where the CENTER of the ad sits
            int x = Mathf.RoundToInt(Screen.width * customXPercent) - width / 2;
            int y = Mathf.RoundToInt(Screen.height * customYPercent) - height / 2;
            x = Mathf.Clamp(x, 10, Mathf.Max(10, Screen.width - width - 10));
            y = Mathf.Clamp(y, 10, Mathf.Max(10, Screen.height - height - 10));

            Debug.Log($"[NativeAdHandler] {(small ? "Small" : "Medium")} custom -> x={x}, y={y}, w={width}, h={height}");
            ad.RenderTemplate(style, size, x, y);
        }
        else
        {
            Debug.Log($"[NativeAdHandler] {(small ? "Small" : "Medium")} preset {Position} -> w={width}, h={height}");
            ad.RenderTemplate(style, size, Position);
        }
    }

    public void Hide()
    {
        Debug.Log("[NativeAdHandler] Hide() called.");
        _currentAd?.Hide();
    }

    private void DestroyCurrentAd()
    {
        if (_currentAd != null)
        {
            _currentAd.Hide();
            _currentAd.Destroy();
            _currentAd = null;
        }
    }

    public void DestroyAd()
    {
        DestroyCurrentAd();
    }

    public void DestroyAllAds()
    {
        DestroyCurrentAd();

        if (_pendingAd != null)
        {
            _pendingAd.Hide();
            _pendingAd.Destroy();
            _pendingAd = null;
        }
    }

    private void OnDestroy() => DestroyAllAds();
}