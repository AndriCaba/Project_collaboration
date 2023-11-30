using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static System.TimeZoneInfo;
using UnityEngine.SceneManagement;

public class ObjectSelector : MonoBehaviour


{

    public Animator Card1, Card2, Card3, Card4, NPCui;

    public LockOnCamera cameraController; // Reference to your camera controller script
    public LayerMask selectableObjectsLayer; // Layer mask for selectable objects
    public GameObject canvas; // The canvas to show/hide when an object is selected

    public bool scriptEnabled;

    private bool isCanvasVisible = false; // Track the canvas visibility

    private void Start()
    {
        canvas.SetActive(false); // Initially hide the canvas
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, selectableObjectsLayer))
            {
                Transform selectedObject = hit.transform;

                // Toggle canvas visibility when an object is selected
                isCanvasVisible = !isCanvasVisible;
                canvas.SetActive(isCanvasVisible);
                Card1.SetTrigger("OnClick");
                Card2.SetTrigger("OnClick");
                Card3.SetTrigger("OnClick");
                Card4.SetTrigger("OnClick");
                NPCui.SetTrigger("OnClick");
                StartCoroutine(TimeStop());

                if (!selectedObject.CompareTag("Untargetable"))
                {
                    cameraController.SetTarget(selectedObject);
                }
            }

            if (PauseMenu.GameIsPaused == true)
            {
                ObjectSelector objectSelector = GetComponent<ObjectSelector>();
                objectSelector.enabled = false;
            }
            if (PauseMenu.GameIsPaused == false)
            {
                ObjectSelector objectSelector = GetComponent<ObjectSelector>();
                objectSelector.enabled = true;
            }
        }

        if (Input.GetMouseButtonDown(1)) // Right mouse button click to clear the target
        {
            canvas.SetActive(false);
            isCanvasVisible = false;
            cameraController.ClearTarget();
            Card1.SetTrigger("OnUnClick");
            Card2.SetTrigger("OnUnClick");
            Card3.SetTrigger("OnUnClick");
            Card4.SetTrigger("OnUnClick");
        }
    }

    IEnumerator TimeStop()
    {
        NPCui.SetTrigger("SlideIn");

        yield return new WaitForSeconds(0.30f);

        Time.timeScale = 0f;
    }

    public void NextClick()
    {
        NPCui.SetTrigger("NextClick");
    }
}
