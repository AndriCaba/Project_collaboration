using Cinemachine;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public GameObject FootstepsAudio;
    public GameObject RollSoundEffect;

    public CinemachineVirtualCamera virtualCamera;
    public Transform Camera;

    public float speed;
    public float rotationSpeed;

    public float camRotationSpeed;

    public float dashSpeed;
    public float dashTime;

    CharacterController characterController;
    private Animator animator;

    public KeyCode keyToDisable = KeyCode.Space;
    public float disableTime; // The time in seconds to disable the key
    private bool isKeyDisabled = false;
    private float disableTimer = 0.0f;

    private Quaternion targetCameraRotation;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        RollSoundEffect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 cameraForward = Camera.forward;
        cameraForward.y = 0f;

        Vector3 movementDirection = (cameraForward.normalized * verticalInput + Camera.right.normalized * horizontalInput);

        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();

        characterController.SimpleMove(movementDirection * magnitude);

        if (movementDirection != Vector3.zero)
        {
            animator.SetBool("IsMoving", true);
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

            FootstepsAudio.SetActive(true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
            FootstepsAudio.SetActive(false);
        }

        if (isKeyDisabled)
        {
            // Key is disabled, count down the timer
            disableTimer -= Time.deltaTime;
            animator.SetBool("IsRolling", false);

            // If the timer reaches 0 or less, re-enable the key
            if (disableTimer <= 0)
            {
                RollSoundEffect.SetActive(false);
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
                RollSoundEffect.SetActive(true);
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

        if (Input.GetKey(KeyCode.Q))
        {
            RotateCamera(-1); // Rotate left
        }
        else if (Input.GetKey(KeyCode.E))
        {
            RotateCamera(1); // Rotate right
        }

        // Smoothly rotate the camera
        virtualCamera.transform.rotation = Quaternion.Slerp(virtualCamera.transform.rotation, targetCameraRotation, camRotationSpeed * Time.deltaTime);
    }

    void RotateCamera(int direction)
    {
        // Adjust the camera's rotation around the y-axis
        Vector3 currentRotation = virtualCamera.transform.rotation.eulerAngles;
        float newYRotation = currentRotation.y + direction * camRotationSpeed * Time.deltaTime;

        targetCameraRotation = Quaternion.Euler(currentRotation.x, newYRotation, currentRotation.z);
    }
}
