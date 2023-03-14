using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// NOTE - change var names with player- to something more fitting (upgrade?)
// Something about recycling and/or deleting buttons

public class UpgradeControl : MonoBehaviour
{
    private List<PlayerItem> upgradeList;

    [SerializeField]
    private GameObject buttonTemplate;

    [SerializeField]
    private GridLayoutGroup gridGroup; // Allows changing column count

    [SerializeField]
    private Sprite[] iconSprites;

    void Start()
    {
        upgradeList = new List<PlayerItem>();


        // Loop that creates objects (to become buttons)
        for (int i = 0; i < 100; i++)
        {
            PlayerItem newItem = new PlayerItem();

            // Replace this - sets random icon
            newItem.iconSprite = iconSprites[Random.Range(0, iconSprites.Length)];

            upgradeList.Add(newItem);
        }
    }

    void GenInventory()
    {
        if (upgradeList.Count < 11)
        {
            //gridGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount
            gridGroup.constraintCount = upgradeList.Count;
        }

        // Creates an actual button based on each object in the "playerInventory" list
        foreach (PlayerItem newItem in upgradeList)
        {
            GameObject newButton = Instantiate(buttonTemplate) as GameObject;
            newButton.SetActive(true);

            newButton.GetComponent<UpgradeButton>().SetIcon(newItem.iconSprite);
            newButton.transform.SetParent(buttonTemplate.transform.parent, false);
        }
    }


    // !! change to upgradeItem...or something
    public class PlayerItem
    {
        public Sprite iconSprite;
    }


}
