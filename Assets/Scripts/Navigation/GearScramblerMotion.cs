using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class GearScramblerMotion : MonoBehaviour
{
    private Vector3 myStartPosition;
    private AudioSource myAudioSource;
    private MeshRenderer myMeshRenderer;
    private CapsuleCollider myCapsuleCollider;

    [SerializeField] GameObject key_place;
    [SerializeField] private XRBaseController leftController;
    [SerializeField] private XRBaseController rightController;

    public NavRoomManager room;

    // Start is called before the first frame update
    void Start()
    {
        myStartPosition = transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myMeshRenderer = GetComponent<MeshRenderer>();
        myCapsuleCollider = GetComponent<CapsuleCollider>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = myStartPosition + new Vector3(0.0f, Mathf.Sin(Time.time) / 3.0f, 0.0f);
        transform.Rotate(0f, 10.0f * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            myAudioSource.Play();
            //myMeshRenderer.enabled = false;
            myCapsuleCollider.enabled = false;
            myStartPosition = key_place.transform.position + new Vector3(0.0f, 1.1f, 0.0f);
            transform.rotation = Quaternion.identity;
            room.num_keys++;

            leftController.SendHapticImpulse(0.5f, 0.5f);
            rightController.SendHapticImpulse(0.5f, 0.5f);
        }
    }
}

