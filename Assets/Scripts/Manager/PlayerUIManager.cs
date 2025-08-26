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
        Init();
    }

    public void Init()
    {
        //Set InfoUI
        Player player = GameManager.Instance.battleManager.player;
        StringBuilder sb = new StringBuilder();
        _infoUI.experienceBar.SetText(sb.Append("Level ").Append(player.level).ToString());
        sb.Clear();
        _infoUI.goldCount.SetText(sb.Append(player.gold).Append(" G").ToString());
        sb.Clear();
        _infoUI.stageCount.SetText(sb.Append("Stage ").Append(GameManager.Instance.battleManager.stage).ToString());
        sb.Clear();

        //Set StatusUI
        statusUI.hpBar.SetText(sb.Append(player.health.curValue).Append(" / ").Append(player.health.MaxValue).ToString());
        statusUI.hpBar.SetFill((float)player.health.curValue / player.health.MaxValue);
        sb.Clear();
        statusUI.mpBar.SetText(sb.Append(player.mana.curValue).Append(" / ").Append(player.mana.MaxValue).ToString());
        statusUI.mpBar.SetFill((float)player.mana.curValue / player.mana.MaxValue);
        sb.Clear();

        //Set Skill Btns
    }
}
