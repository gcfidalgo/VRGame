using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCHaptic : MonoBehaviour
{
    [SerializeField] public HapticRoomManager room;
    [SerializeField] public TextMeshProUGUI dialoge;
    [SerializeField] private GameObject textbox;
    [SerializeField] private GameObject xrorigin;

    public float display_time = 10f;
    public float timer = 0f;
    public float timer2 = 0f;
    public bool slow = false; 

    // Update is called once per frame
    void Update()
    {
        if (timer2 + Time.deltaTime >= 5.0f)
        {
            slow = false;
        }
        else
        {
            timer2 += Time.deltaTime;

        }

        if (timer + Time.deltaTime >= display_time)
        {
            textbox.SetActive(false);
        }
        else
        {
            timer += Time.deltaTime;

        }

        Vector3 pos = xrorigin.transform.position;
        transform.position = new Vector3(pos.x - 1.5f, pos.y, pos.z + 2f);
    }

    public void DisplayHint()
    {

        if (room.hits > 0)
        {
            dialoge.text = "I’ll slow it down for you.";
            timer = 0f;
            slow = true;
        }
        else
        {
            dialoge.text = "Don’t let the pendulums hit you. The stronger the vibration, the closer the pendulum is."; 
        }
        

        textbox.SetActive(true);
        timer = 0f;
    }
}
