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
    public GameObject characterSelectionPanel;
    public GameObject truckSelectionPanel;

    [Header("Main Menu Buttons")]
    public Button playButton;
    public Button exitButton;
    public Button privacyPolicyButton;

    [Header("Player Profile Buttons")]
    public Button playerProfileSaveButton;
    public Button playerProfileBackButton;

    [Header("Flag Selection Buttons")]
    public Button flagSaveButton;
    public Button flagBackButton;

    [Header("Privacy Policy Settings")]
    public string privacyPolicyUrl = "https://samtechnologiesgamingstudio.blogspot.com/p/privacy-policy.html";

    [Header("Player Profile Settings")]
    public TMP_InputField writeYourName;

    [Header("Flag Selection Settings")]
    public Button[] flagButtons;
    public GameObject[] highlightBorders;

    private int selectedFlagIndex = -1;

    [Header("Character Selection")]
    public Button[] characterSelectButtons;

    private int selectedCharacterIndex = -1;

    [Header("Truck Selection")]
    public Button[] truckSelectButtons;

    private int selectedTruckIndex = -1;

    [Header("Scene Settings")]
    public string gameSceneName = "GameScene";

    private void Start()
    {
        // Show first panel
        ShowPanel(playScreenPanel);

        // Main Menu Buttons
        if (playButton != null)
            playButton.onClick.AddListener(OnPlayPressed);

        if (exitButton != null)
            exitButton.onClick.AddListener(OnExitPressed);

        if (privacyPolicyButton != null)
            privacyPolicyButton.onClick.AddListener(OnPrivacyPolicyPressed);

        // Profile Buttons
        if (playerProfileSaveButton != null)
            playerProfileSaveButton.onClick.AddListener(OnPlayerProfileSavePressed);

        if (playerProfileBackButton != null)
            playerProfileBackButton.onClick.AddListener(OnPlayerProfileBackPressed);

        // Flag Buttons
        if (flagSaveButton != null)
            flagSaveButton.onClick.AddListener(OnFlagSavePressed);

        if (flagBackButton != null)
            flagBackButton.onClick.AddListener(OnFlagBackPressed);

        // Flag Selection Listeners
        if (flagButtons != null)
        {
            for (int i = 0; i < flagButtons.Length; i++)
            {
                int index = i;
                flagButtons[i].onClick.AddListener(() => OnFlagClicked(index));
            }
        }

        // Character Selection Listeners
        if (characterSelectButtons != null)
        {
            for (int i = 0; i < characterSelectButtons.Length; i++)
            {
                int index = i;
                characterSelectButtons[i].onClick.AddListener(() => OnCharacterSelected(index));
            }
        }

        // Truck Selection Listeners
        if (truckSelectButtons != null)
        {
            for (int i = 0; i < truckSelectButtons.Length; i++)
            {
                int index = i;
                truckSelectButtons[i].onClick.AddListener(() => OnTruckSelected(index));
            }
        }

        // Hide all flag highlights initially
        if (highlightBorders != null)
        {
            foreach (GameObject border in highlightBorders)
            {
                if (border != null)
                    border.SetActive(false);
            }
        }
    }

    // ======================================================
    // PLAY SCREEN
    // ======================================================

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

    // ======================================================
    // PLAYER PROFILE SCREEN
    // ======================================================

    public void OnPlayerProfileSavePressed()
    {
        string playerName = writeYourName.text.Trim();

        if (string.IsNullOrEmpty(playerName))
        {
            Debug.Log("Please enter your name.");
            return;
        }

        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save();

        ShowPanel(flagSelectionPanel);
    }

    public void OnPlayerProfileBackPressed()
    {
        ShowPanel(playScreenPanel);
    }

    // ======================================================
    // FLAG SELECTION SCREEN
    // ======================================================

    private void OnFlagClicked(int index)
    {
        if (highlightBorders != null)
        {
            for (int i = 0; i < highlightBorders.Length; i++)
            {
                if (highlightBorders[i] != null)
                    highlightBorders[i].SetActive(false);
            }

            if (index < highlightBorders.Length)
            {
                highlightBorders[index].SetActive(true);
            }
        }

        selectedFlagIndex = index;

        Debug.Log("Selected Flag Index: " + index);
    }

    public void OnFlagSavePressed()
    {
        if (selectedFlagIndex < 0)
        {
            Debug.Log("Please select a flag before continuing.");
            return;
        }

        PlayerPrefs.SetInt("SelectedFlag", selectedFlagIndex);
        PlayerPrefs.Save();

        ShowPanel(characterSelectionPanel);
    }

    public void OnFlagBackPressed()
    {
        ShowPanel(playerProfilePanel);
    }

    // ======================================================
    // CHARACTER SELECTION SCREEN
    // ======================================================

    private void OnCharacterSelected(int index)
    {
        selectedCharacterIndex = index;

        PlayerPrefs.SetInt("SelectedCharacter", index);
        PlayerPrefs.Save();

        Debug.Log("Selected Character: " + index);

        ShowPanel(truckSelectionPanel);
    }

    // Optional: Use this directly from Inspector buttons
    public void SelectCharacter(int index)
    {
        OnCharacterSelected(index);
    }

    // ======================================================
    // TRUCK SELECTION SCREEN
    // ======================================================

    private void OnTruckSelected(int index)
    {
        selectedTruckIndex = index;

        PlayerPrefs.SetInt("SelectedTruck", index);
        PlayerPrefs.Save();

        Debug.Log("Selected Truck: " + index);

        SceneManager.LoadScene(gameSceneName);
    }

    // Optional: Use this directly from Inspector buttons
    public void SelectTruck(int index)
    {
        OnTruckSelected(index);
    }

    // ======================================================
    // PANEL MANAGEMENT
    // ======================================================

    private void ShowPanel(GameObject panelToActivate)
    {
        if (playScreenPanel != null)
            playScreenPanel.SetActive(false);

        if (playerProfilePanel != null)
            playerProfilePanel.SetActive(false);

        if (flagSelectionPanel != null)
            flagSelectionPanel.SetActive(false);

        if (characterSelectionPanel != null)
            characterSelectionPanel.SetActive(false);

        if (truckSelectionPanel != null)
            truckSelectionPanel.SetActive(false);

        if (panelToActivate != null)
            panelToActivate.SetActive(true);
    }


    public void GoToHomeScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("HomeScene");
    }
}