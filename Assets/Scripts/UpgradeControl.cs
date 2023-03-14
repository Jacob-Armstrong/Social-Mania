using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// NOTE - change var names with player- to something more fitting (upgrade?)
// Something about recycling and/or deleting buttons

// Purpose of this script is to instantiate the button objects

public class UpgradeControl : MonoBehaviour
{
    
    private List<UpgradeItem> upgradeList;


    [SerializeField]
    private GameObject buttonTemplate;

    /*
    [SerializeField]
    private GridLayoutGroup gridGroup; // Allows changing column count
    */

    [SerializeField]
    private Sprite[] iconSprites;

    void Start()
    {
        upgradeList = new List<UpgradeItem>();

        for (int i = 0; i < 10; i++)
        {
            UpgradeItem newItem = new UpgradeItem();
            newItem.iconSprite = iconSprites[0];

            upgradeList.Add(newItem);
        }

        //GenUpgrades();
    }


    void GenUpgrades()
    {
        /*
        // Section for formatting column count
        if (upgradeList.Count < 11)
        {
            //gridGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount
            gridGroup.constraintCount = upgradeList.Count;
        }
        */

        // Creates an actual button based on each object in the "playerInventory" list
        
        foreach (UpgradeItem newItem in upgradeList)
        {
            GameObject newButton = Instantiate(buttonTemplate) as GameObject;
            newButton.SetActive(true);

            newButton.GetComponent<UpgradeButton>().SetIcon(newItem.iconSprite);
            newButton.transform.SetParent(buttonTemplate.transform.parent, false);
        }
    }


    // !! change to upgradeItem...or something
    public class UpgradeItem
    {
        public Sprite iconSprite;
    }


}
