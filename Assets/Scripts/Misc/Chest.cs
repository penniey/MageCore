using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject itemPrefab;
    private bool hasSpawnedItem;
    void Start()
    {
        hasSpawnedItem = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (hasSpawnedItem == false)
            {
                hasSpawnedItem = true;
                //maybe add some button press perhaps perchance
                var itemReward =
                    Instantiate(itemPrefab, gameObject.transform.position,
                        gameObject.transform
                            .rotation);
                //itemReward.GetComponent<Rigidbody2D>() move it up and down
                
            }

        }
    }
}
