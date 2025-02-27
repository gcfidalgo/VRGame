using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnMove : MonoBehaviour
{
    public AudioSource audioSource; // Assign the AudioSource component in the Inspector
    private Vector3 lastPosition;
    public float movementThreshold = 0.01f; // Adjust this if movement is too sensitive

    void Start()
    {
        lastPosition = transform.position; // Store initial position
    }

    void Update()
    {
        float movement = Vector3.Distance(transform.position, lastPosition);

        if (movement > movementThreshold) // Detects even small movements
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play(); // Play sound when moving
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop(); // Stop sound when not moving
            }
        }

        lastPosition = transform.position; // Update position
    }
}
