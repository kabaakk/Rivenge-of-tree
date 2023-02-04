using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : Singleton<CameraController>
{

    public enum CameraTypes
    {
        ArenaSurvivalCamera,
        ArenaSurvivalEndCamera,
        FlyCamera
        
    }
    
    [Serializable]
    public class CameraType
    {
        public CameraTypes cameraType;
        public CinemachineVirtualCamera camera;
    }

    private Vector3 startingDifference;
    [SerializeField] private List<CameraType> cameras;


    private void Start()
    {
        foreach (var vCamera in cameras)
        {
            if (vCamera.cameraType == CameraTypes.ArenaSurvivalCamera)
            {
                startingDifference = vCamera.camera.transform.position - PlayerArenaEndShoot.instance.transform.position;
            }
           
        }

        ActionManager.instance.ArenaSurvived += ArenaSurvived;
        ActionManager.instance.ArenaSurvivalStarted += SurvivalStarted;
    }

    public void SetCameraStatus(CameraTypes cameraType)
    {
        foreach (var vCamera in cameras)
        {
            if (vCamera.cameraType == cameraType)
            {
                vCamera.camera.Priority = 10;
            }
            else
            {
                vCamera.camera.Priority = 0;
            }
        }
    }

    public void SetFollowForSeedCamera(Transform seedToFollow)
    {
        
        foreach (var vCamera in cameras)
        {
            if (vCamera.cameraType == CameraTypes.FlyCamera)
            {
                vCamera.camera.Follow = seedToFollow;
                vCamera.camera.LookAt = seedToFollow;
            }
        }
    }

    public void SetArenaCamera(Transform arenaToSet)
    {

        SetCameraStatus(CameraTypes.ArenaSurvivalCamera);
        foreach (var vCam in cameras)
        {
            if(vCam.cameraType == CameraTypes.ArenaSurvivalCamera)
            {
               vCam.camera.transform.position = arenaToSet.position + startingDifference;
            }
            
        }
        
        
     

        
        
    }

    private void ArenaSurvived()
    {
        SetCameraStatus(CameraTypes.ArenaSurvivalEndCamera);
    }
    
    private void SurvivalStarted()
    {
        SetCameraStatus(CameraTypes.ArenaSurvivalCamera);
    }

}
