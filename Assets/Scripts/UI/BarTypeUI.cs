using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BarTypeUI : MonoBehaviour
{
    [SerializeField] Image fillImage;
    [SerializeField] TextMeshProUGUI infoText;

    public void SetText(string s)
    {
        infoText.text = s;
    }

    public void SetFill(float rate)
    {
        fillImage.fillAmount = rate;
    }
}
