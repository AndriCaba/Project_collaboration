using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public void GoNextScene()
    {
        StartCoroutine(LoadNewLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void RestartButton()
    {
        StartCoroutine(LoadNewLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void MainMenuFromLevel1()
    {
        StartCoroutine(LoadNewLevel(SceneManager.GetActiveScene().buildIndex - 2));
    }

    public void MainMenuFromLevel2()
    {
        StartCoroutine(LoadNewLevel(SceneManager.GetActiveScene().buildIndex - 3));
    }

    IEnumerator LoadNewLevel(int LevelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        
        SceneManager.LoadScene(LevelIndex);
    }
}
