using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SaplingController : MonoBehaviour
{
    
    private float saplingTimer = 0f;

    [SerializeField] private float saplingHealthTimer = 3f;

    private bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        saplingTimer += Time.deltaTime;
        if (saplingTimer >= saplingHealthTimer && !isDead)
        {
            isDead = true;
            transform.DOScale(Vector3.zero, 0.5f).OnComplete(() =>
            
                Destroy(gameObject)
            );

        }
        
    }
}
