using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    public void SetText(string text)
    {
        GetComponentInChildren<TextMeshProUGUI>().text = text;
    }

    public void ButtonClicked()
    {
        Destroy(gameObject);
    }
}
