using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GazeTimer : MonoBehaviour
{
    public float gazeDuration = 3f; // Time required for full fill
    private float gazeTimer = 0f;
    private bool isGazing = false;

    public Image ringImage; // Assign your ring sprite in the inspector

    void Start()
    {
        // Ensure ring starts empty
        if (ringImage) ringImage.fillAmount = 0f;
    }

    void Update()
    {
        if (isGazing)
        {
            gazeTimer += Time.deltaTime;

            // Fill the ring over gazeDuration (3s)
            if (ringImage) ringImage.fillAmount = Mathf.Clamp01(gazeTimer / gazeDuration);

            if (gazeTimer >= gazeDuration)
            {
                DeactivateObject();
            }
        }
    }

    // Call this when gaze starts
    public void StartGaze()
    {
        isGazing = true;
        gazeTimer = 0f; // Reset timer
        if (ringImage) ringImage.fillAmount = 0f; // Reset fill
    }

    // Call this when gaze stops
    public void StopGaze()
    {
        isGazing = false;
        gazeTimer = 0f; // Reset timer
        if (ringImage) ringImage.fillAmount = 0f; // Reset fill
    }

    // Deactivate the object when gaze completes
    void DeactivateObject()
    {
        Debug.Log("Gaze selection activated on: " + gameObject.name);
        gameObject.SetActive(false); // Deactivate the object
    }
}

