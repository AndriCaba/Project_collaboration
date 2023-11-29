using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialLevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public void GoNextScene()
    {
        StartCoroutine(LoadNewLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadNewLevel(int LevelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(LevelIndex);

        Time.timeScale = 0f;
        DisableKeyboardInput();
    }

    public void DisableKeyboardInput()
    {
        Input.simulateMouseWithTouches = true;
    }

    public void EnableKeyboardInput()
    {
        Input.simulateMouseWithTouches = false;
    }
}
