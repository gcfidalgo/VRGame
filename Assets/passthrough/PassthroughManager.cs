using System.Collections;
using System.Collections.Generic;
using Meta; 
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PassthroughManager : MonoBehaviour
{   
    public bool game_win = false;

    [SerializeField] GameObject hour_hand;
    [SerializeField] GameObject minute_hand;

    [Space]
    [SerializeField] GameObject center_base;
    [SerializeField] GameObject[] clock_pieces;
    [SerializeField] GameObject intensitySlider; 

    [Space]
    [SerializeField] public Camera xrCam; 
    [SerializeField] public OVRPassthroughLayer layer1;

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
        intensitySlider.SetActive(false); 
        layer1.enabled = false;
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

    public void SetIntensity(float i)
    {
        if(!plane)
        {
            layer1.SetBrightnessContrastSaturation(intensitySlider.GetComponent<Slider>().value, 0f, 0f);
            //Debug.Log("value changed");
        }
    }

    public void SwitchPlane()
    {
        plane = !plane;

        if (plane) {

            intensitySlider.SetActive(false);

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
            
            layer1.enabled = false;
            xrCam.clearFlags = CameraClearFlags.Skybox;

        } else
        {
            intensitySlider.SetActive(true);
            intensitySlider.GetComponent<Slider>().value = 0f;
            SetIntensity(0.0f);

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

            xrCam.clearFlags = CameraClearFlags.SolidColor;
            layer1.enabled = true;
        }

    }


}
