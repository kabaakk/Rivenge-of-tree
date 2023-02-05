using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class NewSeed : MonoBehaviour
{

    [SerializeField] private Transform childObj;
    private void OnCollisionEnter(Collision collision)
    {
        // check collision layer for ground
        if (collision.gameObject.layer == 6)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            //zero all velocity
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        
        
            PlayerArenaEndShoot.instance.GrowNewTree(transform.position);
        
            CameraController.instance.SetArenaCamera(PlayerArenaEndShoot.instance.transform);
            transform.DOScale(Vector3.zero, 0.2f).OnComplete(() => Destroy(gameObject));
        }
       

    }

    private void Update()
    {
        // rotate child obj
        childObj.Rotate(Vector3.up * 100 * Time.deltaTime);
    }
}
