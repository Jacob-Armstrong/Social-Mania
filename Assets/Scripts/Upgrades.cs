using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    /* ==== References ==== */
    [SerializeField] Resources resources;
    [SerializeField] UpgradeMenu upgradeMenu;
    [SerializeField] List<Upgrade> upgradeList;
    
    /* ==== Game Objects ==== */
    
    /* ==== Local Variables ==== */
    List<string> purchasedUpgrades = new();
    public double maxAttention;
    public double clickMultiplier;
    public float attLossMultiplier = 1f;
    public float attFloor = 0;
    public float attLossDelay = 5f; // Idle time in seconds before attention starts to drop off
    
    // Start is called before the first frame update
    void Start()
    {
        maxAttention = 2.0d;
        clickMultiplier = 1.0d;
        
        StartCoroutine(UpdateUpgradeMenu());
    }

    IEnumerator UpdateUpgradeMenu()
    {
        while (true)
        {
            for(int i = 0; i < upgradeList.Count; ++i)
            {
                yield return null;

                if (resources.views >= upgradeList[i].viewRequirement &&
                    resources.followers >= upgradeList[i].followerCost/2 &&
                    resources.haters >= upgradeList[i].haterCost/2)
                {
                    upgradeMenu.SpawnUpgrade(upgradeList[i]);
                    upgradeList.RemoveAt(i);
                    --i;
                }
            }

            yield return null;
        }
    }

    public void PurchaseUpgrade(Upgrade upgrade)
    {
        maxAttention += upgrade.maxAttention;
        clickMultiplier += upgrade.clickMultiplier;
        attLossMultiplier -= upgrade.attentionLossMultiplier;
        attLossDelay -= upgrade.attentionLossDelay;
        attFloor += upgrade.attentionFloor;

        resources.followers -= upgrade.followerCost;
        resources.haters -= upgrade.haterCost;

        purchasedUpgrades.Add(upgrade.id);
    }

    public List<string> GetPurchasedUpgrades()
    {
        return purchasedUpgrades;
    }

    private void LoadUpgrade(Upgrade upgrade)
    {
        maxAttention += upgrade.maxAttention;
        clickMultiplier += upgrade.clickMultiplier;
        attLossMultiplier -= upgrade.attentionLossMultiplier;
        attLossDelay -= upgrade.attentionLossDelay;
        attFloor += upgrade.attentionFloor;

        purchasedUpgrades.Add(upgrade.id);
    }

    public void LoadPurchasedUpgrades(List<string> pUpgrades)
    {
        foreach(string id in pUpgrades)
        {
            for(int i = 0; i < upgradeList.Count; ++i)
            {
                if(id == upgradeList[i].id)
                {
                    LoadUpgrade(upgradeList[i]);
                    upgradeList.RemoveAt(i);
                    break;
                }
            }
        }
    }

    public void RemoveUpgrades()
    {
        purchasedUpgrades = new();
    }
}

