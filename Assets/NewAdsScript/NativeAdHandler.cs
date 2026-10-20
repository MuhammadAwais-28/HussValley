using GoogleMobileAds.Api;
using UnityEngine;

/// <summary>
/// Keeps two ad slots: the one currently on screen (_currentAd), and one
/// quietly pre-fetching in the background (_pendingAd) so the NEXT screen
/// transition doesn't have to wait on a network request. Positioning/sizing
/// is applied at render time (fast, no network), so as long as the pending
/// ad had time to finish loading while the player was on the previous
/// screen, the next screen shows it immediately.
/// </summary>
public class NativeAdHandler : MonoBehaviour
{
    [Header("Template")]
    public AdPosition Position = AdPosition.Top;

    [Header("Custom Position (overrides Position above when enabled)")]
    [Tooltip("If true, places the ad at an exact pixel spot instead of one of the fixed corners/edges above.")]
    public bool useCustomPosition = false;

    [Tooltip("Horizontal position as a fraction of screen width. 0 = left edge, 1 = right edge.")]
    [Range(0f, 1f)] public float customXPercent = 0f;

    [Tooltip("Vertical position as a fraction of screen height. 0 = top edge, 1 = bottom edge.")]
    [Range(0f, 1f)] public float customYPercent = 0.5f;

    [Header("Size (prevents the template from stretching full-screen)")]
    [Tooltip("Width as a fraction of screen width.")]
    [Range(0.1f, 1f)] public float widthPercent = 0.6f;

    [Tooltip("Height as a fraction of screen height.")]
    [Range(0.05f, 1f)] public float heightPercent = 0.15f;

    private NativeOverlayAd _currentAd;
    private NativeOverlayAd _pendingAd;
    private int _currentRequestId;
    private int _pendingRequestId;

    /// <summary>True once a background-preloaded ad is ready to swap in instantly.</summary>
    public bool HasPendingAd => _pendingAd != null;

    /// <summary>
    /// Old behavior: loads directly into the CURRENT slot and renders as
    /// soon as it arrives (there will be a visible wait). Used as a fallback
    /// when no pending ad is ready yet, and for the very first load.
    /// </summary>
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

            // Now that something is showing, start warming up the NEXT one
            // in the background for whatever screen comes after this one.
            PreloadNext();
        });
    }

    /// <summary>
    /// Quietly fetches a fresh ad in the background without rendering it —
    /// call this once the current screen's ad is already showing, so the
    /// next screen has something ready to swap in instantly.
    /// </summary>
    public void PreloadNext()
    {
        if (_pendingAd != null) return; // already have one waiting
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

    /// <summary>
    /// Called by NativeAdScreenBinding when a screen becomes active. If a
    /// preloaded ad is ready, swaps it in and renders instantly (no wait),
    /// then immediately starts preloading the NEXT one. If nothing was
    /// preloaded yet (e.g. very first screen), falls back to a direct
    /// LoadAd(), which will have a visible wait like before.
    /// </summary>
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

    /// <summary>Kept for any old callers still using Show() directly (e.g. manual test wiring).</summary>
    public void Show()
    {
        Debug.Log($"[NativeAdHandler] Show() called. hasExistingAd={_currentAd != null}, useCustomPosition={useCustomPosition}, Position={Position}, X%={customXPercent}, Y%={customYPercent}");

        if (_currentAd == null)
        {
            ShowFresh();
            return;
        }

        RenderAd(_currentAd);
    }

    private void RenderAd(NativeOverlayAd ad)
    {
        NativeTemplateStyle style = new NativeTemplateStyle
        {
            TemplateId = NativeTemplateId.Medium,
            MainBackgroundColor = Color.white
        };

        int width;
        int height;
        AdSize size;

        // Calculate device scaling factor safely (DP to Pixels)
        float scaleFactor = Screen.dpi / 160f;
        if (scaleFactor <= 0f || float.IsNaN(scaleFactor)) scaleFactor = 1.0f;
        if (scaleFactor > 3.0f) scaleFactor = 2.0f; // Limit extreme simulated high-res scaling in editor

        if (useCustomPosition)
        {
            // Force the exact standard 300x250 Medium Rectangle size in pixels
            width = Mathf.RoundToInt(300 * scaleFactor);
            height = Mathf.RoundToInt(250 * scaleFactor);

            // Absolute hardcoded safe-minimums required by Google AdMob native layout engine
            if (width < 300) width = 300;
            if (height < 250) height = 250;

            size = new AdSize(width, height);

            // Locate the target point using your screen coordinates
            int targetX = Mathf.RoundToInt(Screen.width * customXPercent);
            int targetY = Mathf.RoundToInt(Screen.height * customYPercent);

            // Offset alignment relative to bottom-left origins
            int x = targetX - (width / 2);
            int y = targetY - (height / 2);

            // Hard clamp everything within the safe display viewport bounds
            x = Mathf.Clamp(x, 10, Screen.width - width - 10);
            y = Mathf.Clamp(y, 10, Screen.height - height - 10);

            Debug.Log($"[NativeAdHandler] Fixed MREC Dimensions -> x={x}, y={y}, w={width}, h={height}");
            ad.RenderTemplate(style, size, x, y);
        }
        else
        {
            // Safe Area / Intercept: Overwrite unsafe proportions passed from binding scripts
            float safeWidthPercent = Mathf.Max(widthPercent, 0.65f);  // Clamp minimum horizontal space
            float safeHeightPercent = Mathf.Max(heightPercent, 0.30f); // Clamp minimum vertical space

            width = Mathf.RoundToInt(Screen.width * safeWidthPercent);
            height = Mathf.RoundToInt(Screen.height * safeHeightPercent);

            int minWidthPixels = Mathf.RoundToInt(320 * scaleFactor);
            int minHeightPixels = Mathf.RoundToInt(260 * scaleFactor);

            if (width < minWidthPixels) width = minWidthPixels;
            if (height < minHeightPixels) height = minHeightPixels;

            size = new AdSize(width, height);
            ad.RenderTemplate(style, size, Position);
        }
    }

    public void Hide()
    {
        Debug.Log("[NativeAdHandler] Hide() called.");
        _currentAd?.Hide();
    }

    /// <summary>Destroys only the currently-shown ad. The background pending/preloaded ad is left untouched.</summary>
    private void DestroyCurrentAd()
    {
        if (_currentAd != null)
        {
            _currentAd.Hide();
            _currentAd.Destroy();
            _currentAd = null;
        }
    }

    /// <summary>
    /// Public entry point used by NativeAdScreenBinding's OnDisable.
    /// Hides and destroys the shown ad, but deliberately does NOT touch the pending
    /// preload, so it stays ready for whichever screen appears next.
    /// </summary>
    public void DestroyAd()
    {
        DestroyCurrentAd();
    }

    /// <summary>
    /// Destroys everything, including the background preload.
    /// Use this when native ads are being fully blocked (e.g., AdsManager.BlockNativeAd turned on), 
    /// not for normal per-screen transitions.
    /// </summary>
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
