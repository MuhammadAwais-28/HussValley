using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private ChaserSpawner chaserSpawner;
    [SerializeField] private MonoBehaviour playerController;
    [SerializeField] private GameObject roundFailedPanel;
    [SerializeField] private GameObject levelCompletePanel;   // optional for now

    private bool roundEnded;

    private void Start()
    {
        Time.timeScale = 1f;
        if (roundFailedPanel != null) roundFailedPanel.SetActive(false);
        if (levelCompletePanel != null) levelCompletePanel.SetActive(false);
    }

    private void OnEnable() { ChaserAI.OnPlayerCaught += HandleCaught; }
    private void OnDisable() { ChaserAI.OnPlayerCaught -= HandleCaught; }

    private void HandleCaught()
    {
        if (roundEnded) return;
        EndRound();

        Debug.Log("Round failed - game stopped");
        if (roundFailedPanel != null) roundFailedPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CompleteLevel()
    {
        if (roundEnded) return;   // can't win after being caught
        EndRound();

        Debug.Log("Level completed");
        if (levelCompletePanel != null) levelCompletePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    private void EndRound()
    {
        roundEnded = true;
        if (chaserSpawner != null) chaserSpawner.StopAllChasers();
        if (playerController != null) playerController.enabled = false;
    }
}