using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{

    // Load the specified scene by name
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Load the previous scene
    public void GoBackToPreviousScene()
    {
        // Get the index of the current scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;


        // Load the previous scene (subtract 1 from the current index)
        SceneManager.LoadScene(currentSceneIndex - 1);

        PauseMenu.GameIsPaused = false;
    }

}
