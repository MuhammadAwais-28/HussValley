using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject playScreenPanel;
    public GameObject playerProfilePanel;
    public GameObject flagSelectionPanel;
    public GameObject modeSelectionPanel;
    public GameObject levelSelectionPanel;

    [Header("Buttons")]
    public Button playButton;
    public Button exitButton;
    public Button privacyPolicyButton;

    public Button playerProfileSaveButton;
    public Button playerProfileBackButton;

    public Button flagSaveButton;
    public Button flagBackButton;

    public Button modeSelectConfirmButton;

    [Header("Privacy Policy Settings")]
    public string privacyPolicyUrl = "https://yourprivacyurl.com";

    [Header("Player Profile Settings")]
    public TMP_InputField writeYourName;

    [Header("Flag Selection Settings")]
    public Button[] flagButtons;
    public GameObject[] highlightBorders;
    private int selectedFlagIndex = -1;

    void Start()
    {
        ShowPanel(playScreenPanel);

        // Hook up buttons
        if (playButton != null) playButton.onClick.AddListener(OnPlayPressed);
        if (exitButton != null) exitButton.onClick.AddListener(OnExitPressed);
        if (privacyPolicyButton != null) privacyPolicyButton.onClick.AddListener(OnPrivacyPolicyPressed);

        if (playerProfileSaveButton != null) playerProfileSaveButton.onClick.AddListener(OnPlayerProfileSavePressed);
        if (playerProfileBackButton != null) playerProfileBackButton.onClick.AddListener(OnPlayerProfileBackPressed);

        if (flagSaveButton != null) flagSaveButton.onClick.AddListener(OnFlagSavePressed);
        if (flagBackButton != null) flagBackButton.onClick.AddListener(OnFlagBackPressed);

        if (modeSelectConfirmButton != null) modeSelectConfirmButton.onClick.AddListener(OnModeSelectConfirmPressed);

        // Flag button listeners
        if (flagButtons != null)
        {
            for (int i = 0; i < flagButtons.Length; i++)
            {
                int index = i;
                flagButtons[i].onClick.AddListener(() => OnFlagClicked(index));
            }
        }

        // Hide all flag borders initially
        if (highlightBorders != null)
        {
            foreach (var border in highlightBorders)
            {
                border.SetActive(false);
            }
        }
    }

    // --- PLAY SCREEN ---
    public void OnPlayPressed()
    {
        ShowPanel(playerProfilePanel);
    }

    public void OnExitPressed()
    {
        Application.Quit();
    }

    public void OnPrivacyPolicyPressed()
    {
        if (!string.IsNullOrEmpty(privacyPolicyUrl))
        {
            Application.OpenURL(privacyPolicyUrl);
        }
    }

    // --- PLAYER PROFILE SCREEN ---
    public void OnPlayerProfileSavePressed()
    {
        ShowPanel(flagSelectionPanel);
    }

    public void OnPlayerProfileBackPressed()
    {
        ShowPanel(playScreenPanel);
    }

    // --- FLAG SELECTION SCREEN ---
    public void OnFlagSavePressed()
    {
        // Only allow save if a flag is selected
        if (selectedFlagIndex >= 0)
        {
            ShowPanel(modeSelectionPanel);
        }
        else
        {
            Debug.Log("Please select a flag before continuing.");
        }
    }

    public void OnFlagBackPressed()
    {
        ShowPanel(playerProfilePanel);
    }

    private void OnFlagClicked(int index)
    {
        for (int i = 0; i < highlightBorders.Length; i++)
        {
            highlightBorders[i].SetActive(false);
        }

        highlightBorders[index].SetActive(true);
        selectedFlagIndex = index;


        Debug.Log($"Clicked flag index: {index}, Activated border index: {index}");
    }

    // --- MODE SELECTION SCREEN ---
    public void OnModeSelectConfirmPressed()
    {
        ShowPanel(levelSelectionPanel);
    }

    // --- LEVEL SELECTION SCREEN ---
    public void LoadGameplayScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // --- HELPER ---
    private void ShowPanel(GameObject panelToActivate)
    {
        if (playScreenPanel != null) playScreenPanel.SetActive(false);
        if (playerProfilePanel != null) playerProfilePanel.SetActive(false);
        if (flagSelectionPanel != null) flagSelectionPanel.SetActive(false);
        if (modeSelectionPanel != null) modeSelectionPanel.SetActive(false);
        if (levelSelectionPanel != null) levelSelectionPanel.SetActive(false);

        if (panelToActivate != null)
        {
            panelToActivate.SetActive(true);
        }
    }
}
