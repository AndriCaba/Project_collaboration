
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
        StartCoroutine(LoadNewLevel1(SceneManager.GetActiveScene().buildIndex + 1));
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Check if the player collided with the specific GameObject
        if (hit.gameObject.CompareTag("NextLevel"))
        {
            // Transition to the next scene
            StartCoroutine(LoadNewLevel2(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }
    IEnumerator LoadNewLevel1(int LevelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(LevelIndex);

        Time.timeScale = 0f;
        DisableKeyboardInput();
    }

    IEnumerator LoadNewLevel2(int LevelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(LevelIndex);
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
