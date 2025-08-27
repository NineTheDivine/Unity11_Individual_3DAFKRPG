using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EntityAnimator : MonoBehaviour
{
    Animator animator;

    protected const string IDLESTRING = "Idle";
    protected const string DEADSTRING = "isDead";
    protected const string DAMAGESTRING = "isDamaged";

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnDamagedApplied()
    {
        animator.SetBool(DAMAGESTRING, true);
    }

    public void OnDeadApplied()
    {
        animator.SetBool(DEADSTRING, true);
    }

    public void OnDamageAnimationEnd()
    {
        animator.SetBool(DAMAGESTRING, false);
    }

    public void OnReset()
    {
        animator.SetBool(DAMAGESTRING, false);
        animator.SetBool(DEADSTRING, false);
        animator.Play(IDLESTRING);
    }
}
