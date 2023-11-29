using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unfreeze_EnableKeyboard : MonoBehaviour
{
    public void EnableKeyboard_Unfreeze()
    {
        TutorialLevelLoader tutorialLevelLoader = new TutorialLevelLoader();
        tutorialLevelLoader.EnableKeyboardInput();
        Time.timeScale = 1f;
    }
}
