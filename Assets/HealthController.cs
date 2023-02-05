using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : Singleton<HealthController>
{
    [SerializeField] private Image healthBar;
    [SerializeField] private Gradient grad;
    // Start is called before the first frame update
 

    public void DamageTaken(float dmgAmount, float currentHealth, float maxHealth)
    {
        
        healthBar.fillAmount = currentHealth/maxHealth;
        
        float lengthOfBar = healthBar.rectTransform.rect.width;
        // create a new square image
        Image newImage = new GameObject("DamageTaken").AddComponent<Image>();
        newImage.transform.SetParent(healthBar.transform);
        // image length is proprtioned to dmgamount
        newImage.rectTransform.sizeDelta = new Vector2(lengthOfBar * (dmgAmount / maxHealth), healthBar.rectTransform.rect.height);
        //image position is end of fill point
        newImage.rectTransform.anchoredPosition = new Vector2(healthBar.rectTransform.rect.width * ((currentHealth-dmgAmount) / maxHealth), 0);
        newImage.color = grad.Evaluate(currentHealth / maxHealth);
        newImage.transform.DOMoveY(newImage.transform.position.y - 100f,1f).SetEase(Ease.InQuint).OnComplete(() => Destroy(newImage.gameObject));
        newImage.DOFade(0f, 1f).SetEase(Ease.InQuint);

        healthBar.color = grad.Evaluate(currentHealth / maxHealth);
    }
}
