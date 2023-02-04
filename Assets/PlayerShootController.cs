using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootController : MonoBehaviour
{
    
    [SerializeField] private float shootTimer =0.2f;
    private float currentShootTimer = 0f;
    [SerializeField] private int ammoCapacity = 10;
    private int currentAmmo = 10;

    [SerializeField] private Seed seedPrefab;
    
    [SerializeField] private Transform shootPoint;
    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = ammoCapacity;
    }

    // Update is called once per frame
    void Update()
    {

       if (Input.GetMouseButton(0))
       {
           Debug.Log("xd");
           currentShootTimer += Time.deltaTime;
           if (currentShootTimer >= shootTimer)
           {
               currentShootTimer = 0f;
               if (currentAmmo > 0)
               {
                   currentAmmo--;
                   int layerMask = 1 << 6;
                   Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                   if (Physics.Raycast(ray, out RaycastHit hit,Mathf.Infinity, layerMask))
                   {
                       Seed firedSeed = Instantiate(seedPrefab, shootPoint.position, Quaternion.identity);
                       firedSeed.transform.LookAt(new Vector3(hit.point.x, firedSeed.transform.position.y,
                           hit.point.z));
                   }
               }
               else
               {
                   Debug.Log("No Ammo");
               }
           }
       }
            
    }
        
        
    
}
