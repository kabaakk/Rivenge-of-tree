using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Seed : MonoBehaviour
{
    public static Seed instance;
    public int seedSpeed = 10;
    
    [SerializeField] private float seedAirTimer = 0.5f;
    
    private float currentSeedAirTimer = 0f;
    [SerializeField] private GameObject saplingObject;
    [SerializeField] private Transform childObject;

    private void Awake()
    {
        instance = this;
    }


    private void Update()
    {
        transform.position +=  seedSpeed * Time.deltaTime*transform.forward ;
        
        currentSeedAirTimer += Time.deltaTime;
        if (currentSeedAirTimer >= seedAirTimer)
        {
            // instantiate sapling at position on y zero
          //  Instantiate(saplingObject, new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);
            Destroy(gameObject);
        }
        childObject.Rotate(Vector3.up * 100 * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            collision.gameObject.GetComponent<AiMovement>().TakeDamage();
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            
            other.GetComponent<AiMovement>().TakeDamage();
            Destroy(gameObject);
        }
    }
}
