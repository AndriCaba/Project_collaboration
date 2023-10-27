using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 1.5f; // Range of the attack
    public int attackDamage = 10; // Damage dealt per attack
    public LayerMask enemyLayer; // Layer containing the enemy objects

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) // You can change "Fire1" to the input you want to use for attacking (e.g., "Mouse0" for mouse click)
        {
            Attack();
        }
    }

    void Attack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);
        Debug.Log("attacking the enemy");

        foreach (Collider enemy in hitEnemies)
        {

           
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackDamage);
            }
        }
    }
  
}
