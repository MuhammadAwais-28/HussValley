using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Ump.Api;
#if UNITY_IOS
using Unity.Advertisement.IosSupport;
#endif


public class ConsentManager : MonoBehaviour
{
    public static bool CanRequestAds { get; private set; } = false;

    [Header("UI")]
    [SerializeField] private Slider loadingSlider;

    [Header("Scene Flow")]
    [SerializeField] private string nextSceneName = "MainMenu";
    [SerializeField] private float minLoadTime = 1f; 

    private bool consentDone = false;

    private void Start()
    {
        if (loadingSlider != null)
            loadingSlider.value = 0f;

#if UNITY_IOS
        RequestAppTrackingAuthorization();
#else
        RequestGoogleConsent();
#endif
        StartCoroutine(LoadNextSceneRoutine());
    }

#if UNITY_IOS
    private void RequestAppTrackingAuthorization()
    {
        if (ATTrackingStatusBinding.GetAuthorizationTrackingStatus() ==
            ATTrackingStatusBinding.AuthorizationTrackingStatus.NOT_DETERMINED)
        {
            ATTrackingStatusBinding.RequestAuthorizationTracking();
        }

        RequestGoogleConsent();
    }
#endif

    private void RequestGoogleConsent()
    {
        ConsentRequestParameters request = new ConsentRequestParameters();

        ConsentInformation.Update(request, (FormError error) =>
        {
            if (error != null)
            {
                Debug.LogWarning("[ConsentManager] Consent info update error: " + error.Message);
                FinishConsent();
                return;
            }

            if (ConsentInformation.IsConsentFormAvailable())
            {
                LoadConsentForm();
            }
            else
            {
                FinishConsent();
            }
        });
    }

    private void LoadConsentForm()
    {
        ConsentForm.Load((ConsentForm form, FormError error) =>
        {
            if (error != null)
            {
                Debug.LogWarning("[ConsentManager] Consent form load error: " + error.Message);
                FinishConsent();
                return;
            }

            if (ConsentInformation.ConsentStatus == ConsentStatus.Required ||
                ConsentInformation.ConsentStatus == ConsentStatus.Unknown)
            {
                form.Show((FormError showError) =>
                {
                    if (showError != null)
                    {
                        Debug.LogWarning("[ConsentManager] Consent form show error: " + showError.Message);
                    }
                    FinishConsent();
                });
            }
            else
            {
                FinishConsent();
            }
        });
    }

    private void FinishConsent()
    {
        CanRequestAds = true;
        consentDone = true;
    }

    private System.Collections.IEnumerator LoadNextSceneRoutine()
    {
        float elapsed = 0f;

        while (!consentDone)
        {
            elapsed += Time.deltaTime;
            if (loadingSlider != null)
                loadingSlider.value = Mathf.Min(0.5f, elapsed / minLoadTime * 0.5f);
            yield return null;
        }

        if (loadingSlider != null)
            loadingSlider.value = 0.5f;

        AsyncOperation op = SceneManager.LoadSceneAsync(nextSceneName);
        op.allowSceneActivation = false;

        while (op.progress < 0.9f)
        {
            if (loadingSlider != null)
                loadingSlider.value = 0.5f + Mathf.Clamp01(op.progress / 0.9f) * 0.5f;
            yield return null;
        }
        while (elapsed < minLoadTime)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }

        if (loadingSlider != null)
            loadingSlider.value = 1f;

        yield return new WaitForSeconds(0.2f);
        op.allowSceneActivation = true;

        /* op = null;
        if (!string.IsNullOrEmpty(nextSceneName) && nextSceneName != SceneManager.GetActiveScene().name)
        {
            op = SceneManager.LoadSceneAsync(nextSceneName);
            op.allowSceneActivation = false;
        } */

    }
}