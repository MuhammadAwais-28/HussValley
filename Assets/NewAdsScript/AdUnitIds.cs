using UnityEngine;

public static class AdUnitIds
{
#if UNITY_ANDROID

    // =========================
    // PRODUCTION AD UNIT IDS
    // =========================

    private const string ProdBanner = "ca-app-pub-5440548834626819/1381497798"; // Top Left Banner
    private const string ProdBannerRight = "ca-app-pub-5440548834626819/5119938963"; // Top Right Banner

    private const string ProdInterstitial = "ca-app-pub-5440548834626819/1428105960";

    private const string ProdRewarded = "ca-app-pub-5440548834626819/1647597819";

    private const string ProdAppOpen = "ca-app-pub-5440548834626819/2698001786";

    private const string ProdMRec = "unused"; // No MREC ID provided

    private const string ProdNative = "ca-app-pub-5440548834626819/7801942628";

    private const string ProdRewardedInterstitial = "ca-app-pub-5440548834626819/9334516148";

#elif UNITY_IOS

    // =========================
    // iOS PRODUCTION IDS
    // Replace with your real iOS IDs
    // =========================

    private const string ProdBanner = "ca-app-pub-0000000000000000/6666666666";
    private const string ProdBannerRight = "ca-app-pub-0000000000000000/6666666667";

    private const string ProdInterstitial = "ca-app-pub-0000000000000000/7777777777";

    private const string ProdRewarded = "unused";

    private const string ProdAppOpen = "ca-app-pub-0000000000000000/9999999999";

    private const string ProdMRec = "unused";

    private const string ProdNative = "unused";

    private const string ProdRewardedInterstitial = "ca-app-pub-0000000000000000/1515151515";

#else

    private const string ProdBanner = "unused";
    private const string ProdBannerRight = "unused";
    private const string ProdInterstitial = "unused";
    private const string ProdRewarded = "unused";
    private const string ProdAppOpen = "unused";
    private const string ProdMRec = "unused";
    private const string ProdNative = "unused";
    private const string ProdRewardedInterstitial = "unused";

#endif

#if UNITY_IOS

    // =========================
    // TEST IDS (iOS)
    // =========================

    private const string TestBanner = "ca-app-pub-3940256099942544/2934735716";
    private const string TestBannerRight = "ca-app-pub-3940256099942544/2934735716";

    private const string TestInterstitial = "ca-app-pub-3940256099942544/4411468910";

    private const string TestRewarded = "ca-app-pub-3940256099942544/1712485313";

    private const string TestAppOpen = "ca-app-pub-3940256099942544/5575463023";

    private const string TestMRec = "ca-app-pub-3940256099942544/2934735716";

    private const string TestNative = "ca-app-pub-3940256099942544/3986624511";

    private const string TestRewardedInterstitial = "ca-app-pub-3940256099942544/6978759866";

#else

    // =========================
    // TEST IDS (Android / Editor)
    // =========================

    private const string TestBanner = "ca-app-pub-3940256099942544/6300978111";

    private const string TestBannerRight = "ca-app-pub-3940256099942544/6300978111";

    private const string TestInterstitial = "ca-app-pub-3940256099942544/1033173712";

    private const string TestRewarded = "ca-app-pub-3940256099942544/5224354917";

    private const string TestAppOpen = "ca-app-pub-3940256099942544/9257395921";

    private const string TestMRec = "ca-app-pub-3940256099942544/6300978111";

    private const string TestNative = "ca-app-pub-3940256099942544/2247696110";

    private const string TestRewardedInterstitial = "ca-app-pub-3940256099942544/5354046379";

#endif

    // =========================
    // TEST MODE CONTROL
    // =========================

    public static bool UseTestAds =
#if UNITY_EDITOR || DEVELOPMENT_BUILD
        true;
#else
        false;
#endif

    // =========================
    // PUBLIC ACCESSORS
    // =========================

    public static string Banner =>
        UseTestAds ? TestBanner : ProdBanner;

    public static string BannerRight =>
        UseTestAds ? TestBannerRight : ProdBannerRight;

    public static string Interstitial =>
        UseTestAds ? TestInterstitial : ProdInterstitial;

    public static string Rewarded =>
        UseTestAds ? TestRewarded : ProdRewarded;

    public static string AppOpen =>
        UseTestAds ? TestAppOpen : ProdAppOpen;

    public static string MRec =>
        UseTestAds ? TestMRec : ProdMRec;

    public static string Native =>
        UseTestAds ? TestNative : ProdNative;

    public static string RewardedInterstitial =>
        UseTestAds ? TestRewardedInterstitial : ProdRewardedInterstitial;

#if UNITY_EDITOR
    [RuntimeInitializeOnLoadMethod]
    private static void LogActiveMode()
    {
        Debug.Log(
            $"[AdUnitIds] UseTestAds = {UseTestAds} " +
            "(Editor/Development Builds use Google test ads)"
        );
    }
#endif
}