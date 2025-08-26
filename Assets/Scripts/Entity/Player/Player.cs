using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [Header("PlayerStatus")]
    public Status mana;

    [Header("Inventory")]
    public Inventory inventory;

    [Header("Skills")]
    public Skill[] skills;

    private void Awake()
    {
        BattleManager.Instance.player = this;
    }

    protected override void Start()
    {
        base.Start();
        this.mana.Init();
        //Refresh Skill Colltime and info
    }

    protected override void OnDead()
    {
        this.health.Init();
        this.mana.Init();
        //Refresh Skill Cooltime and info

        //Retry Battle
    }

}
