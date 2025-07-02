using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    // Start is called before the first frame update
    public bool aoeDone;
    public bool triggerCheck;
    void Start()
    {
        aoeDone = false;
        triggerCheck = false;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        
        GetColliders();
        if (colliders.Count > 0 && aoeDone == false)
        {
            foreach (var Collider in colliders)
            {
                if (Collider.gameObject.name == "EnemyCybercore")
                {
                    var dmgScript = Collider.GetComponent<EnemyCybercore>();
                    dmgScript.TakeDamage(5);
                }
                else if (Collider.gameObject.name == "EnemyCrystal")
                {
                    var dmgScript2 = Collider.GetComponent<EnemyCrystal>();
                    dmgScript2.TakeDamage(5);
                }
            }

            Destroy(gameObject); //INVOKE FOR ANIMATION
            aoeDone = true;
        }
        else if (colliders.Count == 0 && triggerCheck == true)
        {
            Destroy(gameObject);
        }

    }

    private HashSet<Collider2D> colliders = new HashSet<Collider2D>();

    public HashSet<Collider2D> GetColliders()
    {
        return colliders;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Enemy") colliders.Add(collider);
        triggerCheck = true;

    }
}

