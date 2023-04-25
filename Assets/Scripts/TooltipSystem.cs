using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
    static TooltipSystem current;

    public Tooltip tooltip;

    static float delayNum = 0.5f;

    public void Awake()
    {
        current = this;
    }

    static IEnumerator delay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        current.tooltip.gameObject.SetActive(true);
    }

    public static void Show(string content, string cost = "", string header = "")
    {
        current.tooltip.setText(content, cost, header);
        current.tooltip.gameObject.SetActive(true);
    }

    public static void Hide()
    {
        current.tooltip.gameObject.SetActive(false);
    }
}
