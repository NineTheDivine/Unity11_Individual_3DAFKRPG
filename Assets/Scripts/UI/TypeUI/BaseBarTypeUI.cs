using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BaseBarTypeUI : MonoBehaviour
{
    [SerializeField] protected Image fillImage;
    [SerializeField] protected TextMeshProUGUI infoText;

    virtual public void SetText(string s)
    {
        infoText.text = s;
    }
    
    
    virtual public void SetFill(float rate)
    {
        fillImage.fillAmount = rate;
    }
}
