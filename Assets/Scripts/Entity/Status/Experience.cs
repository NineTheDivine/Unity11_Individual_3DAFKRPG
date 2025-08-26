using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu (fileName = "Experience", menuName = "ScriptableObject/Status/Experience")]
public class Experience : Status
{
    public override void Init()
    {
        curValue = 0;
        originalValue = maxValue;
        InvokeActions();
    }

    public override void AddValue(int value)
    {
        curValue += value;
        while (curValue > maxValue)
        {
            GameManager.Instance.battleManager.player.LevelUp();
        }
        InvokeActions();
    }

    public override void UpdateMaxValue(int newValue)
    {
        curValue -= maxValue;
        maxValue = newValue;
        InvokeActions ();
    }
}
