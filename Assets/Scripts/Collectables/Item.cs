using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int amount;
    public itemTypes itemType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            var collectScript = collision.GetComponent<Collectibles>();
            collectScript.AddItem(itemType);
            Destroy(gameObject);
        }
    }


    public enum itemTypes
    {
        Gold,
        Potion,
        Snail
    }
}

