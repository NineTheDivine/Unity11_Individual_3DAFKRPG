using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EntityAI;

[CreateAssetMenu(fileName = "EntityAIData", menuName = "ScriptableObject/EntityAIData")]
public class EntityAIData : ScriptableObject
{
    public float moveAmount;
    public float detectRadius;
    public float attackDelay;
    public float lastAttackTime;
    public EntityAI.EntityAIState initialState = EntityAI.EntityAIState.None;
}
