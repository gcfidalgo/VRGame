using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour {

	public Transform playerCamera;
	public Transform portal;
	public Transform otherPortal;

	public bool reverse = false; 
	
	// Update is called once per frame
	void Update () {
		Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
		transform.position = portal.position + playerOffsetFromPortal;

		float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);

		Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
		Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;

		newCameraDirection = new Vector3(-newCameraDirection.x, newCameraDirection.y, -newCameraDirection.z);
		if (reverse)
		{
            newCameraDirection = new Vector3(-newCameraDirection.x, newCameraDirection.y, -newCameraDirection.z);
        }

		transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
	}
}
