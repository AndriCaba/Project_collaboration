using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.TimeZoneInfo;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public OutlineSelection outlineSelection;
    public ObjectSelector objectSelector;
    public LockOnCamera lockOnCamera;
    public Animator transition;
    public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                EnableScriptsTRUE();
                Resume();
            }
            else
            {
                EnableScriptsFALSE();
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        EnableScriptsTRUE();
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Save()
    {

    }
    public void Settings()
    {

    }
    
    public void QuitFromTutorial()
    {
        StartCoroutine(LoadPreviousLevel(SceneManager.GetActiveScene().buildIndex - 1));
        Resume();
    }
    public void QuitFromLevel1()
    {
        StartCoroutine(LoadPreviousLevel(SceneManager.GetActiveScene().buildIndex - 2));
        Resume();
    }
    public void QuitFromLevel2()
    {
        StartCoroutine(LoadPreviousLevel(SceneManager.GetActiveScene().buildIndex - 3));
        Resume();
    }

    void EnableScriptsTRUE()
    {
        outlineSelection.enabled = true;
        objectSelector.enabled = true;
        lockOnCamera.enabled = true;
    }
    void EnableScriptsFALSE()
    {
        outlineSelection.enabled = false;
        objectSelector.enabled = false;
        lockOnCamera.enabled = false;
    }

    IEnumerator LoadPreviousLevel(int LevelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(LevelIndex);
    }
}
