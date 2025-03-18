using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionRoomManager : MonoBehaviour
{
    [SerializeField] GameObject hour_hand;
    [SerializeField] GameObject minute_hand;
    private float hour_speed;
    private float min_speed;

    public float game_time = 330f;
    public float timer = 0f;

    [SerializeField] GameObject Door;
    [SerializeField] GameObject nextPlane;
    public float door_time = 3f;
    public float door_timer = 0f;
    public float door_speed = 0f;

    public bool game_win = false; 

    // Start is called before the first frame update
    void Start()
    {
        min_speed = 360f / game_time;
        hour_speed = 27f / game_time;
        nextPlane.SetActive(false);
        door_speed = 105f / 3.0f; 
    }

    // Update is called once per frame
    void Update()
    {   
        if(game_win)
        {
            
            if (nextPlane.activeSelf == false)
            {
                nextPlane.SetActive(true);
                
            }

            if (door_timer + Time.deltaTime < door_time)
            {   
                Door.transform.Rotate(0f, 0f, door_speed * Time.deltaTime);
                door_timer += Time.deltaTime;

            }

        } else
        {
            if (timer + Time.deltaTime >= game_time)
            {
                SceneManager.LoadScene("Lobby");
            }
            else
            {
                timer += Time.deltaTime;
                minute_hand.transform.Rotate(0f, min_speed * Time.deltaTime, 0f);
                hour_hand.transform.Rotate(0f, hour_speed * Time.deltaTime * -1, 0f);
            }
        }
        
    }

 
}
