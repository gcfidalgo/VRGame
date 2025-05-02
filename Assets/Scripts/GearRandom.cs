using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearRandom : MonoBehaviour
{
    private float minRotationSpeed = 10f;
    private float maxRotationSpeed = 50f;
    
    private float minBobSpeed = 0.5f;
    private float maxBobSpeed = 2f;
    private float bobHeight = 0.5f;

    // Runtime variables
    private float rotationSpeedY;
    private float rotationSpeedZ;
    private float positionYSpeed;
    private int rotationYDirection;
    private int rotationZDirection;

    private Vector3 startPosition;
    private float bobTimer;

    private void Start()
    {
        // Store the starting position
        startPosition = transform.position;

        // Randomize all values
        RandomizeProperties();
    }

    private void RandomizeProperties()
    {
        // Random rotation speeds
        rotationSpeedY = Random.Range(minRotationSpeed, maxRotationSpeed);
        rotationSpeedZ = Random.Range(minRotationSpeed, maxRotationSpeed);

        // Random Y position bob speed
        positionYSpeed = Random.Range(minBobSpeed, maxBobSpeed);

        // Random rotation directions (1 or -1)
        rotationYDirection = Random.value > 0.5f ? 1 : -1;
        rotationZDirection = Random.value > 0.5f ? 1 : -1;

        // Random start position for bobbing
        bobTimer = Random.Range(0f, Mathf.PI * 2);
    }

    private void Update()
    {
        // Apply rotation around Y and Z axes
        transform.Rotate(0f, rotationSpeedY * rotationYDirection * Time.deltaTime, rotationSpeedZ * rotationZDirection * Time.deltaTime);

        // Update bob timer
        bobTimer += positionYSpeed * Time.deltaTime;

        float yOffset = Mathf.Sin(bobTimer) * bobHeight;
        transform.position = new Vector3(startPosition.x, startPosition.y + yOffset, startPosition.z);
    }

    public void Randomize()
    {
        RandomizeProperties();
    }

    public void ResetPosition()
    {
        transform.position = startPosition;
        bobTimer = 0f;
    }
}
