using UnityEngine;

public enum GameMode { Normal = 0, Medium = 1, Hard = 2 }

public static class GameSession
{
    public static GameMode SelectedMode
    {
        get { return (GameMode)Mathf.Clamp(PlayerPrefs.GetInt("SelectedDifficulty", 0), 0, 2); }
        set { PlayerPrefs.SetInt("SelectedDifficulty", (int)value); }
    }

    public static int ChaserCount
    {
        get
        {
            switch (SelectedMode)
            {
                case GameMode.Medium: return 3;
                case GameMode.Hard: return 6;
                default: return 1;
            }
        }
    }
}