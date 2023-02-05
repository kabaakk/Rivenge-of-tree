using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : Singleton<HealthController>
{
    [SerializeField] private Image healthBar;
    [SerializeField] private Gradient grad;
    [SerializeField] private Color color;
    // Start is called before the first frame update
    void Start()
    {
        grad = new Gradient();
    }

    public void DamageTaken(float dmgAmount, float currentHealth, float maxHealth, Color[] colors)
    {
        healthBar.fillAmount = dmgAmount;
        healthBar.color = grad.Evaluate(currentHealth / maxHealth);
    }
}
