using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [Header("EntitySpriteAnimator")]
    [SerializeField] protected EntityAnimator entityAnimator;

    [Header("Status")]
    public Status health;
    public bool isDead = false;
    [SerializeField] protected int originalAtk = 5;
    virtual public int curAtk { get { return originalAtk; } }

    protected virtual void Start()
    {
        health.Init();
        isDead = false;
    }

    public void ApplyDamage(Entity target, int damage)
    {
        if (target.isDead)
            return;
        target.TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        if (isDead)
            return;
        Debug.Log(this.name + "이 피해 " + damage.ToString() + " 입음");
        health.SubValue(damage);
        if (health.curValue <= 0)
            OnDead();
        else
            entityAnimator.OnDamagedApplied();
    }

    protected abstract void OnDead();
}
