using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public Status mana;
    public Experience experience;

    [Header("PlayerStats")]
    public int level = 1;
    public int gold = 0;
    override public int curAtk { get { return (int)(originalAtk * (1 + (level - 1) * 0.5f)); } }

    [Header("Inventory")]
    public Inventory inventory;

    [Header("Skills")]
    public Skill[] skills;

    private void Awake()
    {
        GameManager.Instance.battleManager.player = this;
    }

    protected override void Start()
    {
        base.Start();
        this.mana.Init();
        this.experience.Init();
        AddGold();
        //Refresh Skill Colltime and info
    }

    protected override void OnDead()
    {
        isDead = true;
        //Refresh Skill Cooltime and info

        //Retry Battle
    }

    public void LevelUp()
    {
        level++;
        health.UpdateMaxValue(health.originalValue + (int)(health.originalValue * 0.1f * (level - 1)));
        mana.UpdateMaxValue(mana.originalValue + (int)(mana.originalValue * 0.05f * (level - 1)));
        experience.UpdateMaxValue(experience.originalValue + (int)(experience.originalValue * (level - 1) * (level - 1)));
    }

    public bool AddGold(int value = 0)
    {
        if (gold + value < 0)
            return false;
        gold += value;
        GameManager.Instance.playerUIManager.infoUI.goldCount.SetText(gold);
        return true;
    }
}
