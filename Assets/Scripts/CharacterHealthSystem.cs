using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CharacterHealthSystem : Singleton<CharacterHealthSystem>
{
    public float health;
    public float maxHealth = 100;

    private PlayerStateController playerStateController;
    // Start is called before the first frame update
    void Start()
    {
        playerStateController = GetComponent<PlayerStateController>();
        ActionManager.instance.ArenaSurvived += RefillHealth;
        health = maxHealth;
    }

    private void RefillHealth()
    {
        health = Mathf.Clamp(health + 10f, 0, maxHealth);
        HealthController.instance.RefilledHealth( health, maxHealth);
    }
    public void GetDamage(float amount)
    {
        if (playerStateController.playerState == PlayerStates.ArenaSurvival)
        {
            
            AudioController.instance.PlaySound(AudioController.SoundTypes.playerHit);
            health -= amount;
            HealthController.instance.DamageTaken(amount, health, maxHealth);

            if (health <= 0)
            {
                AudioController.instance.PlaySound(AudioController.SoundTypes.playerDeath);

                GetComponent<PlayerStateController>().PlayerDied();

                transform.DORotate(Vector3.forward * -90f, 1.5f).SetEase(Ease.OutElastic);
            }
        }
    }
}
