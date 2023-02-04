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
            }
        }
    }

    public void SetArenaCamera(Transform arenaToSet)
    {
        
        
        
        
    }

}
