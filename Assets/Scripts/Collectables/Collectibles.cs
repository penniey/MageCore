using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Collectibles : MonoBehaviour
{

    public List<GameObject> collectedItems;
        
    public void AddItem(Item.itemTypes type)
    {
        var position = 0;
        if (collectedItems.Count() > 0)
        {
            foreach (GameObject item in collectedItems)
            {

                var itemScript = item.GetComponent<Item>();
                var iType = itemScript.itemType;
                if (iType == type)
                {
                    itemScript.amount++;
                    return;
                }
                else
                {

                    if (position + 1 == collectedItems.Count())
                    {
                        collectedItems.Add(item);
                        return;
                    }
                    else position++;
                }
            }
        }

    }


}
