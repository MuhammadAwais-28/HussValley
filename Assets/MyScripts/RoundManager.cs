using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private ChaserSpawner chaserSpawner;
    [SerializeField] private MonoBehaviour playerController;

    [Header("Caught Panel")]
    [SerializeField] private GameObject roundFailedPanel;
    [SerializeField] private Button caughtRestartButton;
    [SerializeField] private Button caughtHomeButton;

    [Header("Level Finish Panel")]
    [SerializeField] private GameObject levelCompletePanel;
    [SerializeField] private Button finishNextRoundButton;
    [SerializeField] private Button finishHomeButton;

    [Header("Scenes")]
    [SerializeField] private string homeSceneName = "HomeScene";

    private bool roundEnded;
    private bool restartRequested;
    private bool adBusy;

    private void Start()
    {
        Time.timeScale = 1f;

        if (roundFailedPanel != null)
            roundFailedPanel.SetActive(false);

        if (levelCompletePanel != null)
            levelCompletePanel.SetActive(false);

        // Show rewarded ad before restart
        if (caughtRestartButton != null)
            caughtRestartButton.onClick.AddListener(OnRestartWithAd);

        if (finishNextRoundButton != null)
            finishNextRoundButton.onClick.AddListener(GoToDifficultySelection);

        if (caughtHomeButton != null)
            caughtHomeButton.onClick.AddListener(GoHome);

        if (finishHomeButton != null)
            finishHomeButton.onClick.AddListener(GoHome);
    }

    private void Update()
    {
        if (restartRequested)
        {
            restartRequested = false;
            adBusy = false;
            RestartScene();
        }
    }

    private void OnRestartWithAd()
    {
        if (adBusy)
            return;

        adBusy = true;

        if (AdsManager.Instance == null)
        {
            Debug.LogWarning("AdsManager missing - restarting without ad");
            restartRequested = true;
            return;
        }

        AdsManager.Instance.ShowRewarded(
            () =>
            {
                // Fires once when the ad closes, fails, or is blocked
                Debug.Log("Ad complete/closed");
                restartRequested = true;
            },
            () =>
            {
                Debug.Log("Ad reward earned");
            }
        );
    }

    private void OnEnable()
    {
        ChaserAI.OnPlayerCaught += HandleCaught;
    }

    private void OnDisable()
    {
        ChaserAI.OnPlayerCaught -= HandleCaught;
    }

    private void HandleCaught()
    {
        if (roundEnded)
            return;

        EndRound();

        Debug.Log("Round failed - game stopped");

        if (roundFailedPanel != null)
            roundFailedPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void CompleteLevel()
    {
        if (roundEnded)
            return;

        EndRound();

        Debug.Log("Level completed");

        if (levelCompletePanel != null)
            levelCompletePanel.SetActive(true);

        Time.timeScale = 0f;
    }

    private void EndRound()
    {
        roundEnded = true;

        if (chaserSpawner != null)
            chaserSpawner.StopAllChasers();

        if (playerController != null)
            playerController.enabled = false;
    }

    public void RestartScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoHome()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(homeSceneName);
    }

    public void GoToDifficultyPanel()
    {
        PlayerPrefs.SetInt("OpenDifficultyPanel", 1);

        Time.timeScale = 1f;
        SceneManager.LoadScene(homeSceneName);
    }

    public void GoToDifficultySelection()
    {
        PlayerPrefs.SetInt("OpenDifficultyPanel", 1);

        Time.timeScale = 1f;
        SceneManager.LoadScene(homeSceneName);
    }
}