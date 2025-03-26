using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class CustomHapticScript : MonoBehaviour
{
    public XRController controller;  // Reference to the XR Controller

    // Send a low-amplitude haptic impulse
    public void LowA()
    {
        // Send haptic impulse if controller is valid
        if (controller)
        {
            controller.inputDevice.SendHapticImpulse(0, 0.1f, 1f); // (channel 0, amplitude, duration)
        }
    }

    public void MedA()
    {
        // Send haptic impulse if controller is valid
        if (controller)
        {
            controller.inputDevice.SendHapticImpulse(0, 0.5f, 1f); // (channel 0, amplitude, duration)
        }
    }

    public void HigA()
    {
        // Send haptic impulse if controller is valid
        if (controller)
        {
            controller.inputDevice.SendHapticImpulse(0, 1f, 1f); // (channel 0, amplitude, duration)
        }
    }
}
