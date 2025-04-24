using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ClockPlaces : MonoBehaviour
{
    [SerializeField] public GameObject piece;
    [SerializeField] public ClockManager placeManager;
    [SerializeField] public string pieceName = " ";
    [SerializeField] public int piecePlace = 0;

    private Quaternion start_rot;
    private bool isPlaced = false;

    // Start is called before the first frame update
    void Start()
    {
        start_rot = piece.transform.rotation; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == pieceName && !isPlaced)
        {
            piece.GetComponent<XRGrabInteractable>().enabled = false;
            piece.transform.position = transform.position;
            piece.transform.rotation = start_rot;
            isPlaced = true;

            Rigidbody rb = piece.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.isKinematic = true; // This will fully prevent physics forces
                rb.constraints = RigidbodyConstraints.FreezePosition;
            }

            placeManager.SetPiecePlace(piecePlace);
        }
    }
}
