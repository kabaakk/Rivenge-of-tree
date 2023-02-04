using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealthSystem : Singleton<CharacterHealthSystem>
{
    public float health;
    public float maxHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void GetDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            //die animation;
            Debug.Log("DIED");
        }
    }
}
