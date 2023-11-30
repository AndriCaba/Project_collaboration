using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public GameObject objectToActivate;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Check if the player collided with the specific GameObject
        if (hit.gameObject.CompareTag("SpawnBoss"))
        {
            // Activate or turn on the specified GameObject
            objectToActivate.SetActive(true);
        }
    }
}
