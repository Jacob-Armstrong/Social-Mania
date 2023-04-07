using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    /* ==== References ==== */
    [SerializeField] Resources resources;
    [SerializeField] UpgradeMenu upgradeMenu;
    [SerializeField] Upgrade[] upgradeList;

    /* ==== Game Objects ==== */

    /* ==== Local Variables ==== */
    private Hashtable upgrades = new();
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

        for(int i = 0; i < upgradeList.Length; ++i)
        {
            var upgrade = upgradeList[i];

            if(upgrades[upgrade.id] == null) // If there isn't an id conflict, add the upgrade to the hashtable
            {
                upgrades.Add(upgrade.id, upgrade);
            }
            else
            {
                Debug.Log("Upgrade id conflict: " + upgrade.id);
            }
        }

        StartCoroutine(UpdateUpgradeMenu());
    }

    IEnumerator UpdateUpgradeMenu()
    {
        List<string> remove = new();

        while (true)
        {
            remove.Clear();

            foreach (DictionaryEntry u in upgrades)
            {
                yield return null;

                Upgrade currentUpgrade = (Upgrade)upgrades[u.Key];

                if (resources.followers >= currentUpgrade.followerCost/2 &&
                    resources.haters >= currentUpgrade.haterCost/2 &&
                    upgrades[currentUpgrade.prereqId] == null)
                {
                    upgradeMenu.SpawnUpgrade(currentUpgrade);
                    remove.Add((string)u.Key);
                }
            }

            foreach(string s in remove)
            {
                upgrades.Remove(s);
                yield return null;
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
    }
}

