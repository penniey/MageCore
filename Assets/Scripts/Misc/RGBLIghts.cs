using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RGBLIghts : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject lightSource;
    [SerializeField] float duration;
    void Start()
    {
        duration = 240;
    }

    // Update is called once per frame
    void Update()
    {
        RGBAnimation();
    }



    void RGBAnimation()
    {
        float hue = (Time.time * duration) % 360f;
        Color newColor = Color.HSVToRGB(hue / 360f, 0.3f, 1f);
        var light = lightSource.GetComponent<Light2D>();
        light.color = newColor;
    }
}
