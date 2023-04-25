using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UpgradeButton : MonoBehaviour
{
    Button button;

    Resources resources;
    Upgrades upgrades;
    Upgrade upgrade;

    double followerCost;
    double attentionCost;

    string header;
    string description;
    string cost;

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

        header = upgrade.header;
        description = upgrade.description;
        cost = upgrade.optionalCostText;

        if (cost == "")
        { 
            cost = costString();
        }
    }

    string costString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("Cost: ");

        if (followerCost != 0)
        {
            sb.Append(followerCost).Append(" followers");
        }

        // Implement when more costs
        /*
        if (attentionCost != 0)
        {
            if (followerCost != 0)
            {
                sb.Append(", ");
            }

            sb.Append(attentionCost).Append("x attention");
        }
        */

        return sb.ToString();
    }

    public string getTooltipInfoText()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append(header).AppendLine();
        sb.Append(description).AppendLine().AppendLine();
        sb.Append(cost).AppendLine();

        return sb.ToString();
    }

    public void ButtonClicked()
    {
        upgrades.PurchaseUpgrade(upgrade);
        Destroy(gameObject);
    }
    
}