using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewsObject : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI myText;

    [SerializeField]
    private int unlock;

    public void SetText(string textString)
    {
        myText.text = textString;
    }

    public TextMeshProUGUI GetText()
    {
        return myText;
    }
    public void SetRequirement(int unlockAmt)
    {
        unlock = unlockAmt;
    }

    public int GetRequirement()
    {
        return unlock;
    }
}
