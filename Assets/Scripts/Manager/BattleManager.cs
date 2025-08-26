using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Player player;
    public Enemy enemy;

    public int stage = 1;

    private void Awake()
    {
        GameManager.Instance.battleManager = this;
    }

}
