using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    [SerializeField] Transform content;
    [SerializeField] ItemBtn btnPrefab;

    [Header("Inventory Setting")]
    [SerializeField] int inventorySize = 16;
    public List<Item> inventoryItems;
    public List<ItemBtn> btnItems;

    public void Awake()
    {
        inventoryItems = new List<Item>(inventorySize);
        btnItems = new List<ItemBtn>(inventorySize);
        for (int i = 0; i < inventorySize; i++)
        {
            ItemBtn btn = Instantiate(btnPrefab, content);
            btn.slotIndex = i;
            btnItems.Add(btn);
        }
    }

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
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i] == null)
            {
                inventoryItems[i] = item;
                btnItems[i].SetItem(item);
                return true;
            }
            else if (inventoryItems[i].name == item.name)
            {
                btnItems[i].count++;
                return true;
            }
        }
        //if inventory is full,  return false
        Destroy(item.gameObject);
        return false;
    }

    public void RemoveItem()
    {
        
    }
}
