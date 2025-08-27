using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class OneValueTextSetter : MonoBehaviour, ITextSetter
{
    [SerializeField] public TextMeshProUGUI textbox;
    [SerializeField] private string placeHolderText;
    [SerializeField] private bool isPlaceHolderBack;

    public void SetText(int curValue, int maxValue = 0)
    {
        StringBuilder sb = new StringBuilder();
        if (isPlaceHolderBack)
        {
            textbox.text = sb.Append(curValue).Append(placeHolderText).ToString(); 
        }
        else
        {
            textbox.text = sb.Append(placeHolderText).Append(curValue).ToString();
        }
    }
}
