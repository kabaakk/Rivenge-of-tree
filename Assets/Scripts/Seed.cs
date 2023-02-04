using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    public static Seed instance;
    public int seedSpeed = 10;

    private void Awake()
    {
        instance = this;
    }


    private void Update()
    {
        transform.position +=  seedSpeed * Time.deltaTime*transform.forward ;
    }

  
}
