using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelection : MonoBehaviour
{
    public int[] ID; // Array to store multiple IDs
    private int currentIdIndex = 0;
    public int objectID;

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collider that hit the enemy has a specific tag
        if (collision.gameObject.CompareTag("Player"))
        {
            // Check if the ID array is not null and has elements
            if (ID != null && ID.Length > 0)
            {
                // Cycle to the next ID
                CycleToNextId();
            }
            else
            {
                Debug.LogError("ID array is null or empty.");
            }
        }
    }

    void CycleToNextId()
    {
        // Check if the ID array is not null and has elements
        if (ID != null && ID.Length > 0)
        {
            // Increment the index to move to the next ID
            currentIdIndex = (currentIdIndex + 1) % ID.Length;

            // Access and use the current ID (replace this with your logic)
            objectID = ID[currentIdIndex];
            Debug.Log("Selected ID: " + objectID);
        }
        else
        {
            Debug.LogError("ID array is null or empty.");
        }
    }
}
