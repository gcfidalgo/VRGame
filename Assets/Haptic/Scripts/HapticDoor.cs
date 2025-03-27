using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticDoor : MonoBehaviour
{
   
    public float door_time = 3f;
    public float timer = 0f;

    public float speed = 105f / 3f;

    public bool win = false; 

    private void Update()
    {
        if (win && timer + Time.deltaTime < door_time)
        {
            transform.Rotate(0f, 0f, speed * Time.deltaTime);
            timer += Time.deltaTime;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            win = true;
        }
    }
}
