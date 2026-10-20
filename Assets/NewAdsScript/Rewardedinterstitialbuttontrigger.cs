using UnityEngine;
using UnityEngine.Events;


public class RewardedInterstitialButtonTrigger : MonoBehaviour
{
    [Tooltip("Runs after the ad closes, fails, or isn't available.")]
    public UnityEvent onAdComplete;

    [Tooltip("Optional: runs only if the player watches the ad to completion.")]
    public UnityEvent onUserRewarded;

    // Hook this to the Button's OnClick() in the Inspector
    public void TriggerRewardedInterstitial()
    {
        if (AdsManager.Instance != null)
        {
            AdsManager.Instance.ShowRewardedInterstitial(
                onComplete: () => onAdComplete?.Invoke(),
                onUserRewarded: () => onUserRewarded?.Invoke()
            );
        }
        else
        {
            onAdComplete?.Invoke();
        }
    }
}