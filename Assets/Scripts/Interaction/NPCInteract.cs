using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class NPCInteract : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI dialoge;
    [SerializeField] private GameObject textbox;
    [SerializeField] private WallGearManager wallPlace; 

    public float display_time = 10f;
    public float timer = 0f;

    public bool print1 = false;
    public bool print2 = false;

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
    }

    public void LookedBlue(bool first)
    {
        if (first)
        {
            print1 = true; 

        } else
        {
            print2 = true;
        }
    }

    public void DisplayHint()
    {
        if (wallPlace.place1 && wallPlace.place2 && wallPlace.place3)
        {
            dialoge.text = "Open the chest with the key.";

        }
        else if (wallPlace.place1 || wallPlace.place2 || wallPlace.place3)
        {
            dialoge.text = "Fix the mechanism to get the key"; 

        } 
        else if(print1 && print2)
        {
            dialoge.text = "Follow the instructions on the revealed blueprints. Press the Grab button to grab the gears and drawers.";

        }
        else if(!print1 && !print2)
        {
            dialoge.text = "Look at the eye icon on the table."; 
        }
        else if (!wallPlace.place1 && !wallPlace.place2 && !wallPlace.place3)
        {
            dialoge.text = "The key mechanism uses gold gears. They vibrate differently";
        }

        textbox.SetActive(true);
        timer = 0f;
    }

}
