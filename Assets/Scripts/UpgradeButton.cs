using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    Button button;

    Resources resources;
    Upgrades upgrades;
    Upgrade upgrade;

    double followerCost;
    double attentionCost;

    private void Start()
    {
        button = GetComponent<Button>();
        resources = FindObjectOfType<Resources>();
        upgrades = FindObjectOfType<Upgrades>();
    }

    private void Update()
    {
        if(!button.interactable && followerCost <= resources.followers && attentionCost <= resources.attention)
        {
            button.interactable = true;
        }
        else if(button.interactable && (followerCost > resources.followers || attentionCost > resources.attention))
        {
            button.interactable = false;
        }
    }

    public void Initialize(Upgrade _upgrade)
    {
        upgrade = _upgrade;
        followerCost = upgrade.followerCost;
        GetComponentInChildren<TextMeshProUGUI>().text = upgrade.buttonText;
    }

    public void ButtonClicked()
    {
        upgrades.PurchaseUpgrade(upgrade);
        Destroy(gameObject);
    }
}