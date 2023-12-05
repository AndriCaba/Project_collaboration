using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static System.TimeZoneInfo;
using UnityEngine.SceneManagement;

public class ObjectSelector : MonoBehaviour
{
    

    public LockOnCamera cameraController; // Reference to your camera controller script
    public LayerMask selectableObjectsLayer; // Layer mask for selectable objects
    public GameObject canvas; // The canvas to show/hide when an object is selected

    public bool scriptEnabled;

    private bool isCanvasVisible = false; // Track the canvas visibility



    private void Start()
    {
        LockOnCamera LockCamera = cameraController.GetComponent<LockOnCamera>();
        LockCamera.enabled = false;
        canvas.SetActive(false); // Initially hide the canvas
    }

    private void Update()
    {
        LockOnCamera LockCamera = cameraController.GetComponent<LockOnCamera>();
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
          
            LockCamera.enabled = true;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, selectableObjectsLayer))
            {
                Transform selectedObject = hit.transform;

                // Toggle canvas visibility when an object is selected
                isCanvasVisible = !isCanvasVisible;
                canvas.SetActive(isCanvasVisible);
               

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
            LockCamera.enabled = false;
            canvas.SetActive(false);
            isCanvasVisible = false;
            cameraController.ClearTarget();
      
        }
    }
}
