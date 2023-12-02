using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCUIAnimations : MonoBehaviour
{
    public Animator NPC_BG, NPC_Page1, NPC_Page2, NPC_NextButton, NPC_BackButton;
    private void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits an object
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the hit object is the one you want to trigger the popup
                if (hit.collider.gameObject == gameObject)
                {
                    TriggerInitialAnimations();
                }
            }
        }
    }
    public void TriggerInitialAnimations()
    {
        NPC_BG.SetTrigger("FadeIn");
        NPC_Page1.SetTrigger("SlideIn");
        NPC_NextButton.SetTrigger("SlideIn");
    }
    public void NextButtonClick()
    {
        NPC_NextButton.SetTrigger("OnClick");
        NPC_BackButton.SetTrigger("SlideIn");
        NPC_Page1.SetTrigger("OnClick");
        NPC_Page2.SetTrigger("OnClick");
    }
    public void BackButtonClick()
    {
        NPC_NextButton.SetTrigger("BackClick");
        NPC_BackButton.SetTrigger("OnClick");
        NPC_Page1.SetTrigger("BackClick");
        NPC_Page2.SetTrigger("BackClick");
    }
}
