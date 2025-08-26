using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static private GameManager _instance;
    static public GameManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new GameObject("GameManager").AddComponent<GameManager>();
            return _instance;
        }
    }
    public BattleManager battleManager;
    public PlayerUIManager playerUIManager;
    public SaveManager saveManager;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(_instance != this)
            Destroy(gameObject);
        //Try Load Battle Manager, if not, make one
        if(saveManager == null)
            saveManager = new GameObject("SaveManager").AddComponent<SaveManager>();


        if (battleManager == null)
        {
            battleManager = new GameObject("BattleManager").AddComponent<BattleManager>();
        }
    }


    //Save Battle Managerwhen application Quit
    private void OnApplicationQuit()
    {
        saveManager.SaveData();
    }
}
