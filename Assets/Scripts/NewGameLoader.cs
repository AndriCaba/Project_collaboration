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
        StartCoroutine(LoadLevel("Tutorial Level"));
    }

    IEnumerator LoadLevel(string LevelName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        
        SceneManager.LoadScene(LevelName);
    }
}
