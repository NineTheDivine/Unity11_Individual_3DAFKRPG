using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameManager _instance;
    public GameManager Instance { get { return _instance; } }
    BattleManager battleManager;
    PlayerUIManager playerUIManager;
    SaveManager saveManager;

    private void Awake()
    {
        battleManager = BattleManager.Instance;
        playerUIManager = playerUIManager.Instance;
    }
}
