using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockManager : MonoBehaviour
{
    public bool place1 = false;
    public bool place2 = false;
    public bool place3 = false;
    public bool place4 = false;
    public bool place5 = false;
    public bool place6 = false;

    [SerializeField] public PassthroughManager roomManager;

    // Update is called once per frame
    void Update()
    {
        if (place1 && place2 && place3 && place4 && place5 && place6)
        {
            roomManager.game_win = true;
        }
    }

    public void SetPiecePlace(int i)
    {
        if (i == 1)
        {
            place1 = true;
        }
        else if (i == 2)
        {
            place2 = true;
        }
        else if (i == 3)
        {
            place3 = true;
        }
        else if (i == 4)
        {
            place4 = true;
        }
        else if (i == 5)
        {
            place5 = true;
        }
        else if (i == 6)
        {
            place6 = true;
        }
    }

    public void ResetPiecePlace(int i)
    {
        if (i == 1)
        {
            place1 = false;
        }
        else if (i == 2)
        {
            place2 = false;
        }
        else if (i == 3)
        {
            place3 = false;
        }
        else if (i == 4)
        {
            place4 = false;
        }
        else if (i == 5)
        {
            place5 = false;
        }
        else if (i == 6)
        {
            place6 = false;
        }
    }
}
