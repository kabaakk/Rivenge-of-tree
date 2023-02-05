using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class PowerUpTextController : MonoBehaviour
{

    [SerializeField] private TextMeshPro _textMeshPro;


    private void Start()
    {
        transform.localScale = Vector3.zero;
        
        transform.DORotate(Vector3.up*720f,2f,RotateMode.FastBeyond360).SetEase(Ease.InOutSine);
        transform.DOScale(Vector3.one, 0.5f);
        transform.DOMoveY(transform.position.y + 5f, 0.8f);
        
        DOVirtual.DelayedCall(3f,() =>
        {
            transform.DOScale(Vector3.zero, 0.5f).OnComplete(() => Destroy(gameObject));
        });
        
    }

    public void SetText(PlayerShootController.UpgradeTypes typeToSet)
    {
        // case swithc with type to set
        switch (typeToSet)
        {
            case PlayerShootController.UpgradeTypes.Damage:
                _textMeshPro.text = "Damage Up";
                break;
            case PlayerShootController.UpgradeTypes.MaxAmmo:
                _textMeshPro.text = "Max Ammo Up";
                break;
            case PlayerShootController.UpgradeTypes.ShootRate:
                _textMeshPro.text = "Fire Rate Up";
                break;
          
        }
        
    }
}
