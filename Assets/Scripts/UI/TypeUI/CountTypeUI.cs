using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountTypeUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI infoText;
    public void SetText(string s)
    {
        infoText.text = s;
    }
}
