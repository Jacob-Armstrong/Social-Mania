using System;
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

    /* --- Basic game stats --- */
    [HideInInspector] public double maxAttention = 2.0d;
    [HideInInspector] public double clickMultiplier = 1.0d;
    [HideInInspector] public float attLossMultiplier = 1f;
    [HideInInspector] public float attFloor = 0;
    [HideInInspector] public float attLossDelay = 5f; // Idle time in seconds before attention starts to drop off
    [HideInInspector] public float viewMultiplier = 1f; // Idle time in seconds before attention starts to drop off
    
    /* --- Offline time --- */
    [HideInInspector] public int maxOfflineTime;
    [HideInInspector] public TimeSpan maxOfflineUpgrade = TimeSpan.FromMinutes(1);
    
    /* --- Collab events --- */
    [HideInInspector] public TimeSpan eventTime = TimeSpan.FromSeconds(60);
    [HideInInspector] public int eventChance;
    [HideInInspector] public int successChance;
    [HideInInspector] public double eventGainMultiplier;
    [HideInInspector] public double eventLossMultiplier;

    /* ==== Default Stats ==== */
    public double d_maxAttention = 2.0d;
    public double d_clickMultiplier = 1.0d;
    public float d_attLossMultiplier = 1f;
    public float d_attFloor = 0;
    public float d_attLossDelay = 5f;
    public int d_maxOfflineTime = 0;
    public int d_viewMultiplier = 1;
    public int d_eventChance = 100;
    public int d_successChance = 50;
    public double d_eventGainMultiplier = 0.50;
    public double d_eventLossMultiplier = 0.15;

    // Start is called before the first frame update
    void Awake()
    {
        for(int i = 0; i < upgradeList.Count; ++i)
        {
            upgradeList[i].Initialize();
        }

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
                if (resources.views >= upgrades[i].viewRequirement && 
                    resources.followers >= upgrades[i].followerCost/2 &&
                    (upgrades[i].prereqId == "" || purchasedUpgrades.Contains(upgrades[i].prereqId)))
                {
                        upgradeMenu.SpawnUpgrade(upgrades[i]);
                        upgrades.RemoveAt(i);
                        --i;
                }

                yield return null;
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
        maxOfflineTime = d_maxOfflineTime;
        maxOfflineUpgrade = TimeSpan.FromMinutes(maxOfflineTime);
        viewMultiplier = d_viewMultiplier;
        eventChance = d_eventChance;
        successChance = d_successChance;
        eventGainMultiplier = d_eventGainMultiplier;
        eventLossMultiplier = d_eventLossMultiplier;
    }

    public void PurchaseUpgrade(Upgrade upgrade)
    {
        LoadUpgrade(upgrade);

        resources.followers -= upgrade.followerCost;
        resources.attention -= upgrade.attentionCost;
    }

    public List<string> GetPurchasedUpgrades()
    {
        return purchasedUpgrades;
    }

    private void LoadUpgrade(Upgrade upgrade)
    {
        maxAttention = Math.Max(upgrade.maxAttention, maxAttention);
        clickMultiplier = Math.Max(upgrade.clickMultiplier, clickMultiplier);
        attLossDelay = Mathf.Max(upgrade.attentionLossDelay, attLossDelay);
        attFloor = Mathf.Max(upgrade.attentionFloor, attFloor);
        maxOfflineTime = Mathf.Max(upgrade.maxOfflineTime, maxOfflineTime);
        viewMultiplier = Mathf.Max(upgrade.viewMultiplier, viewMultiplier);

        if(upgrade.attentionLossMultiplier > 0)
            attLossMultiplier = upgrade.attentionLossMultiplier;

        if (upgrade.maxOfflineTime > 0)
            maxOfflineUpgrade = TimeSpan.FromMinutes(maxOfflineTime);

        purchasedUpgrades.Add(upgrade.id);
    }

    public void LoadPurchasedUpgrades(List<string> pUpgrades)
    {
        upgradeMenu.ResetMenu();

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
