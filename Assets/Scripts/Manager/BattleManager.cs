using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Player player;
    public Enemy enemy;

    public int stage = 1;

    private void Awake()
    {
        GameManager.Instance.battleManager = this;
    }

    private void Start()
    {
        GameManager.Instance.playerUIManager.infoUI.stageCount.SetText(stage);
    }

    public void EndStage(bool isWin)
    {
        if (isWin)
        {
            player.AddGold(enemy.DropGold);
            player.experience.AddValue(enemy.DropExp);
            //player.inventory.AddItems(enemy.MakeItemDrops());
        }
        Invoke("ResetStage", 3.0f);
    }

    public void ResetStage()
    {
        player.OnResetStage();
        enemy.OnResetStage();
    }

}
