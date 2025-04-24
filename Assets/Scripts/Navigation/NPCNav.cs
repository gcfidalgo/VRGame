using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using Unity.VisualScripting;
using UnityEngine;

public class NPCNav : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI dialoge;
    [SerializeField] private GameObject textbox;
    [SerializeField] private GameObject xrorigin; 
    [SerializeField] private NavRoomManager room; 

    public float display_time = 10f;
    public float timer = 0f;

    public bool hit1 = false; 
    public bool hit2 = false;
    public bool hit3 = false;

    // Start is called before the first frame update
    void Start()
    {
        textbox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer + Time.deltaTime >= display_time)
        {
            textbox.SetActive(false);
        }
        else
        {
            timer += Time.deltaTime;

        }

        Vector3 pos = xrorigin.transform.position;
        transform.position = new Vector3(pos.x + 1.5f, pos.y, pos.z + 1.5f); 

    }

    public void ActiveHit(int i)
    {
        if(i == 1)
        {
            hit1 = true; 

        } else if (i == 2)
        {
            hit2 = true;   
            
        } else if (i == 3)
        {
            hit3 = true;
        }
    }
    public void DisplayHint()
    {   
        if(room.GameWin())
        {
            dialoge.text = "Return to the central clock and go to the next room."; 
        }
        else if(hit3)
        {
            dialoge.text = "There’s a gear on each floor level. Portals help you move around."; 
        }
        else if(hit2)
        {
            dialoge.text = "Coins give you more time.";
        }
        else if (hit1)
        {
            dialoge.text = "Check your watch, time is running. Go to the central clock.";
        }
        else
        {
            dialoge.text = "Use the joystick to move, and don’t fall!";
        }

        textbox.SetActive(true);
        timer = 0f; 
    }

}
