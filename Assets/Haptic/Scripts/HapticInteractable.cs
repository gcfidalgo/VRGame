using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Haptic : MonoBehaviour
{

    // Low amplitude feedback
    public void LowA(XRBaseController controller)
    {
        SendHapticImpulse(controller, 0.1f, 1f);
    }

    // Medium amplitude feedback
    public void MedA(XRBaseController controller)
    {
        SendHapticImpulse(controller, 0.5f, 1f);
    }

    // High amplitude feedback
    public void HigA(XRBaseController controller)
    {
        SendHapticImpulse(controller, 1f, 1f);
    }

    // Helper method to send the haptic impulse
    private void SendHapticImpulse(XRBaseController controller, float amplitude, float duration)
    {
        if (controller != null)
        {
            controller.SendHapticImpulse(amplitude, duration);
        }
    }
}

