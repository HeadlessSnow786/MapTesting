using System.Collections;
using UnityEngine;

public class ViewBob : MonoBehaviour
{
    public float bobFrequency = 1.0f;       // Adjust the frequency of bobbing.
    public float bobAmplitude = 0.05f;      // Adjust the intensity of bobbing.
    public float idleSwayAmplitude = 0.02f; // Adjust the intensity of idle sway.
    public float moveThreshold = 0.1f;      // Adjust the threshold for detecting movement.

    private Vector3 originalPosition;
    private float timer = 0.0f;

    private void Start()
    {
        originalPosition = transform.localPosition;
    }

    private void Update()
{
    // Check for player movement input (adjust as needed based on your input system).
    float moveInput = Input.GetAxis("Vertical"); // Use the vertical input axis for movement.

    // Calculate the bobbing motion based on player movement.
    float horizontalBob = Mathf.Sin(timer) * bobAmplitude;
    float verticalBob = Mathf.Cos(timer * 2) * bobAmplitude;

    // Calculate the idle sway motion when the player is not moving.
    float idleSway = Mathf.Sin(timer * 0.5f) * idleSwayAmplitude;

    // Apply the bobbing and idle sway motion to the camera's position.
    Vector3 bobbingPosition = originalPosition + new Vector3(horizontalBob, verticalBob + idleSway, 0);
    transform.localPosition = Vector3.Lerp(transform.localPosition, bobbingPosition, Time.deltaTime * 5f); // Adjust the interpolation speed.

    // Increment the timer based on player movement or time.
    if (Mathf.Abs(moveInput) > moveThreshold)
    {
        timer += Time.deltaTime * bobFrequency;
    }
    else
    {
        // Gradually reset the timer to its initial value when not moving.
        timer = Mathf.Lerp(timer, 0.0f, Time.deltaTime * 5f); // Adjust the interpolation speed.
    }
}
}
