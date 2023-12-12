using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadManager : MonoBehaviour
{
    private const string LEVEL_KEY = "SavedLevel";

    // Save the current level
    public void SaveLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt(LEVEL_KEY, currentLevel);
        PlayerPrefs.Save();

        Debug.Log("Level saved: " + currentLevel);
    }

    // Load and play the saved level
    public void LoadLevel()
    {
        if (PlayerPrefs.HasKey(LEVEL_KEY))
        {
            int savedLevel = PlayerPrefs.GetInt(LEVEL_KEY);
            SceneManager.LoadScene(savedLevel);

            Debug.Log("Level loaded: " + savedLevel);
        }
        else
        {
            Debug.LogWarning("No saved level found");
        }
    }

    // Clear the saved level (useful for resetting)
    public void ClearSavedLevel()
    {
        PlayerPrefs.DeleteKey(LEVEL_KEY);
        PlayerPrefs.Save();

        Debug.Log("Saved level cleared");
    }
}
