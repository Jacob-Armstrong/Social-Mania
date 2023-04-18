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
        GetComponentInChildren<TextMeshProUGUI>().text = upgrade.buttonText;
    }

    public void ButtonClicked()
    {
        upgrades.PurchaseUpgrade(upgrade);
        Destroy(gameObject);
    }
}