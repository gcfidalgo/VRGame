using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassthroughManager : MonoBehaviour
{   
    public bool game_win = false;

    [SerializeField] GameObject hour_hand;
    [SerializeField] GameObject minute_hand;

    [Space]
    [SerializeField] GameObject center_base;
    [SerializeField] GameObject[] clock_pieces; 

    private float hour_speed;
    private float min_speed;

    public float game_time = 400f;
    public float timer = 0f;

    public bool plane = true; 



    // Start is called before the first frame update
    void Start()
    {
        min_speed = 360f / game_time;
        hour_speed = 30f / game_time;
        SwitchPlane();
    }

    // Update is called once per frame
    void Update()
    {
        if (game_win)
        {
            Application.Quit();
        }
        else
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

    public void SwitchPlane()
    {
        plane = !plane;

        if (plane) { 
            
            center_base.SetActive(true);
            for(int i = 0; i < clock_pieces.Length; i++)
            {   
                if(clock_pieces[i].tag == "NotFound")
                {
                    clock_pieces[i].SetActive(false);

                } else
                {
                    clock_pieces[i].SetActive(true);
                }
                
            }

        } else
        {
            center_base.SetActive(false);
            for (int i = 0; i < clock_pieces.Length; i++)
            {
                if (clock_pieces[i].tag == "NotFound")
                {
                    clock_pieces[i].SetActive(true);
                }
                else
                {
                    clock_pieces[i].SetActive(false);
                }

            }
        }

    }
}
