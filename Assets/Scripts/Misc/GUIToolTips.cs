using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GUIToolTips : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject UiCanvas;
    public AudioSource gameMusic;
    public bool musicOn;
    void Start()
    {
        musicOn = false;
        UiCanvas.SetActive(true);
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Door")
        {
            if (!musicOn)
            {
                gameMusic.Play();
                musicOn = true;
            }
            UiCanvas.SetActive(false);
        }
    }
}
