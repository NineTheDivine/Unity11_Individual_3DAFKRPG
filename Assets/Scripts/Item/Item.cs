using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string itemName;
    [SerializeField] private string itemDescription;
    [SerializeField] private Sprite itemSprite;

    public string ItemName { get { return itemName; } }
    public string ItemDescription { get { return itemDescription; } }
    public Sprite ItemSprite { get { return itemSprite; } }

    IUseable[] useables;

    public void Awake()
    {
        useables = GetComponents<IUseable>();
    }

    public void UseItem()
    {
        for (int i = 0; i < useables.Length; i++)
        {
            useables[i].OnUse();
        }
    }
}
