using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealMana : MonoBehaviour, IUseable
{
    [SerializeField] int value;
    public void OnUse()
    {
        GameManager.Instance.battleManager.player.mana.AddValue(value);
    }
}
