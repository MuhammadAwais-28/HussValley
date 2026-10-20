using UnityEngine;
using UnityEngine.Events;


public class InterstitialButtonTrigger : MonoBehaviour
{
    [Tooltip("Runs after the interstitial closes, fails, or isn't available.")]
    public UnityEvent onAdComplete;

    // Hook this to the Button's OnClick() in the Inspector
    public void TriggerInterstitial()
    {
        if (AdsManager.Instance != null)
        {
            AdsManager.Instance.ShowInterstitial(() => onAdComplete?.Invoke());
        }
        else
        {
            onAdComplete?.Invoke();
        }
    }
}