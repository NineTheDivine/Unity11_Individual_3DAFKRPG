using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public void LoadData()
    {
        return;
    }

    public void SaveData()
    {
        //ResetPlayer Status
        GameManager.Instance.battleManager.player.health.ResetStatus();
        GameManager.Instance.battleManager.player.mana.ResetStatus();
        GameManager.Instance.battleManager.player.experience.ResetStatus();
    }
}
