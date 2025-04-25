using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumRot : MonoBehaviour
{
    public float swingSpeed = 2f;
    public float maxAngle = 45f;
    public float minAngle = -45f;
    private float phaseOffset = 0f;
    [SerializeField] private NPCHaptic npc;

    public float display_time = 10f;
    public float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        float temp = Random.Range(45f, 95f);
        maxAngle = temp;
        minAngle = temp * -1;
        temp = Random.Range(0.3f, 2.5f);
        swingSpeed = temp;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = swingSpeed;
        if (npc.slow && timer + Time.deltaTime <= display_time)
        {
            swingSpeed = 0.2f;
            timer += Time.deltaTime;

        } else
        {
            timer = 0f; 
            npc.slow = false;
        }

        float normalizedSin = (Mathf.Sin(Time.time * swingSpeed + phaseOffset) + 1f) / 2f;
        float angle = Mathf.Lerp(minAngle, maxAngle, normalizedSin);
        transform.localRotation = Quaternion.Euler(0, 0, angle);

        swingSpeed = temp; 

    }
}
