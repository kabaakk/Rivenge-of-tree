using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealthSystem : MonoBehaviour
{
    public Image healthBar;
    public float health;
    public float maxHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthBar.fillAmount = health;
    }

    public void GetDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health;

        if (health <= 0)
        {
            //die animation;
            Debug.Log("DIED");
        }
    }
}
