using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IUseable
{
    Buff[] buffs;

    public void Awake()
    {
        buffs = GetComponents<Buff>();
    }

    public void OnUse()
    {
        for (int i = 0; i < buffs.Length; i++)
        {
            buffs[i].ApplyBuff();
        }
    }
}
