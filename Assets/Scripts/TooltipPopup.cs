using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class TooltipPopup : MonoBehaviour
{
    public GameObject popupCanvasObject;
    public RectTransform popupObject;
    public TextMeshProUGUI infoText;
    public Vector3 offset;
    public float padding;
    
    Canvas popupCanvas;

    static TooltipPopup tooltipPopup;

    void Awake()
    {
        popupCanvas = popupCanvasObject.GetComponent<Canvas>();
        tooltipPopup = this;
        hideInfo();
    }

    void Update()
    {
        followCursor();
    }

    void followCursor()
    {
        if (!popupCanvasObject.activeSelf)
        {
            return;
        }

        Vector3 newPos = Input.mousePosition + offset;
        newPos.z = 0f;

        /*
        float rightEdgeToScreenEdgeDistance = Screen.width - (newPos.x + popupObject.rect.width * popupCanvas.scaleFactor / 2) - padding;
        if (rightEdgeToScreenEdgeDistance < 0)
        {
            newPos.x += rightEdgeToScreenEdgeDistance;
        }
        */
        
        float leftEdgeToScreenEdgeDistance = 0 - (newPos.x - popupObject.rect.width * popupCanvas.scaleFactor / 2) + padding;
        if (leftEdgeToScreenEdgeDistance > 0)
        {
            newPos.x += leftEdgeToScreenEdgeDistance;
        }

        float topEdgeToScreenEdgeDistance = Screen.height - (newPos.y + popupObject.rect.height * popupCanvas.scaleFactor) - padding;
        if (topEdgeToScreenEdgeDistance < 0)
        {
            newPos.y += topEdgeToScreenEdgeDistance;
        }
        

        popupObject.transform.position = newPos;
    }

    public static void displayInfo(UpgradeButton upgradeButton)
    {
        StringBuilder sb = new StringBuilder();

        //sb.Append("<size=35>").Append(upgradeButton.getHeader()).Append("</size>").AppendLine();
        sb.Append(upgradeButton.getTooltipInfoText());
        tooltipPopup.infoText.text = sb.ToString();

        tooltipPopup.popupCanvasObject.SetActive(true);
        LayoutRebuilder.ForceRebuildLayoutImmediate(tooltipPopup.popupObject);
    }

    public static void displayInfo(string buttonDescription)
    {
        tooltipPopup.infoText.text = buttonDescription;
        tooltipPopup.popupCanvasObject.SetActive(true);
        LayoutRebuilder.ForceRebuildLayoutImmediate(tooltipPopup.popupObject);
    }

    public static void hideInfo()
    {
        tooltipPopup.popupCanvasObject.SetActive(false);
    }
}
