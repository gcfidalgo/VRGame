using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHit : MonoBehaviour
{
    [SerializeField] private NPCNav npc;
    public int hit = 0;

    private bool isHit = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isHit)
        {
            npc.ActiveHit(hit);
        }
    }

}
