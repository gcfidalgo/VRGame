using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraClockHands : MonoBehaviour
{
    [SerializeField] GameObject hand;
    private float random_rot;
    public float random_direction = -1.0f;
    public bool v2 = false; 
    
    // Start is called before the first frame update
    void Start()
    {
        random_rot = Random.Range(3.5f, 10.0f); 
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(!v2)
        {
            hand.transform.Rotate(0f, random_rot * Time.deltaTime * random_direction, 0f);
        } else
        {
            hand.transform.Rotate(0f, 0f, random_rot * Time.deltaTime * random_direction);
        }
            
    }
}
