using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public Vector3 mousePosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) //Right Click
        {
            mousePosition = Input.mousePosition;
            {
                Debug.Log(mousePosition.x);
                Debug.Log(mousePosition.y);
            }
        }
        
    }



}
