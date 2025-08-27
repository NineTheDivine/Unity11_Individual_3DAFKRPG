using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public interface ITextSetter
{
    public void SetText(int curValue, int maxValue = 0);
}
