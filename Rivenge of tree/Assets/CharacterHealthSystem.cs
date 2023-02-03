using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealthSystem : MonoBehaviour
{
    public float health;
    public float maxHealth = 100;
    public static CharacterHealthSystem instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void GetDamage(float amount)
    {
        health -= amount;
        Debug.Log(health);

        if (health <= 0)
        {
            //die animation;
            Debug.Log("DIED");
        }
    }
}
