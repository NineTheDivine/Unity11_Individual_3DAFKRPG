using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusUI : MonoBehaviour
{
    [SerializeField] public BaseBarTypeUI hpBar;
    [SerializeField] public BaseBarTypeUI mpBar;
    [SerializeField] public SkillButton[] skillButtons = new SkillButton[4];
}
