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
    List<Upgrade> upgrades;

    [HideInInspector] public double maxAttention = 2.0d;
    [HideInInspector] public double clickMultiplier = 1.0d;
    [HideInInspector] public float attLossMultiplier = 1f;
    [HideInInspector] public float attFloor = 0;
    [HideInInspector] public float attLossDelay = 5f; // Idle time in seconds before attention starts to drop off

    /* ==== Default Stats ==== */
    public double d_maxAttention = 2.0d;
    public double d_clickMultiplier = 1.0d;
    public float d_attLossMultiplier = 1f;
    public float d_attFloor = 0;
    public float d_attLossDelay = 5f;

    // Start is called before the first frame update
    void Start()
    {
        upgrades = new List<Upgrade>(upgradeList);
        InitializeStats();
        StartCoroutine(UpdateUpgradeMenu());
    }

    IEnumerator UpdateUpgradeMenu()
    {
        while (true)
        {
            for(int i = 0; i < upgrades.Count; ++i)
            {
                yield return null;

                if (resources.views >= upgrades[i].viewRequirement &&
                    resources.followers >= upgrades[i].followerCost/2 &&
                    resources.haters >= upgrades[i].haterCost/2)
                {
                    upgradeMenu.SpawnUpgrade(upgrades[i]);
                    upgrades.RemoveAt(i);
                    --i;
                }
            }

            yield return null;
        }
    }

    public void InitializeStats()
    {
        maxAttention = d_maxAttention;
        clickMultiplier = d_clickMultiplier;
        attLossMultiplier = d_attLossMultiplier;
        attFloor = d_attFloor;
        attLossDelay = d_attLossDelay;
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
            for(int i = 0; i < upgrades.Count; ++i)
            {
                if(id == upgrades[i].id)
                {
                    LoadUpgrade(upgrades[i]);
                    upgrades.RemoveAt(i);
                    break;
                }
            }
        }
    }

    public void RemoveUpgrades()
    {
        purchasedUpgrades = new();
        upgrades = new List<Upgrade>(upgradeList);
        upgradeMenu.ResetMenu();
        InitializeStats();
    }
}
