using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{
    public Transform[] waypoints;
    public float patrolSpeed = 2f;
    public float chaseSpeed = 5f;
    public float lineOfSight = 5f;
    public float shootingRange = 3f;
    public float fireRate = 1f;


    public GameObject bulletPrefab;
    public Transform bulletParent;


    private Animator animator;
    public float rotationSpeed;
    private Transform player;



    private int currentWaypointIndex = 0;
    private float nextFireTime;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Hit").transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distanceFromPlayer = Vector3.Distance(player.position, transform.position);



        if (distanceFromPlayer < lineOfSight && distanceFromPlayer > shootingRange)
        {
            // Chase the player
            
     
            ChasePlayer();
         
        }
        else if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
        {
            // Chase the player
          
          
            ChasePlayer();

            // Shoot
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
        else
        {

            // Patrol between waypoints
            animator.SetBool("IsMoving", false);
            Patrol();
        }
    }

    void Patrol()
    {
        // Move towards the current waypoint
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, patrolSpeed * Time.deltaTime);

        // Check if the enemy has reached the current waypoint
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            // Move to the next waypoint
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    void ChasePlayer()
    {
        // Move towards the player
        animator.SetBool("IsMoving", true);
       
        transform.position    = Vector3.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
        

    }

    void Shoot()
    {


        Instantiate(bulletPrefab, bulletParent.position, Quaternion.identity);


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
