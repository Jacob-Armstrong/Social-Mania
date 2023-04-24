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

    string upgradeId;
    double followerCost;
    double haterCost;
    string header;
    string description;

    private void Start()
    {
        button = GetComponent<Button>();
        resources = FindObjectOfType<Resources>();
        upgrades = FindObjectOfType<Upgrades>();
    }

    private void Update()
    {
        if(!button.interactable && followerCost <= resources.followers && haterCost <= resources.haters)
        {
            button.interactable = true;
        }
    }

    public void Initialize(Upgrade _upgrade)
    {
        upgrade = _upgrade;
        upgradeId = upgrade.id;
        followerCost = upgrade.followerCost;
        haterCost = upgrade.haterCost;
        header = upgrade.header;
        description = upgrade.description;
        GetComponentInChildren<TextMeshProUGUI>().text = upgrade.buttonText;
    }

    public string getCost()
    {
        return followerCost.ToString();
    }
    
    public string getDescription()
    {
        return description;
    }

    public string getHeader()
    {
        return header;
    }

    public void ButtonClicked()
    {
        upgrades.PurchaseUpgrade(upgrade);
        Destroy(gameObject);
    }
}