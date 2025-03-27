using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticGear : MonoBehaviour
{
    
    public bool version = false;
    //public XRGrabInteractable grab;

    //private void Awake()
    //{
    //    grab = GetComponent<XRGrabInteractable>();
    //    grab.selectEntered.AddListener(OnGearGrab);
    //}
    public void OnGearGrab(SelectEnterEventArgs args)
    {
        if (args.interactorObject is XRBaseControllerInteractor controllerInteractor)
        {
            XRBaseController controller = controllerInteractor.xrController;

            if (controller != null)
            {
                StartCoroutine(HapticInteraction(version, controller));
            }
        }
    }

    public IEnumerator HapticInteraction(bool i, XRBaseController controller)
    {
        if (i)
        {
            controller.SendHapticImpulse(0.5f, 0.1f);
            yield return new WaitForSeconds(0.4f);
            controller.SendHapticImpulse(0.8f, 0.5f);
            yield return new WaitForSeconds(0.4f);
            controller.SendHapticImpulse(0.5f, 0.1f);
            yield return new WaitForSeconds(0.4f);

        }
        else
        {
            controller.SendHapticImpulse(0.1f, 0.1f);
            yield return new WaitForSeconds(0.2f);
            controller.SendHapticImpulse(0.1f, 0.1f);
            yield return new WaitForSeconds(0.2f);
        }

    }
}
