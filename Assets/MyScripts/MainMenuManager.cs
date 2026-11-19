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
    public GameObject levelSelectionPanel;
    public GameObject truckSelectionPanel;
    public GameObject difficultySelectionPanel;

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

    [Header("Level Selection")]
    public Button[] levelButtons;

    private int selectedLevelIndex = -1;

    [Header("Truck Selection")]
    public Button[] truckSelectButtons;

    private int selectedTruckIndex = -1;

    [Header("Scene Settings")]
    public string gameSceneName = "GamePlayScene";


    [Header("Difficulty Selection")]
    public Button[] difficultyButtons;

    private int selectedDifficultyIndex = -1;

    private void Start()
    {
        if (PlayerPrefs.GetInt("OpenDifficultyPanel", 0) == 1)
        {
            PlayerPrefs.DeleteKey("OpenDifficultyPanel");
            ShowPanel(difficultySelectionPanel);
        }
        else
        {
            ShowPanel(playScreenPanel);
        }

        if (playButton != null)
            playButton.onClick.AddListener(OnPlayPressed);

        if (exitButton != null)
            exitButton.onClick.AddListener(OnExitPressed);

        if (privacyPolicyButton != null)
            privacyPolicyButton.onClick.AddListener(OnPrivacyPolicyPressed);

        if (playerProfileSaveButton != null)
            playerProfileSaveButton.onClick.AddListener(OnPlayerProfileSavePressed);

        if (playerProfileBackButton != null)
            playerProfileBackButton.onClick.AddListener(OnPlayerProfileBackPressed);

        if (flagSaveButton != null)
            flagSaveButton.onClick.AddListener(OnFlagSavePressed);

        if (flagBackButton != null)
            flagBackButton.onClick.AddListener(OnFlagBackPressed);

        if (flagButtons != null)
        {
            for (int i = 0; i < flagButtons.Length; i++)
            {
                int index = i;
                flagButtons[i].onClick.AddListener(() => OnFlagClicked(index));
            }
        }

        if (characterSelectButtons != null)
        {
            for (int i = 0; i < characterSelectButtons.Length; i++)
            {
                int index = i;
                characterSelectButtons[i].onClick.AddListener(() => OnCharacterSelected(index));
            }
        }

        if (levelButtons != null)
        {
            for (int i = 0; i < levelButtons.Length; i++)
            {
                int index = i;
                levelButtons[i].onClick.AddListener(() => OnLevelSelected(index));
            }
        }

        if (truckSelectButtons != null)
        {
            for (int i = 0; i < truckSelectButtons.Length; i++)
            {
                int index = i;
                truckSelectButtons[i].onClick.AddListener(() => OnTruckSelected(index));
            }
        }

        if (highlightBorders != null)
        {
            foreach (GameObject border in highlightBorders)
            {
                if (border != null)
                    border.SetActive(false);
            }
        }

        if (difficultyButtons != null)
        {
            for (int i = 0; i < difficultyButtons.Length; i++)
            {
                int index = i;
                difficultyButtons[i].onClick.AddListener(() => OnDifficultySelected(index));
            }
        }

    }

    // =========================
    // PLAY SCREEN
    // =========================

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
        Application.OpenURL(privacyPolicyUrl);
    }

    // =========================
    // PLAYER PROFILE
    // =========================

    public void OnPlayerProfileSavePressed()
    {
        string playerName = writeYourName.text.Trim();

        if (string.IsNullOrEmpty(playerName))
        {
            Debug.Log("Enter Player Name");
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

    // =========================
    // FLAG SELECTION
    // =========================

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
                highlightBorders[index].SetActive(true);
        }

        selectedFlagIndex = index;
    }

    public void OnFlagSavePressed()
    {
        if (selectedFlagIndex < 0)
        {
            Debug.Log("Select Flag First");
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

    // =========================
    // CHARACTER SELECTION
    // =========================

    private void OnCharacterSelected(int index)
    {
        selectedCharacterIndex = index;

        PlayerPrefs.SetInt("SelectedCharacter", index);
        PlayerPrefs.Save();

        Debug.Log("Selected Character : " + index);

        ShowPanel(levelSelectionPanel);
    }

    public void SelectCharacter(int index)
    {
        OnCharacterSelected(index);
    }

    // =========================
    // LEVEL SELECTION
    // =========================

    private void OnLevelSelected(int index)
    {
        selectedLevelIndex = index;

        PlayerPrefs.SetInt("SelectedLevel", index);
        PlayerPrefs.Save();

        Debug.Log("Selected Level : " + index);

        ShowPanel(difficultySelectionPanel);
    }

    public void SelectLevel(int index)
    {
        OnLevelSelected(index);
    }

    // =========================
    // TRUCK SELECTION
    // =========================

    private void OnTruckSelected(int index)
    {
        selectedTruckIndex = index;

        PlayerPrefs.SetInt("SelectedTruck", index);
        PlayerPrefs.Save();

        Debug.Log("Selected Truck : " + index);

        SceneManager.LoadScene(gameSceneName);
    }

    public void SelectTruck(int index)
    {
        OnTruckSelected(index);
    }



    // =========================
    // DIFFICULTY SELECTION
    // =========================

    private void OnDifficultySelected(int index)
    {
        selectedDifficultyIndex = index;
        GameSession.SelectedMode = (GameMode)index;
        PlayerPrefs.SetInt("SelectedDifficulty", index);
        PlayerPrefs.Save();

        Debug.Log("Selected Difficulty : " + index);

        SceneManager.LoadScene("GamePlayScene");
    }

    public void SelectDifficulty(int index)
    {
        OnDifficultySelected(index);
    }

    // =========================
    // PANEL MANAGEMENT
    // =========================




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

        if (levelSelectionPanel != null)
            levelSelectionPanel.SetActive(false);

        if (difficultySelectionPanel != null)
            difficultySelectionPanel.SetActive(false);

        if (panelToActivate != null)
            panelToActivate.SetActive(true);
    }

    public void GoToHomeScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("HomeScene");
    }
}