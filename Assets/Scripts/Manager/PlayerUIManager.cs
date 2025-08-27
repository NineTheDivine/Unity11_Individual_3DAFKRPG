using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class PlayerUIManager : MonoBehaviour
{
    [SerializeField] private InfoUI _infoUI;
    public InfoUI infoUI { get { return _infoUI; } }
    [SerializeField] StatusUI _statusUI;
    public StatusUI statusUI { get { return _statusUI; } }

    private void Awake()
    {
        GameManager.Instance.playerUIManager = this;
    }
}
