using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EntityAI;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemyAI : EntityAI
{
    Player player;
    protected override void Init()
    {
        //transform.position = GameManager.Instance.battleManager.Map.SpawnPosition
        currentState = entityAIData.initialState;
        transform.position = new Vector3(25, 1, 6);
        player = GameManager.Instance.battleManager.player;
    }

    protected override void Update()
    {
        if (!entity.isDead && (currentState == EntityAIState.None || currentState == EntityAIState.Move)
            && Vector3.Distance(transform.position, player.transform.position) <= detectRadius)
            currentState = EntityAIState.Attack;

        if (this.currentState == EntityAIState.Move)
        {
            transform.Translate(moveAmount * Time.deltaTime * transform.right);
        }

        else if (this.currentState == EntityAIState.Attack)
        {
            Player player = GameManager.Instance.battleManager.player;
            if (player == null)
                currentState = EntityAIState.End;

            else if (Time.time - lastAttackTime >= attackDelay)
            {
                lastAttackTime = Time.time;
                entity.ApplyDamage(player, entity.curAtk);
            }
        }
    }
}
