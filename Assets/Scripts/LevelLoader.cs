using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.TimeZoneInfo;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Check if the player collided with the specific GameObject
        if (hit.gameObject.CompareTag("NextLevel"))
        {
            // Transition to the next scene
            StartCoroutine(LoadNewLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }

    IEnumerator LoadNewLevel(int LevelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(LevelIndex);
    }
}
