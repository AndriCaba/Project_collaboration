using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public CinemachineVirtualCamera virtualCamera;
    public Transform Camera;

    public float speed;
    public float rotationSpeed;

    //public KeyCode lookRightKey; // Key to make the camera look right
    //public KeyCode lookLeftKey; // Key to make the camera look left

    public float dashSpeed;
    public float dashTime;
    
    CharacterController characterController;
    private Animator animator;

    public KeyCode keyToDisable = KeyCode.Space;
    public float disableTime; // The time in seconds to disable the key
    private bool isKeyDisabled = false;
    private float disableTimer = 0.0f;


    // Start is called before the first frame update
    void Start()
    {   
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 cameraForward = Camera.forward;
        cameraForward.y = 0f;

        Vector3 movementDirection = (cameraForward.normalized * verticalInput  + Camera.right.normalized * horizontalInput);
        
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();

        characterController.SimpleMove(movementDirection * magnitude);

        if (movementDirection != Vector3.zero)
        {
            animator.SetBool("IsMoving", true);
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        if (isKeyDisabled)
        {
            // Key is disabled, count down the timer
            disableTimer -= Time.deltaTime;
            animator.SetBool("IsRolling", false);

            // If the timer reaches 0 or less, re-enable the key
            if (disableTimer <= 0)
            {
                isKeyDisabled = false;
            }
        }
        else
        {
            // Key is not disabled, check if the key is pressed
            if (Input.GetKeyDown(keyToDisable))
            {
                StartCoroutine(Dash());
                isKeyDisabled = true;
                animator.SetBool("IsRolling", true);
                disableTimer = disableTime;
            }

            IEnumerator Dash()
            {
                float startTime = Time.time;

                while (Time.time < startTime + dashTime)
                {
                    transform.Translate(Vector3.forward * dashSpeed);
                    yield return null;
                }
            }
        }
    }
}