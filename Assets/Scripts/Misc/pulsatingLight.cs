using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class pulsatingLight : MonoBehaviour
{
    public GameObject lightSource;

    private bool goingUp;

    private bool runAnimation;

    public float animationSpeed = 0.0035f;
    // Start is called before the first frame update
    void Start()
    {
        lightSource = gameObject;
        runAnimation = true;
    }

    // Update is called once per frame
    void Update()
    {
        Pulsate();
    }

    void Pulsate()
    {

        var lightSourceLight = lightSource.GetComponent<Light2D>();

        if (lightSourceLight.pointLightOuterRadius >= 5) goingUp = false;
        else if(lightSourceLight.pointLightOuterRadius <= 2) goingUp = true;
        if (goingUp) lightSourceLight.pointLightOuterRadius += animationSpeed;
        else lightSourceLight.pointLightOuterRadius -= animationSpeed;
        
    }
}
