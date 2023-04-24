using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class Tooltip : MonoBehaviour
{
    public TextMeshProUGUI headerText;
    public TextMeshProUGUI contentText;
    public TextMeshProUGUI costText;

    public LayoutElement layoutElement;

    public RectTransform rectTransform;

    public GameObject tooltip;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    
    void Update()
    {
        /*if (Application.isEditor)
        {
            int headerLength = headerText.text.Length;
            int contentLength = contentText.text.Length;
            int costLength = costText.text.Length;

            layoutElement.enabled =
                (headerLength > characterWrapLimit || contentLength > characterWrapLimit ||
                 costLength > characterWrapLimit)
                    ? true
                    : false;
        }
        */

        Vector2 position = Input.mousePosition;

        float pivotX = position.x / Screen.width;
        float pivotY = position.y / Screen.height;

        rectTransform.pivot = new Vector2(pivotX, pivotY);
        transform.position = position;
    }

    public void setText(string content, string cost = "", string header = "")
    {
        if (string.IsNullOrEmpty(header))
        {
            headerText.gameObject.SetActive(false);
        }
        else
        {
            headerText.gameObject.SetActive(true);
            headerText.text = header;
        }
        
        if (string.IsNullOrEmpty(cost))
        {
            costText.gameObject.SetActive(false);
        }
        else
        {
            costText.gameObject.SetActive(true);
            costText.text = cost;
        }

        contentText.text = content;

        int headerLength = headerText.text.Length;
        int contentLength = contentText.text.Length;
        int costLength = costText.text.Length;

        layoutElement.enabled = Math.Max(headerText.preferredWidth, contentText.preferredWidth) >= layoutElement.preferredWidth;

        tooltip = this.gameObject;
        tooltip.SetActive(true);


    }
}
