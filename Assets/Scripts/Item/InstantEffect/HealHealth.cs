using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealHealth : MonoBehaviour, IUseable
{
    [SerializeField] int value;
    public void OnUse()
    {
        GameManager.Instance.battleManager.player.health.AddValue(value);
    }
}

