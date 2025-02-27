using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScramblerMotion : MonoBehaviour
{
    private Vector3 myStartPosition;
    //private AudioSource myAudioSource;
    private MeshRenderer myMeshRenderer;
    private CapsuleCollider myCapsuleCollider;

    public NavRoomManager room;

    // Start is called before the first frame update
    void Start()
    {
        myStartPosition = transform.position;
        //myAudioSource = GetComponent<AudioSource>();
        myMeshRenderer = GetComponent<MeshRenderer>();
        myCapsuleCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = myStartPosition + new Vector3(0.0f, Mathf.Sin(Time.time) / 3.0f, 0.0f);
        transform.Rotate(Vector3.back * 50 * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        room.scramble = true; 
        //myAudioSource.Play();
        myMeshRenderer.enabled = false;
        myCapsuleCollider.enabled = false;
    }
}

