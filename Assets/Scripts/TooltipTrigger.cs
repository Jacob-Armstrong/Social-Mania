using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    
    UpgradeButton upgradeButton;
    public string otherDescription;

    void Update()
    {
        if (GetComponentInParent<UpgradeButton>())
        {
            upgradeButton = GetComponentInParent<UpgradeButton>();
        }
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (otherDescription != "")
        {
            TooltipPopup.displayInfo(otherDescription);
        }

        if (upgradeButton)
        {
            TooltipPopup.displayInfo(upgradeButton);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipPopup.hideInfo();
    }
}
