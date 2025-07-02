using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePop : MonoBehaviour
{
    private TextMeshPro textMesh;
    private float dissapearTime;
    private Color textColor;
    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }

    public void Setup(float damageAmount)
    {
        textMesh.SetText(damageAmount.ToString());
        dissapearTime = 1f;
        textColor = textMesh.color;
    }

    private void FixedUpdate()
    {
        float moveYSpeed = 2.5f;
        dissapearTime -= Time.deltaTime;
        if(dissapearTime < 0)
        {
            float disappearSpeed = 3f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if(textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
        transform.position += new Vector3(0, moveYSpeed) * (Time.deltaTime / 2);
    }
}
