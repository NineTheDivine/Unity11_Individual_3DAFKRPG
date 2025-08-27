using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class SlashTextSetter : MonoBehaviour, ITextSetter
{
    public TextMeshProUGUI textbox;
    [SerializeField] private string placeHolderText;

    public void SetText(int curValue, int maxValue = 0)
    {
        StringBuilder sb = new StringBuilder();
        textbox.text = sb.Append(placeHolderText).Append(curValue).Append(" / ").Append(maxValue).ToString(); 
    }
}
