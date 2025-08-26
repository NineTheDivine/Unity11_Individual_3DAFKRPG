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
    public int originalValue { get; protected set; }
    protected List<Action<int, int>> EventActions = new List<Action<int, int>> ();
    public int curValue;

    public virtual void Init()
    {
        curValue = maxValue;
        originalValue = maxValue;
        InvokeActions();
    }

    public virtual void AddValue(int value)
    {
        curValue = Mathf.Min(curValue + value, maxValue);
        InvokeActions();
    }

    public void SubValue(int value)
    {
        curValue = Mathf.Max(minValue, curValue - value);
        InvokeActions();
    }

    public void AddAction(Action<int, int> action)
    {
        if(!EventActions.Contains(action))
            EventActions.Add(action);
    }


    public virtual void UpdateMaxValue(int newValue)
    {
        curValue += newValue - maxValue;
        maxValue = newValue;
        InvokeActions();
    }

    public void InvokeActions()
    {
        for (int i = 0; i < EventActions.Count; i++)
            EventActions[i](curValue, maxValue);
    }


    private void OnDestroy()
    {
        maxValue = originalValue;
        curValue = 0;
    }
}
