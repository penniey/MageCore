using Cinemachine;
using UnityEngine;
public class CameraRegister : MonoBehaviour
{
    private void OnEnable()
    {
        CameraHandler.Add(GetComponent<CinemachineVirtualCamera>());
    }
    private void OnDisable()
    {
        CameraHandler.Remove(GetComponent<CinemachineVirtualCamera>());
    }
}
