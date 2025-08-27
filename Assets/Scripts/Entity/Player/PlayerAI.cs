using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : EntityAI
{
    Enemy enemy;
    public override void Init()
    {
        //transform.position = GameManager.Instance.battleManager.Map.SpawnPosition
        currentState = entityAIData.initialState;
        transform.position = new Vector3(0, 1, 6);
        enemy = GameManager.Instance.battleManager.enemy;
    }

    protected override void Update()
    {
        if (currentState == EntityAIState.End)
            return;

        if (entity.isDead)
            this.currentState = EntityAIState.End;


        if (this.currentState == EntityAIState.Move)
        {
            transform.Translate(moveAmount * Time.deltaTime * transform.right);
            if (!entity.isDead && Vector3.Distance(transform.position, enemy.transform.position) <= detectRadius)
                currentState = EntityAIState.Attack;
        }

        else if (this.currentState == EntityAIState.Attack)
        {
            Enemy enemy = GameManager.Instance.battleManager.enemy;
            if (enemy.isDead)
                currentState = EntityAIState.End;

            else if (Time.time - lastAttackTime >= attackDelay)
            {
                lastAttackTime = Time.time;
                entity.ApplyDamage(enemy, entity.curAtk);
            }
        }
    }
}
