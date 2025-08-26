using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIManager : MonoBehaviour
{
    private PlayerUIManager _instance;
    public PlayerUIManager Instance { get { return _instance; } }

    [SerializeField] private InfoUI _infoUI;
    public InfoUI infoUI { get { return _infoUI; } }
    [SerializeField] StatusUI _statusUI;
    public StatusUI statusUI { get { return _statusUI; } }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
