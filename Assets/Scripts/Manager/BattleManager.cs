using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    static private BattleManager _instance;
    static public BattleManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new GameObject("BattleManager").AddComponent<BattleManager>();
            return _instance;
        }
    }

    public Player player;
    public Enemy enemy;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
            Destroy(gameObject);
    }

}
