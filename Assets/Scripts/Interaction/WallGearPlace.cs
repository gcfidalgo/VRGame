using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WallGearPlace : MonoBehaviour
{
    [SerializeField] public GameObject gear;
    [SerializeField] public GameObject gearManager; 
    [SerializeField] public string gearName = " ";
    [SerializeField] public int gearPlace = 0;
    [SerializeField] public float yrot = 45f;
    [SerializeField] public float zrot = 0f;
    [SerializeField] public Material newMaterial;

    private bool isPlaced = false;

    private void Update()
    {
        //if (isPlaced && gear.transform.rotation.z == zrot)
        //{
        //    gear.GetComponent<XRGrabInteractable>().enabled = false;
        //    gear.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll; 
        //    gear.GetComponent<Renderer>().material = newMaterial;
        //    gearManager.GetComponent<WallGearManager>().SetRotPlace(gearPlace);
        //}

        if(isPlaced)
        {
            gear.transform.Rotate(0f, 0f, 10.0f * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.name == gearName && !isPlaced)
        {
            isPlaced = true;
            gear.GetComponent<XRGrabInteractable>().enabled = false;

            gear.transform.position = transform.position;
            //float currentZRotation = gear.transform.rotation.eulerAngles.z;
            gear.transform.rotation = Quaternion.Euler(0f, yrot, zrot);

            Rigidbody rb = gear.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.isKinematic = true; // This will fully prevent physics forces
                rb.constraints = RigidbodyConstraints.FreezePosition;
            }

            gear.GetComponent<Renderer>().material = newMaterial;
            gearManager.GetComponent<WallGearManager>().SetRotPlace(gearPlace);
            gearManager.GetComponent<WallGearManager>().SetGearPlace(gearPlace);
        }
        
    }
}
