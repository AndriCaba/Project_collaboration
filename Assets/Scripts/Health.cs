using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public GameObject GameOverUI;
    public int maxHealth = 100; // Maximum health of the object
    public int currentHealth; // Current health of the object

    public Healthbar healthbar;

    public void Start()
    {
        currentHealth = maxHealth; // Set the initial health to the maximum health when the object is created
        healthbar.SetMaxHealth(maxHealth);
    }
    void Update()
    {

      

    
    }

    // Function to apply damage to the object
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();

        }
    }

    // Function to handle the death of the object
    private void Die()
    {
        // You can implement death behavior here, such as playing an animation, spawning effects, or destroying the object.
        Destroy(gameObject);
        GameOverUI.SetActive(true);
    }


}

