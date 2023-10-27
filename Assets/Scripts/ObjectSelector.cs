using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ObjectSelector : MonoBehaviour


{


    public LockOnCamera cameraController; // Reference to your camera controller script
    public LayerMask selectableObjectsLayer; // Layer mask for selectable objects
    public GameObject canvas; // The canvas to show/hide when an object is selected

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
               
                if (!selectedObject.CompareTag("Untargetable"))
                {
                    cameraController.SetTarget(selectedObject);
                }
            }
        }

        if (Input.GetMouseButtonDown(1)) // Right mouse button click to clear the target
        {
            canvas.SetActive(false);
            isCanvasVisible = false;
            cameraController.ClearTarget();
        }
    }
}
