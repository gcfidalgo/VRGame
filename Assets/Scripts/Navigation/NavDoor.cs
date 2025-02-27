using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavDoor : MonoBehaviour
{
    [SerializeField] GameObject nextPlane;    
    
    public NavRoomManager room;
    public bool win = false;
    public float door_time = 3f;
    public float timer = 0f;

    public float speed = 120f / 3f;

    private void Start()
    {
        nextPlane.SetActive(false);
    }

    private void Update()
    {
        if(win && timer + Time.deltaTime < door_time)
        {
            transform.Rotate(0f, speed * Time.deltaTime, 0f);
            timer += Time.deltaTime;
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && room.GameWin())
        {
            speed = 120f / door_time;
            win = true;
            nextPlane.SetActive(true);
        }
    }
}
