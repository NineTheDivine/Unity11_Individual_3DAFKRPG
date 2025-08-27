using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    //Value float is effect scaler
    public HashSet<Buff> BuffHashSet = new HashSet<Buff>();
    public Dictionary<BuffType, float> CurrentBuff = new Dictionary<BuffType, float>();

    public void Awake()
    {
        GameManager.Instance.battleManager.buffManager = this;
    }


    public void ApplyBuff(Buff buff)
    {
        BuffHashSet.Add(buff);
        if (!CurrentBuff.ContainsKey(buff.BuffInformation.Type))
        {
            CurrentBuff.Add(buff.BuffInformation.Type, 0f);
        }
        CurrentBuff[buff.BuffInformation.Type] += buff.BuffInformation.value;
    }

    public void RemoveBuff(Buff buff)
    {
        if (CurrentBuff.ContainsKey(buff.BuffInformation.Type))
        {
            CurrentBuff[buff.BuffInformation.Type] -= buff.BuffInformation.value;
            if (CurrentBuff[buff.BuffInformation.Type] <= 0.0f)
                CurrentBuff.Remove(buff.BuffInformation.Type);
        }
        BuffHashSet.Remove(buff);
    }
}
