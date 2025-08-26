using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu (fileName = "Status", menuName = "ScriptableObject/Status")]
public class Status: ScriptableObject 
{ 
    [SerializeField] int minValue;
    [SerializeField] int maxValue;
    List<Action<float>> EventActions = new List<Action<float>> ();
    public int curValue;

    public void Init()
    {
        curValue = maxValue;
    }

    public void AddValue(int value)
    {
        curValue = Mathf.Min(curValue + value, maxValue);
        for(int i = 0; i < EventActions.Count; i++)
            EventActions[i]((float)curValue / maxValue);
    }

    public void SubValue(int value)
    {
        curValue = Mathf.Max(minValue, curValue - value);
        for (int i = 0; i < EventActions.Count; i++)
            EventActions[i]((float)curValue / maxValue);
    }

    public void AddAction(Action<float> action)
    {
        if(!EventActions.Contains(action))
            EventActions.Add(action);
    }
}
