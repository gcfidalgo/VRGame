using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCPass : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI dialoge;
    [SerializeField] private GameObject textbox;
    [SerializeField] public ClockManager manager;
    [SerializeField] private GameObject xrorigin;
    [SerializeField] private ClockPlaces piecePlace1;
    [SerializeField] private ClockPlaces piecePlace4;
    [SerializeField] private ClockPlaces piecePlace6;

    // Distance to spawn NPC in front of player
    [SerializeField] private float spawnDistance = 2.5f;

    public float display_time = 10f;
    public float timer = 0f;
    private int line = 0;

    private bool h1 = false;
    private bool h4 = false;
    private bool h6 = false;

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
            if (textbox.activeInHierarchy)
            {
                textbox.SetActive(false);
                if (line < 2)
                {
                    line++;
                    DisplayHint();
                }
            }
        }
        else
        {
            timer += Time.deltaTime;
        }

        Hinder();
    }

    private void Hinder()
    {
        if (!h1 && manager.place1)
        {
            line = 3;
            display_time = 10f;
            DisplayHint();
            SpawnInFrontOfPlayer();
            piecePlace1.ResetPiece();
            h1 = true;
        }
        if (!h4 && manager.place4)
        {
            line = 3;
            display_time = 10f;
            DisplayHint();
            SpawnInFrontOfPlayer();
            piecePlace4.ResetPiece();
            h4 = true;
        }
        if (!h6 && manager.place6)
        {
            line = 3;
            display_time = 10f;
            DisplayHint();
            SpawnInFrontOfPlayer();
            piecePlace6.ResetPiece();
            h6 = true;
        }
    }

    private void SpawnInFrontOfPlayer()
    {
        
        Vector3 playerPos = xrorigin.transform.position;
        Vector3 playerForward = xrorigin.transform.forward;

        Vector3 spawnPos = playerPos + playerForward * spawnDistance;
        spawnPos.y = playerPos.y; 

        transform.position = spawnPos;


        Vector3 directionToPlayer = playerPos - spawnPos;



        if (directionToPlayer != Vector3.zero) 
        {
            transform.rotation = Quaternion.LookRotation(directionToPlayer);
        }
    }

    public void DisplayHint()
    {
        if (line > 2)
        {
            dialoge.text = "I won't let you leave.";
        }
        else if (line == 2)
        {
            dialoge.text = "I hid the pieces, they're only visible in the other plane.";
        }
        else if (line == 1)
        {
            dialoge.text = "What? You need my help to fix the clock?";
        }
        else if (line == 0)
        {
            display_time = 5.0f;
            dialoge.text = "Are you planning to leave me?";
        }

        textbox.SetActive(true);
        timer = 0f;
    }
}