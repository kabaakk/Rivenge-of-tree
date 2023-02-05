using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerArenaEndShoot : Singleton<PlayerArenaEndShoot>
{
    private PlayerStateController _playerStateController;


    private Vector3 directionToShoot;

    [SerializeField] private GameObject newSeedPrefab;

    [SerializeField] private GameObject staticTree;
    // Start is called before the first frame update
    void Start()
    {
        _playerStateController = GetComponent<PlayerStateController>();
        TreePartController treePartController = GetComponentInChildren<TreePartController>();
        treePartController.CloseTree();
        treePartController.GrowTree();
    }

    // Update is called once per frame
    void Update()
    {
        if(_playerStateController.playerState != PlayerStates.ArenaSurvivalEnd)
        {
            return;
        }

      


        if (Input.GetMouseButton(0))
        {
            int layerMask = 1 << 6;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit,Mathf.Infinity, layerMask))
            {
               directionToShoot =  transform.position -hit.point;
                
                LineRendererController.instance.DrawLine(transform.position, transform.position - directionToShoot);
            }
            
            
        }

        if (Input.GetMouseButtonUp(0))
        {
            ActionManager.instance.SeedThrown?.Invoke();
            ThrowSeed(directionToShoot);

        }
        
      
        
        
    }

    private void ThrowSeed(Vector3 direction)
    {
        AudioController.instance.PlaySound(AudioController.SoundTypes.acornFly);

        GameObject newSeed = Instantiate(newSeedPrefab, transform.position + Vector3.up*2, Quaternion.identity);
        newSeed.GetComponent<Rigidbody>().AddForce(direction.normalized * 1000f + Vector3.up*300f);
        
        CameraController.instance.SetFollowForSeedCamera(newSeed.transform);
        CameraController.instance.SetCameraStatus(CameraController.CameraTypes.FlyCamera);
       
        
    }


    public void GrowNewTree(Vector3 positionToGrow)
    {
        GetComponent<LeafController>().CloseAllLeaf();
        TreePartController treePartController = GetComponentInChildren<TreePartController>();
        
        // generate static tree at last pos
        GameObject newStaticTree = Instantiate(staticTree, transform.position, Quaternion.identity);
        
        
        
        transform.position = new  Vector3(positionToGrow.x,0f,positionToGrow.z);
        
        treePartController.CloseTree();
        treePartController.GrowTree();
        
        
        
        
        
    }
}
