using UnityEngine;
using UnityEngine.UI;

public class EnemyInteraction : MonoBehaviour
{
    public GameObject uiElement; // Reference to your UI element (Image or Text)
    private bool isUIVisible = false;
    private static GameObject currentFocusedEnemy; // Track the currently focused enemy

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.collider.gameObject;

                if (clickedObject == gameObject && !isUIVisible) // Check if the object clicked is the enemy and UI is not visible
                {
                    ToggleUIElement();
                }
            }
        }

        if (Input.GetMouseButtonDown(1)) // Right mouse button
        {
            if (currentFocusedEnemy != null)
            {
                currentFocusedEnemy.GetComponent<EnemyInteraction>().ToggleUIElement();
                currentFocusedEnemy = null;
            }
        }
    }

    void ToggleUIElement()
    {
        if (isUIVisible)
        {
            isUIVisible = false;
            uiElement.SetActive(false);
        }
        else
        {
            isUIVisible = true;
            uiElement.SetActive(true);

            if (currentFocusedEnemy != null && currentFocusedEnemy != gameObject)
            {
                currentFocusedEnemy.GetComponent<EnemyInteraction>().ToggleUIElement();
            }

            currentFocusedEnemy = gameObject;
        }
    }
}
