using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemBtn : MonoBehaviour
{
    Button button;
    [SerializeField] Image itemIcon;
    [SerializeField] TextMeshProUGUI countText;

    public Item slotItem { get; private set; } = null;
    public int count = 0;
    public int slotIndex;

    public void Awake()
    {
        button = GetComponent<Button>();
    }
    public void Start()
    {
        if (slotItem == null)
        {
            button.interactable = false;
            EmptySlot();
        }
        else
        {
            button.interactable=true;
        }
    }
    public void SetItem(Item item)
    {
        slotItem = item;
        slotItem.transform.SetParent(transform);
        count++;
    }


    public void EmptySlot()
    {
        button.interactable = false;
        if(slotItem != null)
            Destroy(slotItem.gameObject);
        itemIcon.sprite = null;
        itemIcon.color = new Color(255, 255, 255, 0);
        countText.text = "";
    }
}
