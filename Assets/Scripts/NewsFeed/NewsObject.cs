using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewsObject : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI myText;

    public void SetText(string textString)
    {
        myText.text = textString;
    }

    public TextMeshProUGUI GetText()
    {
        return myText;
    }

}
