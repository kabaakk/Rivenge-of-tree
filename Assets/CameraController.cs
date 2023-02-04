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

    
    [SerializeField] private List<CameraType> cameras;
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

}
