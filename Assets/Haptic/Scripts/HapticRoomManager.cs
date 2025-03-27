using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HapticRoomManager : MonoBehaviour
{
    [SerializeField] GameObject hour_hand;
    [SerializeField] GameObject minute_hand;
    private float hour_speed;
    private float min_speed;

    public float game_time = 400f;
    public float timer = 0f;

    public int hits = 0; 

    void Start()
    {
        min_speed = 360f / game_time;
        hour_speed = 30f / game_time;
    }

    void Update()
    {
        if (timer + Time.deltaTime >= game_time || hits >= 3)
        {
            GameLose();
        }
        else
        {
            timer += Time.deltaTime;
            minute_hand.transform.Rotate(0f, -1 * min_speed * Time.deltaTime, 0f);
            hour_hand.transform.Rotate(0f, hour_speed * Time.deltaTime * -1, 0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameLose();
    }

    private void GameLose()
    {
        SceneManager.LoadScene("Lobby");
    }
}
