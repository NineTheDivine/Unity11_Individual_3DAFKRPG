using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityAI : MonoBehaviour
{
    public enum EntityAIState
    {
        None,
        Move,
        Attack,
        End
    }
    [SerializeField] protected EntityAIData entityAIData;

    [HideInInspector] protected float moveAmount = 1.0f;
    [HideInInspector] protected float detectRadius = 1.0f;
    [HideInInspector] protected float attackDelay = 1.0f;
    [HideInInspector] protected float lastAttackTime = 0.0f;
    protected Entity entity;

    public EntityAIState currentState;

    protected void Awake()
    {
        if (entityAIData != null)
        {
            moveAmount = entityAIData.moveAmount;
            detectRadius = entityAIData.detectRadius;
            attackDelay = entityAIData.attackDelay;
            lastAttackTime = entityAIData.lastAttackTime;
            currentState = entityAIData.initialState;
        }
        entity = GetComponent<Entity>();
    }

    private void Start()
    {
        Init();
    }
    abstract protected void Init();
    abstract protected void Update();
}
