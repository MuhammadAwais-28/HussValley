using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;

/// <summary>
/// Each screen that has this component gets its own fresh native ad
/// impression: entering the screen triggers a brand new LoadAd() (which
/// internally destroys whatever ad existed before), and leaving the screen
/// fully destroys the ad rather than just hiding it. This means every
/// screen transition is a new ad request/impression, not a reused/
/// repositioned view of the same ad.
/// </summary>
public class NativeAdScreenBinding : MonoBehaviour
{
    [Header("Handler (optional — leave empty to use the persistent AdsManager.Instance.NativeHandler)")]
    [Tooltip("Only set this if you want to override with a specific local handler for testing. In normal use, leave this empty: at runtime the persistent handler under Bootstrap/AdsManager is used automatically, which also avoids the cross-scene reference problem (Bootstrap and this scene are never both loaded in the Editor, so you can't drag that reference in here directly anyway).")]
    public NativeAdHandler handler;

    [Header("Preset Position")]
    public AdPosition position = AdPosition.Bottom;

    [Header("Custom Position")]
    public bool useCustomPosition = false;

    [Tooltip("Horizontal position")]
    [Range(0f, 1f)] public float customXPercent = 0f;

    [Tooltip("Vertical position")]
    [Range(0f, 1f)] public float customYPercent = 0.5f;

    [Header("Size (per-screen — prevents the template from stretching full-screen)")]
    [Tooltip("Width as a fraction of screen width. Note: Google's built-in template has its own minimum size and may ignore very small values.")]
    [Range(0.1f, 1f)] public float widthPercent = 0.4f;

    [Tooltip("Height as a fraction of screen height.")]
    [Range(0.05f, 1f)] public float heightPercent = 0.15f;

    private static readonly HashSet<NativeAdScreenBinding> _activeBindings = new HashSet<NativeAdScreenBinding>();

    private NativeAdHandler ResolveHandler()
    {
        if (handler != null) return handler;

        if (AdsManager.Instance == null)
        {
            Debug.LogWarning($"[NativeAdScreenBinding:{gameObject.name}] AdsManager.Instance is null — cannot resolve NativeHandler.");
            return null;
        }

        return AdsManager.Instance.NativeHandler;
    }

    private void OnEnable()
    {
        _activeBindings.Add(this);

        var resolved = ResolveHandler();
        if (resolved == null)
        {
            Debug.LogWarning($"[NativeAdScreenBinding:{gameObject.name}] No handler available — nothing to show.");
            return;
        }

        resolved.useCustomPosition = useCustomPosition;
        if (useCustomPosition)
        {
            resolved.customXPercent = customXPercent;
            resolved.customYPercent = customYPercent;
        }
        else
        {
            resolved.Position = position;
        }

        resolved.widthPercent = widthPercent;
        resolved.heightPercent = heightPercent;

        resolved.ShowFresh(); // instant if a background preload is ready; otherwise falls back to a direct LoadAd() (waits)
    }

    private void OnDisable()
    {
        _activeBindings.Remove(this);

        if (_activeBindings.Count > 0) return;

        var resolved = ResolveHandler();
        resolved?.DestroyAd(); // was: resolved?.Hide();
    }
}