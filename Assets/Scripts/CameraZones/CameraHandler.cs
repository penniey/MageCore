using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    static List<CinemachineVirtualCamera> Allcameras = new List<CinemachineVirtualCamera>();

    public static CinemachineVirtualCamera CurrentCamera = null;

    public static bool IsCurrentCamera(CinemachineVirtualCamera camera)
    {
        return camera == CurrentCamera;
    }

    public static void SwitchCamera(CinemachineVirtualCamera newCamera)
    {
        newCamera.Priority = 10;
        CurrentCamera = newCamera;

        foreach (CinemachineVirtualCamera cam in Allcameras)
        {
            if (cam != newCamera)
            {
                cam.Priority = 0;
            }
        }
    }

    public static void Add(CinemachineVirtualCamera camera)
    {
        Allcameras.Add(camera);
    }

    public static void Remove(CinemachineVirtualCamera camera)
    {
        Allcameras.Remove(camera);
    }
}
