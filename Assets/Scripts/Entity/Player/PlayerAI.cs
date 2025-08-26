using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : EntityAI
{
    [SerializeField] LayerMask enemyLayer;
    protected override void Init()
    {
        //transform.position = GameManager.Instance.battleManager.Map.SpawnPosition
        currentState = entityAIData.initialState;
        transform.position = new Vector3(0, 1, 6);
    }

    protected override void Update()
    {
        if (this.currentState == EntityAIState.Move)
        {
            transform.Translate(moveAmount * Time.deltaTime * transform.right);
            if (Physics.Raycast(transform.position, transform.right, detectRadius, enemyLayer))
            {
                currentState = EntityAIState.Attack;
            }
        }

        else if (this.currentState == EntityAIState.Attack)
        {
            Enemy enemy = GameManager.Instance.battleManager.enemy;
            if (enemy == null)
                currentState = EntityAIState.End;

            else if (Time.time - lastAttackTime >= attackDelay)
            {
                Debug.Log("Attack");

                lastAttackTime = Time.time;
                entity.ApplyDamage(enemy, entity.curAtk);
            }
        }

        //Collect Items and Reload Stage Later
        else if (this.currentState == EntityAIState.End)
        {
            currentState = EntityAIState.None;
            if (entity.isDead)
                StartCoroutine(FailStage());
            else
                StartCoroutine(ClearStage());
        }
    }

    private IEnumerator ClearStage()
    {
        //Collect Enemy Drops
        yield return new WaitForSeconds(3.0f);
        //Reload Stage
    }

    private IEnumerator FailStage()
    {
        yield return new WaitForSeconds(3.0f);
        //Reload Stage
    }
}
