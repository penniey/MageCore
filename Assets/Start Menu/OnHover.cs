using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class OnHover : MonoBehaviour
{
    public GameObject lightSource;
    public bool lightOn;
    void Start()
    {
        lightOn = false;
    }

    public void TurnOnLight()
    {
        lightSource.SetActive(true);
        
    }

    public void TurnOffLight()
    {
        lightSource.SetActive(false);

    }
}
