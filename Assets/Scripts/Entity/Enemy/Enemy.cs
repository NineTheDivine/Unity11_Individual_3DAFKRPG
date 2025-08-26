using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    private void Awake()
    {
        GameManager.Instance.battleManager.enemy = this;
    }

    protected override void OnDead()
    {
        Debug.Log("Enemy is Dead");
        throw new System.NotImplementedException();
    }
}
