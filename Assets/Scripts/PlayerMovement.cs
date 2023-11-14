using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    Vector3 velocity; // Gravity

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask; // Only want to check for ground
    bool isGrounded;

    bool isCrouching = false;

     // Smooth transition variables
    private float targetHeight;
    private float originalHeight;
    private float transitionStartTime;
    private float transitionDuration = 0.3f; // Adjust the duration as needed for the smooth transition.
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;

        // Check for crouch input
        if (Input.GetKeyDown(KeyCode.C))
        {
            isCrouching = !isCrouching;

            // Set your desired crouch and standing heights
            targetHeight = isCrouching ? 1.0f : 2.0f;
            originalHeight = controller.height;
            transitionStartTime = Time.time;

            // Smoothly adjust the character's height when transitioning
            StartCoroutine(AdjustCharacterHeight());
        }

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    // Coroutine for smooth height adjustment
    IEnumerator AdjustCharacterHeight()
    {
        float elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            float lerpFactor = elapsedTime / transitionDuration;
            controller.height = Mathf.Lerp(originalHeight, targetHeight, Mathf.SmoothStep(0f, 1f, lerpFactor));
            elapsedTime = Time.time - transitionStartTime;
            yield return null;
        }

        controller.height = targetHeight; // Ensure the final height is exactly the target height.
    }

}
