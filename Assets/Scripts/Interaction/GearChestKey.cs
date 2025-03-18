using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearChestKey : MonoBehaviour
{
    [SerializeField] GameObject ChestDoor;

    public float door_time = 3f;
    public float timer = 0f;

    private float speed = 55f / 3f;
    public bool win = false; 

    private void Update()
    {
        if (win && timer + Time.deltaTime < door_time)
        {
            ChestDoor.transform.Rotate(0f, speed * Time.deltaTime * -1, 0f);
            timer += Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ChestKey")
        {
            win = true;
        }
    }
}
