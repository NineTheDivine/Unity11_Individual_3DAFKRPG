using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusUI : MonoBehaviour
{
    [SerializeField] BarTypeUI hpBar;
    [SerializeField] BarTypeUI mpBar;
    [SerializeField] SkillButton[] skillButtons = new SkillButton[4];
}
