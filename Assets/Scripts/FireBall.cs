using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private float fireBallSpeed = 10f;
    [SerializeField] private float fireBallAirTimer = 5f;
    private float currentFireballAirTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        AudioController.instance.PlaySound(AudioController.SoundTypes.fireball);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position +=  fireBallSpeed * Time.deltaTime*transform.forward ;
        
        currentFireballAirTimer += Time.deltaTime;
        if (currentFireballAirTimer >= fireBallAirTimer)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            
            Destroy(gameObject);
        }
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            CharacterHealthSystem.instance.GetDamage(22);
            
                
            Destroy(gameObject);
        }
        else if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
