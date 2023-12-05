using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cam;

    void Update()
    {
        // Ensure the camera reference is not null
        if (cam != null)
        {
            // Face the camera
            transform.LookAt(cam);
        }
        else
        {
            Debug.LogError("Camera reference is null. Assign the camera in the Inspector.");
        }
    }
}
