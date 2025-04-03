using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passthroughManagerScript : MonoBehaviour
{
    public OVRPassthroughLayer layer1;
    public OVRPassthroughLayer layer2;
    private bool clicked = false;
    public bool op = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void changeopacity()
    {
        if (!op)
        {
            layer1.textureOpacity = 1;
            op = true;
        }
        else 
        { 
            layer1.textureOpacity = 0.2f;
            op= false;

        }
    }

    public void switchlayers()
    {
        if (!clicked)
        {
            clicked = true;
            layer1.enabled = false;
            layer2.enabled = true;
        }
        else
        {
            clicked = false;
            layer1.enabled = true;
            layer2.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
