using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    [SerializeField] GameObject content;
    [SerializeField] UpgradeButton buttonTemplate;

    List<UpgradeButton> buttons = new();

    public void SpawnUpgrade(Upgrade upgrade)
    {
        UpgradeButton b = Instantiate(buttonTemplate, content.transform);
        b.Initialize(upgrade);

        buttons.Add(b);
    }

    public void ResetMenu()
    {
        for(int i = buttons.Count - 1; i >= 0; --i)
        {
            RemoveButton(i);
        }
    }

    public void RemoveButton(int index)
    {
        if(buttons[index] != null)
            Destroy(buttons[index].gameObject);

        buttons.RemoveAt(index);
    }
}