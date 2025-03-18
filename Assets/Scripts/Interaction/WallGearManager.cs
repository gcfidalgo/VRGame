using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WallGearManager : MonoBehaviour
{
    public bool place1 = false; 
    public bool place2 = false;
    public bool place3 = false;

    public bool rot1 = false;
    public bool rot2 = false;
    public bool rot3 = false;

    [SerializeField] public GameObject keyDoor;
    [SerializeField] public GameObject key;

    private AudioSource sfx;

    private void Start()
    {
        key.GetComponent<XRGrabInteractable>().enabled = false;
        sfx = GetComponent<AudioSource>();
    }
  
    // Update is called once per frame
    void Update()
    {
        if (place1 && place2 && place3 && rot1 && rot2 && rot3)
        {
            keyDoor.SetActive(false);
            key.GetComponent<XRGrabInteractable>().enabled = true;
        }
    }

    public void SetGearPlace(int i)
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

        sfx.Play();
    }

    public void SetRotPlace(int i)
    {
        if (i == 1)
        {
            rot1 = true;
        }
        else if (i == 2)
        {
            rot2 = true;
        }
        else if (i == 3)
        {
            rot3 = true;
        }
    }
}
