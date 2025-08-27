using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public void AddItems(List<Item> items)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (!TryAddItem(items[i]))
                Debug.Log("인벤토리가 가득 찼습니다.");
        }
    }

    public bool TryAddItem(Item item)
    {


        //if inventory is full,  return false
        return false;
    }
}
