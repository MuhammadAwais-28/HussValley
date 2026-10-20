using GoogleMobileAds.Api;
using UnityEngine;

/// <summary>
/// Loads and displays an AdMob Medium Rectangle (MREC) banner ad.
/// Managed by AdsManager. One instance is reused across every screen that
/// wants an MREC — call MoveTo(...) + Show() when a screen becomes active,
/// and Hide() when it's no longer needed, instead of reloading the ad.
/// </summary>
public class MRecAdHandler : MonoBehaviour
{
    private BannerView _mrecView;

    public void LoadAd()
    {
        Debug.Log("[MRecAdHandler] LoadAd() called.");
        DestroyAd();

        _mrecView = new BannerView(AdUnitIds.MRec, AdSize.MediumRectangle, AdPosition.Bottom);

        _mrecView.OnBannerAdLoaded += () => Debug.Log("[MRecAdHandler] Ad loaded.");
        _mrecView.OnBannerAdLoadFailed += (LoadAdError error) =>
            Debug.LogWarning("[MRecAdHandler] Load failed: " + error);
        _mrecView.OnAdPaid += (AdValue value) =>
            Debug.Log($"[MRecAdHandler] Paid {value.Value} {value.CurrencyCode}");

        AdRequest request = new AdRequest();
        _mrecView.LoadAd(request);
    }

    public void Show()
    {
        if (_mrecView == null)
        {
            Debug.LogWarning("[MRecAdHandler] Show() called but no ad is loaded yet.");
            return;
        }

        Debug.Log("[MRecAdHandler] Show() called.");
        _mrecView.Show();
    }

    public void Hide()
    {
        if (_mrecView == null)
        {
            Debug.Log("[MRecAdHandler] Hide() called but no ad exists — nothing to hide.");
            return;
        }

        Debug.Log("[MRecAdHandler] Hide() called.");
        _mrecView.Hide();
    }

    /// <summary>
    /// Repositions the MREC to an exact pixel spot, given as a fraction of
    /// the real device screen (0-1), measured from the top-left corner —
    /// same convention as NativeAdHandler's custom position. Call this right
    /// before Show() whenever a different screen/panel wants the ad in a
    /// different spot; the underlying ad itself is not reloaded.
    /// </summary>
    public void MoveTo(float xPercent, float yPercent)
    {
        if (_mrecView == null)
        {
            Debug.LogWarning("[MRecAdHandler] MoveTo() called but no ad is loaded yet — position not applied.");
            return;
        }

        int x = Mathf.RoundToInt(Screen.width * xPercent);
        int y = Mathf.RoundToInt(Screen.height * yPercent);
        Debug.Log($"[MRecAdHandler] MoveTo({xPercent}, {yPercent}) -> pixel ({x}, {y}) on Screen {Screen.width}x{Screen.height}.");
        _mrecView.SetPosition(x, y);
    }

    public void DestroyAd()
    {
        if (_mrecView != null)
        {
            Debug.Log("[MRecAdHandler] DestroyAd() — destroying existing ad.");
            _mrecView.Destroy();
            _mrecView = null;
        }
    }

    private void OnDestroy() => DestroyAd();
}