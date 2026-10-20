using GoogleMobileAds.Api;
using UnityEngine;

public class BannerAdHandler : MonoBehaviour
{
    private BannerView _bannerView;
    public AdPosition bannerPosition = AdPosition.Top;


    public void LoadAd()
    {
        DestroyAd();

        _bannerView = new BannerView(AdUnitIds.Banner, AdSize.Banner, bannerPosition);

        _bannerView.OnBannerAdLoaded += () => Debug.Log("[BannerAdHandler] Ad loaded.");
        _bannerView.OnBannerAdLoadFailed += (LoadAdError error) =>
            Debug.LogWarning("[BannerAdHandler] Load failed: " + error);
        _bannerView.OnAdPaid += (AdValue value) =>
            Debug.Log($"[BannerAdHandler] Paid {value.Value} {value.CurrencyCode}");

        AdRequest request = new AdRequest();
        _bannerView.LoadAd(request);
    }

    public void Show()
    {
        _bannerView?.Show();
    }

    public void Hide()
    {
        _bannerView?.Hide();
    }

    public void DestroyAd()
    {
        if (_bannerView != null)
        {
            _bannerView.Destroy();
            _bannerView = null;
        }
    }

    private void OnDestroy() => DestroyAd();
}
