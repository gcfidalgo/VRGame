using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatform : MonoBehaviour
{
    public float rotationSpeed = 30f; // Speed of rotation
    public float rotationTime = 2f; // Time spent rotating
    public float pauseTime = 2f; // Time spent paused

    private float timer = 0f;
    private bool isPaused = false;
    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = transform.rotation; // Store initial rotation
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (!isPaused)
        {
            // Rotate the platform
            transform.Rotate(rotationSpeed * Time.deltaTime, 0f, 0f);

            // If rotation time is up, pause and reset rotation
            if (timer >= rotationTime)
            {
                isPaused = true;
                timer = 0f;
                transform.rotation = initialRotation; // Reset rotation
            }
        }
        else
        {
            // Pause for the given duration
            if (timer >= pauseTime)
            {
                isPaused = false;
                timer = 0f; // Reset timer to start rotation again
            }
        }
    }
}