using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageCycle : MonoBehaviour
{

    public Sprite[] spriteList; // List of sprites to cycle through
    public GameObject targetObject; // Object whose SpriteRenderer will change

    private int currentSpriteIndex = 0;

    void Start()
    {
        // Check if the target object is assigned
        if (targetObject == null)
        {
            Debug.LogError("Target object is not assigned in the inspector!");
            return;
        }

        // Get the SpriteRenderer component from the target object
        SpriteRenderer targetSpriteRenderer = targetObject.GetComponent<SpriteRenderer>();

        // Check if the SpriteRenderer component is found
        if (targetSpriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on the target object!");
            return;
        }

        // Set the initial sprite
        targetSpriteRenderer.sprite = spriteList[currentSpriteIndex];
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get the SpriteRenderer component from the target object
            SpriteRenderer targetSpriteRenderer = targetObject.GetComponent<SpriteRenderer>();

            // Change the sprite of the target SpriteRenderer
            if (targetSpriteRenderer != null && spriteList.Length > 0)
            {
                // Increment the index to move to the next sprite in the list
                currentSpriteIndex = (currentSpriteIndex + 1) % spriteList.Length;

                // Set the new sprite on the target object's SpriteRenderer
                targetSpriteRenderer.sprite = spriteList[currentSpriteIndex];

                // Print debug information to the console
                Debug.Log("Sprite replaced with: " + targetSpriteRenderer.sprite.name);
            }
            else
            {
                // Print a warning if the SpriteRenderer or spriteList is not set up correctly
                Debug.LogWarning("SpriteRenderer or spriteList not set up correctly on the target object.");
            }
        }
    }
}
