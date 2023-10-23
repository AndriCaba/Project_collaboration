using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOnCamera : MonoBehaviour
{
    private Transform target; // The currently locked-on target.
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    public float smoothSpeed = 5f; // Adjust this to control camera follow speed.
    public Vector3 offset; // Offset from the target.


    private void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    private void LateUpdate()
    {
        if (target == null)
        {
            // Restore original position and rotation when untargeted.
            transform.position = originalPosition;
            transform.rotation = originalRotation;
            return;
        }

        // Calculate the desired camera position.
        Vector3 desiredPosition = target.position + offset;

        // Smoothly interpolate the current camera position towards the desired position.
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        transform.position = smoothedPosition;

        // Make the camera look at the target.
        transform.LookAt(target);
    }

    // Set the target when an object is clicked.
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
    public void ClearTarget()
    {
        target = null;
    }
}

