using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    //public TooltipPopup tooltipPopup;
    UpgradeButton upgradeButton;

    void Update()
    {
        //tooltipPopup = GetComponent<TooltipPopup>();
        upgradeButton = GetComponentInParent<UpgradeButton>();
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipPopup.displayInfo(upgradeButton);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipPopup.hideInfo();
    }
}
