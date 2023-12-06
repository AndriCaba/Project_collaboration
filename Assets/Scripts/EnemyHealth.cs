using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public Healthbar healthbar;

    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
            
        }
    }

    void Die()
    {
        // Implement enemy death behavior here, such as playing an animation, spawning effects, or destroying the enemy object.
        Destroy(gameObject);
    }
}

