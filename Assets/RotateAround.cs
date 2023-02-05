using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Slowy rotate aroundy axis
        transform.RotateAround(transform.position, Vector3.up, 50 * Time.deltaTime);
        // bounce up and down
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, 1) +0.5f, transform.position.z);
        
    }
}
