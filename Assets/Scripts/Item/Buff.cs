using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BuffType
{
    None = 0,
    Exp,
    Gold,
    Atk
}

[System.Serializable]
public class BuffInfo
{
    public BuffType Type;
    public float value;
    public float durationSeconds;
}

public class Buff : MonoBehaviour
{
    [SerializeField] protected BuffInfo buffInformation;
    public BuffInfo BuffInformation { get { return buffInformation; } }

    float remainingtime;
    //Image image;


    public void ApplyBuff()
    {
        remainingtime = buffInformation.durationSeconds;
        if (GameManager.Instance.battleManager.buffManager.BuffHashSet.Contains(this))
        {
            remainingtime = buffInformation.durationSeconds;
            return;
        }

        GameManager.Instance.battleManager.buffManager.ApplyBuff(this);
        this.StartCoroutine(EndBuff());
        
    }

    private IEnumerator EndBuff()
    {
        while (remainingtime >= 0)
        {
            //Set Buff Button image Fill
            //image.fillAmount = remainingtime / buff.durationSeconds;
            remainingtime -= 1.0f;
            yield return new WaitForSeconds(1);
        }
        Debug.Log("Buff End");
        GameManager.Instance.battleManager.buffManager.RemoveBuff(this);
    }
}
