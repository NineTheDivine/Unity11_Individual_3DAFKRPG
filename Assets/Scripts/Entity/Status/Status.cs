using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu (fileName = "Status", menuName = "ScriptableObject/Status/Base")]
public class Status: ScriptableObject 
{ 
    [SerializeField] protected int minValue;
    [SerializeField] protected int maxValue;
    public int MaxValue { get { return maxValue; } }
    public int originalValue { get; private set; }
    protected List<Action<float>> EventActions = new List<Action<float>> ();
    public int curValue;

    public void Init()
    {
        curValue = maxValue;
        originalValue = maxValue;
    }

    public virtual void AddValue(int value)
    {
        curValue = Mathf.Min(curValue + value, maxValue);
        for (int i = 0; i < EventActions.Count; i++)
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

    public virtual void UpdateMaxValue(int newValue)
    {
        curValue += newValue - maxValue;
        maxValue = newValue;
    }

    private void OnDestroy()
    {
        maxValue = originalValue;
        curValue = 0;
    }
}
