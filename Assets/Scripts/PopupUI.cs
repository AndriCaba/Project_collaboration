using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupUI : MonoBehaviour
{

    public GameObject popup; // Reference to your UI popup

    void Start()
    {
        // Disable the popup when the game starts
        popup.SetActive(false);
    }

    void Update()
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
                    // Show the popup
                    popup.SetActive(true);
                
                }
            }
        }

        // Check for the Escape button press
        if (Input.GetKeyDown(KeyCode.T))
        {
            // Close the popup
            Debug.Log("Time resumed");
     
            popup.SetActive(false);

        }
    }
    IEnumerator TimeStop()
    {


        yield return new WaitForSeconds(0.30f);

        Time.timeScale = 0f;
    }

    IEnumerator ResumeTime(float delay)
    {
        yield return new WaitForSeconds(delay);

        Time.timeScale = 3f;
    }

}
    