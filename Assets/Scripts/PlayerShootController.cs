using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootController : MonoBehaviour
{
    
    [SerializeField] private float shootTimer =0.2f;
    private float currentShootTimer = 0.2f;
    [SerializeField] private int ammoCapacity = 10;
    private int currentAmmo = 10;

    [SerializeField] private Seed seedPrefab;
    
    [SerializeField] private Transform shootPoint;

    private LeafController _leafController;
    
    private bool isReloading = false;

    private float reloadTimerTotal = 0.5f;
    private float reloadTimer = 0.5f;
    private float currentReloadTimer = 0f;

    private PlayerStateController _playerStateController;
    // Start is called before the first frame update
    void Start()
    {
        currentShootTimer = shootTimer;
        currentAmmo = ammoCapacity;
        _leafController = GetComponent<LeafController>();
        _playerStateController = GetComponent<PlayerStateController>();
        ActionManager.instance.ArenaSurvivalStarted += RefillAllAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerStateController.playerState != PlayerStates.ArenaSurvival)
        {
            return;
        }

        if (Input.GetMouseButton(0) && !isReloading)
        {
            currentShootTimer += Time.deltaTime;
            if (currentShootTimer >= shootTimer)
            {
                currentShootTimer = 0f;
                if (currentAmmo > 0)
                {
                    currentAmmo--;
                    _leafController.AmmoCountChanged(currentAmmo, ammoCapacity);

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
                    isReloading = true;
                }
            }
        }
       
        if (isReloading)
        {
            reloadTimer = reloadTimerTotal/ammoCapacity;
             
            currentReloadTimer += Time.deltaTime;
            if (currentReloadTimer >= reloadTimer)
            {
                currentReloadTimer = 0f;
                currentAmmo++;
                _leafController.AmmoCountChanged(currentAmmo, ammoCapacity);
                if (currentAmmo >= ammoCapacity)
                {
                    isReloading = false;
                }
            }
              
        }
            
    }


    private void RefillAllAmmo()
    {
        currentAmmo = ammoCapacity;
        _leafController.AmmoCountChanged(currentAmmo, ammoCapacity);
    }
    
}
