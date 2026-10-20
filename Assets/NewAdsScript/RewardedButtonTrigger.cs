using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Drop this on the Play button (or any button that should show a plain
/// rewarded ad instead of an interstitial or rewarded interstitial). Wire the
/// button's OnClick() to TriggerRewarded(). onAdComplete runs after the ad
/// closes, fails, or isn't available — put "start the game" there.
/// onUserRewarded only fires if the player watches the ad through to
/// completion — wire it up if you want to grant a bonus for that.
/// </summary>
public class RewardedButtonTrigger : MonoBehaviour
{
    [Tooltip("Runs after the ad closes, fails, or isn't available.")]
    public UnityEvent onAdComplete;

    [Tooltip("Runs only if the player watches the ad to completion.")]
    public UnityEvent onUserRewarded;

    // Hook this to the Button's OnClick() in the Inspector
    public void TriggerRewarded()
    {
        if (AdsManager.Instance != null)
        {
            AdsManager.Instance.ShowRewarded(
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