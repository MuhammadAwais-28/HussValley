using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;

public class NativeAdScreenBinding : MonoBehaviour
{
    public enum NativeAdTemplate { Small, Medium }

    [Header("Handler (optional, leave empty to use AdsManager.Instance.NativeHandler)")]
    public NativeAdHandler handler;

    [Header("Template")]
    public NativeAdTemplate template = NativeAdTemplate.Small;

    [Header("Preset Position")]
    public AdPosition position = AdPosition.Bottom;

    [Header("Custom Position (X/Y = center of the ad)")]
    public bool useCustomPosition = false;
    [Range(0f, 1f)] public float customXPercent = 0.17f;
    [Range(0f, 1f)] public float customYPercent = 0.55f;

    [Header("Size (fraction of screen; the template's minimum still applies)")]
    [Range(0.1f, 1f)] public float widthPercent = 0.3f;
    [Range(0.05f, 1f)] public float heightPercent = 0.2f;

    private static readonly HashSet<NativeAdScreenBinding> _activeBindings = new HashSet<NativeAdScreenBinding>();

    private NativeAdHandler ResolveHandler()
    {
        if (handler != null) return handler;

        if (AdsManager.Instance == null)
        {
            Debug.LogWarning($"[NativeAdScreenBinding:{gameObject.name}] AdsManager.Instance is null.");
            return null;
        }
        return AdsManager.Instance.NativeHandler;
    }

    private void OnEnable()
    {
        _activeBindings.Add(this);

        var resolved = ResolveHandler();
        if (resolved == null) return;

        resolved.useSmallTemplate = (template == NativeAdTemplate.Small);
        resolved.useCustomPosition = useCustomPosition;
        resolved.Position = position;
        resolved.customXPercent = customXPercent;
        resolved.customYPercent = customYPercent;
        resolved.widthPercent = widthPercent;
        resolved.heightPercent = heightPercent;

        resolved.ShowFresh();
    }

    private void OnDisable()
    {
        _activeBindings.Remove(this);
        if (_activeBindings.Count > 0) return;

        ResolveHandler()?.DestroyAd();
    }
}