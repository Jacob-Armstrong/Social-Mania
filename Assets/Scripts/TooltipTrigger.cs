using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [TextArea]
    public string header;
    [TextArea]
    public string content;
    [TextArea]
    public string cost;

    UpgradeButton upgrade;

    float delay = 0.5f;

    void Update()
    {
        upgrade = GetComponentInParent<UpgradeButton>();
        if (upgrade)
        { 
            cost = "Cost: " + upgrade.getCost() + " followers";
            content = upgrade.getDescription();
            header = upgrade.getHeader();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //StopAllCoroutines();
        //StartCoroutine(timer());
        TooltipSystem.Show(content, cost, header);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //StopAllCoroutines();
        TooltipSystem.Hide();
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(delay);
        TooltipSystem.Show(content, cost, header);
    }
}
