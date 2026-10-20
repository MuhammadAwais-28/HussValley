using System.Collections;
using UnityEngine;

/// <summary>
/// Attach to any panel/screen GameObject that should display the shared MREC
/// ad in a specific spot while it's active. Positions and shows the ad on
/// enable, hides it on disable — so switching screens automatically moves
/// (or hides) the MREC instead of it staying stuck on an old screen.
///
/// The actual Show/MoveTo call is deferred by one frame: if this panel is
/// active by default in the scene, OnEnable() fires while the scene is still
/// loading (on Unity's loading thread), and calling into Screen.width or the
/// native BannerView from there throws "can only be called from the main
/// thread". Waiting one frame guarantees we're safely past that point.
/// </summary>
public class MRecScreenBinding : MonoBehaviour
{
    public enum MRecPreset
    {
        Top,
        Bottom,
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight,
        Center
    }

    [Header("Preset Position")]
    [Tooltip("Where the MREC should sit while THIS screen is showing. Ignored if 'Use Custom Position' is enabled below.")]
    public MRecPreset position = MRecPreset.Bottom;

    [Header("Custom Position (overrides preset above)")]
    [Tooltip("If true, uses the exact xPercent/yPercent spot below instead of the fixed preset above.")]
    public bool useCustomPosition = false;

    [Tooltip("Horizontal position as a fraction of screen width. 0 = left edge, 1 = right edge.")]
    [Range(0f, 1f)] public float xPercent = 0f;

    [Tooltip("Vertical position as a fraction of screen height. 0 = top edge, 1 = bottom edge.")]
    [Range(0f, 1f)] public float yPercent = 0.5f;

    // Small inset so edge/corner presets don't render flush against the
    // screen border. Purely cosmetic — tweak to taste.
    private const float EdgeMargin = 0.02f;

    // Shared across every MRecScreenBinding instance in the scene. Counts how
    // many ad-enabled screens are simultaneously active. Only hides the MREC
    // when this drops to zero — mirrors NativeAdScreenBinding's fix so the
    // Home->Settings-style "last OnDisable wins" bug can't happen here either.
    private static int _activeBindingCount = 0;

    private Coroutine _showRoutine;

    private void OnEnable()
    {
        _activeBindingCount++;

        if (_showRoutine != null) StopCoroutine(_showRoutine);
        _showRoutine = StartCoroutine(ShowNextFrame());
    }

    private IEnumerator ShowNextFrame()
    {
        // Wait one frame so we're guaranteed to be past scene-load and on
        // the main thread before touching Screen.width or the native ad view.
        yield return null;

        if (AdsManager.Instance == null)
        {
            Debug.LogWarning($"[MRecScreenBinding:{gameObject.name}] AdsManager.Instance is null, cannot show MREC.");
            yield break;
        }
        if (AdsManager.Instance.MRecHandler == null)
        {
            Debug.LogWarning($"[MRecScreenBinding:{gameObject.name}] MRecHandler not assigned on AdsManager, cannot show MREC.");
            yield break;
        }

        float x, y;
        if (useCustomPosition)
        {
            x = xPercent;
            y = yPercent;
        }
        else
        {
            (x, y) = ResolvePreset(position);
        }

        Debug.Log($"[MRecScreenBinding:{gameObject.name}] Moving MREC to ({x}, {y}) [{(useCustomPosition ? "custom" : position.ToString())}] and showing.");
        AdsManager.Instance.MRecHandler.MoveTo(x, y);
        AdsManager.Instance.MRecHandler.Show();
    }

    private void OnDisable()
    {
        _activeBindingCount = Mathf.Max(0, _activeBindingCount - 1);

        if (_showRoutine != null)
        {
            StopCoroutine(_showRoutine);
            _showRoutine = null;
        }

        // Another ad-enabled screen is still active — leave the ad showing.
        if (_activeBindingCount > 0) return;

        if (AdsManager.Instance == null || AdsManager.Instance.MRecHandler == null) return;

        Debug.Log($"[MRecScreenBinding:{gameObject.name}] OnDisable — hiding MREC.");
        AdsManager.Instance.MRecHandler.Hide();
    }

    /// <summary>
    /// Maps a preset to an (xPercent, yPercent) top-left anchor, the same way
    /// MoveTo/RenderAd already interpret custom position elsewhere in this
    /// project. NOTE: because MoveTo anchors the ad's TOP-LEFT corner (not
    /// its center), "Center" here is only an approximation — true centering
    /// would need to subtract half the MREC's width/height in percent, which
    /// requires knowing the box's pixel size relative to Screen.width/height
    /// inside MRecHandler. If you want pixel-perfect centering, expose the
    /// MREC's rendered width/height from MRecHandler and I can correct this.
    /// </summary>
    private (float x, float y) ResolvePreset(MRecPreset preset)
    {
        switch (preset)
        {
            case MRecPreset.Top: return (0.5f, EdgeMargin);
            case MRecPreset.Bottom: return (0.5f, 1f - EdgeMargin);
            case MRecPreset.TopLeft: return (EdgeMargin, EdgeMargin);
            case MRecPreset.TopRight: return (1f - EdgeMargin, EdgeMargin);
            case MRecPreset.BottomLeft: return (EdgeMargin, 1f - EdgeMargin);
            case MRecPreset.BottomRight: return (1f - EdgeMargin, 1f - EdgeMargin);
            case MRecPreset.Center: return (0.5f, 0.5f);
            default: return (0.5f, 1f - EdgeMargin);
        }
    }
}