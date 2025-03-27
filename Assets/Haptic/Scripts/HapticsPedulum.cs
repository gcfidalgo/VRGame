using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticsPedulum : MonoBehaviour
{   
    [SerializeField] public HapticRoomManager room;
    [SerializeField] public GameObject player;

    [SerializeField] private XRBaseController leftController;
    [SerializeField] private XRBaseController rightController;

    private float maxHapticDistanceX = 4f; // Maximum X distance for haptic feedback
    private float minHapticDistanceX = 0.5f; // Minimum X distance for full intensity

    private float maxHapticDistanceY = 5f; // Maximum Y distance for haptic feedback
    private float minHapticDistanceY = 0.5f; // Minimum Y distance for full intensity

    private float maxHapticDistanceZ = 1.1f; // Maximum Z distance for haptic feedback
    private float minHapticDistanceZ = 0.5f; // Minimum Z distance for full intensity

    private float maxHapticAmplitude = 1f; // Maximum haptic amplitude
    private float minHapticAmplitude = 0.1f; // Minimum haptic amplitude

    private Vector3 pos; 

    private void Awake()
    {
        room = GameObject.Find("HapticRoomManager").GetComponent<HapticRoomManager>();

        leftController = GameObject.Find("Left Controller").GetComponent<XRBaseController>();
        rightController = GameObject.Find("Right Controller").GetComponent<XRBaseController>();

        player = GameObject.Find("XR Origin (XR Rig)");
    }

    private void Start()
    {
        pos = player.transform.position;
    }


    void Update()
    {
        // Calculate distance between player and pendulum
        Vector3 distance = transform.position - Camera.main.transform.position;

        // Check if the distance is within the haptic feedback range for each axis
        bool withinXRange = Mathf.Abs(distance.x) <= maxHapticDistanceX;
        bool withinYRange = Mathf.Abs(distance.y) <= maxHapticDistanceY;
        bool withinZRange = Mathf.Abs(distance.z) <= maxHapticDistanceZ;

        if (withinXRange && withinYRange && withinZRange)
        {
            // Calculate haptic intensity based on distance for each axis
            float normalizedDistanceX = Mathf.Clamp01((maxHapticDistanceX - Mathf.Abs(distance.x)) / (maxHapticDistanceX - minHapticDistanceX));
            float normalizedDistanceY = Mathf.Clamp01((maxHapticDistanceY - Mathf.Abs(distance.y)) / (maxHapticDistanceY - minHapticDistanceY));
            float normalizedDistanceZ = Mathf.Clamp01((maxHapticDistanceZ - Mathf.Abs(distance.z)) / (maxHapticDistanceZ - minHapticDistanceZ));

            // Calculate average normalized distance
            float averageNormalizedDistance = (normalizedDistanceX + normalizedDistanceY + normalizedDistanceZ) / 3f;

            // Calculate haptic amplitude based on average normalized distance
            float hapticAmplitude = Mathf.Lerp(minHapticAmplitude, maxHapticAmplitude, averageNormalizedDistance);

            // Send haptic feedback to both controllers
            SendHapticFeedback(leftController, hapticAmplitude);
            SendHapticFeedback(rightController, hapticAmplitude);
        }
    }

    private void SendHapticFeedback(XRBaseController controller, float amplitude)
    {
        if (controller != null)
        {
            controller.SendHapticImpulse(amplitude, 0.1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            room.hits++;
            player.transform.position = pos;
            Debug.Log("hit");
        }
    }
}
