using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradePickup : MonoBehaviour
{

    [SerializeField] private PlayerShootController.UpgradeTypes _upgradeTypes;

    [SerializeField] private TextMeshPro _text;

    private void Start()
    {
        _text.text = _upgradeTypes.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            other.GetComponent<PlayerShootController>().Upgrade(_upgradeTypes);
            Destroy(this.gameObject);
        }
    }
}
