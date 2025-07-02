using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class cameraChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public List<BoxCollider2D> Rooms;
    public List<CinemachineVirtualCamera> Cameras;

    public CinemachineVirtualCamera cr;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Camera"))
        {
            
            var cMachine = collision.GetComponent<CinemachineVirtualCamera>();
            cr = cMachine;
            CameraHandler.SwitchCamera(cMachine);
        }
    }
}
