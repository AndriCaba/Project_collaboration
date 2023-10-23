using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSelector : MonoBehaviour
{
    public LockOnCamera cameraController;
    public LayerMask selectableObjectsLayer;
    public GameObject canvas;

    public bool isCanvasVisible = false;

    private void Start()
    {
        canvas.SetActive(false);


    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0)) // Assuming left mouse button click.
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, selectableObjectsLayer))
            {
                Transform selectedObject = hit.transform;


                canvas.SetActive(true);



                if (!selectedObject.CompareTag("Untargetable"))
                {
                    cameraController.SetTarget(selectedObject);


                }

            }
            isCanvasVisible = !isCanvasVisible;

        }
        if (Input.GetMouseButtonDown(1)) // Assuming right mouse button click to clear the target.
        {
            canvas.SetActive(false);

            cameraController.ClearTarget();
        }
    }
}