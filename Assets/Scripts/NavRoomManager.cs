using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavRoomManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    private Transform player_start;

    [SerializeField] GameObject hour_hand;
    [SerializeField] GameObject minute_hand;
    private Quaternion hour_init_rot;
    private Quaternion min_init_rot;
    private float hour_speed;
    private float min_speed;

    public float game_time = 330f;
    public float timer = 0f;

    public float scramble_timer = 0f;
    public float scram_time = 10f; 
    public bool scramble = false;

    public int num_keys = 0; 

    // Start is called before the first frame update
    void Start()
    {
        player_start = player.transform;
        hour_init_rot = hour_hand.transform.rotation;
        min_init_rot = minute_hand.transform.rotation;

        min_speed = 360f / game_time;
        hour_speed = 27f / game_time; 
    }

    // Update is called once per frame
    void Update()
    {   
        if(scramble)
        {
            if (scramble_timer + Time.deltaTime >= scram_time)
            {
                scramble = false;
                scramble_timer = 0f; 
            }
            else
            {
                scramble_timer += Time.deltaTime;
            }
        }else
        {
            if (timer + Time.deltaTime >= game_time)
            {
                GameLose();
            }
            else
            {
                timer += Time.deltaTime;
                minute_hand.transform.Rotate(0f, min_speed * Time.deltaTime, 0f);
                hour_hand.transform.Rotate(0f, hour_speed * Time.deltaTime * -1, 0f); 

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameLose();
    }

    private void GameLose()
    {
        player.transform.position = player_start.position;
        timer = 0f;
        hour_hand.transform.rotation = hour_init_rot;
        minute_hand.transform.rotation = min_init_rot;
    }

    public bool GameWin()
    {   
        if (num_keys == 2)
        {
            return true;

        } else
        {
            return false;
        }
    }
}
