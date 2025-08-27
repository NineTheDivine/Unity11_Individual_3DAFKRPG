using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainGold : MonoBehaviour, IUseable
{
    [SerializeField] int value;
    public void OnUse()
    {
        GameManager.Instance.battleManager.player.AddGold(value);
    }
}
