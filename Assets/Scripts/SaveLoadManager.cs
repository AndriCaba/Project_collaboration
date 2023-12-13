using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveLoadManager : MonoBehaviour
{
    private const string LEVEL_KEY = "SavedLevel";
    public Text Leveltext;
    public GameObject LevelObject;

    // Save the current level
    public void SaveLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt(LEVEL_KEY, currentLevel);
        PlayerPrefs.Save();

        Leveltext.text = "Level saved: " + currentLevel;
        LevelObject.SetActive(true);
        StartCoroutine(WaitForDisable());
    }
    IEnumerator WaitForDisable()
    {
        yield return new WaitForSeconds(3f);
        LevelObject.SetActive(false);
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
