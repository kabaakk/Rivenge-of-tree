using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSeed : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        //zero all velocity
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        
        
        PlayerArenaEndShoot.instance.GrowNewTree(transform.position);
        
        
    }
}
