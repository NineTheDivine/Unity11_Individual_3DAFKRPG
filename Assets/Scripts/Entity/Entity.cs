using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [Header("Status")]
    public Status health;

    protected virtual void Start()
    {
        health.Init();
    }

    protected abstract void OnDead();
}
