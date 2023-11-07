using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public EnemyInteraction enemyInteraction1;
    public EnemyInteraction enemyInteraction2;
    public EnemyInteraction enemyInteraction3;
    public OutlineSelection outlineSelection;
    public ObjectSelector objectSelector;
    public LockOnCamera lockOnCamera;

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
    public void Quit()
    {
        Debug.Log("QUITTING GAME...");
    }

    void EnableScriptsTRUE()
    {
        enemyInteraction1.enabled = true;
        enemyInteraction2.enabled = true;
        enemyInteraction3.enabled = true;
        outlineSelection.enabled = true;
        objectSelector.enabled = true;
        lockOnCamera.enabled = true;
    }
    void EnableScriptsFALSE()
    {
        enemyInteraction1.enabled = false;
        enemyInteraction2.enabled = false;
        enemyInteraction3.enabled = false;
        outlineSelection.enabled = false;
        objectSelector.enabled = false;
        lockOnCamera.enabled = false;
    }
}
