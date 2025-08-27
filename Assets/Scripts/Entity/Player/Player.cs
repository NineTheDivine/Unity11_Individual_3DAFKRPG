using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Entity
{
    public Status mana;
    public Experience experience;

    [Header("PlayerStats")]
    public int level = 1;
    public int gold = 0;
    override public int curAtk { get 
        {
            int levelAtk = (int)(originalAtk * (1 + (level - 1) * 0.5f));
            return (int)(levelAtk * ((1.0f + (buffManager.CurrentBuff.TryGetValue(BuffType.Atk, out float value) ? value : 0.0f)))); 
        }
    }

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
        UpdateStatusByLevel();
        AddGold();
        GameManager.Instance.playerUIManager.infoUI.experienceBar.textSetter.SetText(level);
        //Refresh Skill Colltime and info
    }

    protected override void OnDead()
    {
        isDead = true;
        entityAnimator.OnDeadApplied();
        GameManager.Instance.battleManager.EndStage(false);
    }

    public void LevelUp()
    {
        level++;
        GameManager.Instance.playerUIManager.infoUI.experienceBar.textSetter.SetText(level);
        UpdateStatusByLevel();
    }

    public void UpdateStatusByLevel()
    {
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

    public void OnResetStage()
    {
        health.Init();
        mana.Init();
        entityAnimator.OnReset();
        isDead = false;
        GetComponent<PlayerAI>().Init();
    }
}
