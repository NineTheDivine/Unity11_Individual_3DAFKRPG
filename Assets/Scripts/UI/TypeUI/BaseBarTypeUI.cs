using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BaseBarTypeUI : MonoBehaviour
{
    [SerializeField] protected Status[] eventStatus;
    [SerializeField] protected Image fillImage;
    [SerializeField] public ITextSetter textSetter;
    [SerializeField] bool AddTextSetterInActions = true;

    public void Awake()
    {
        textSetter = this.GetComponent<ITextSetter>();
        for (int i = 0; i < eventStatus.Length; i++)
        {
            eventStatus[i].AddAction(SetFill);
            if (textSetter != null && AddTextSetterInActions)
            {
                eventStatus[i].AddAction(textSetter.SetText);
            }
        }
    }
    
    virtual public void SetFill(int curValue, int maxValue)
    {
        fillImage.fillAmount = Mathf.Clamp((float)curValue / maxValue, 0, 1);
    }
}
