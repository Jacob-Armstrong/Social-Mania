using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickDetector : MonoBehaviour
{
    /* ==== References ==== */
    [SerializeField] Stats stats;

    /* ==== Game Objects ==== */
    [SerializeField] Button mainButton;

/* ==== Local Variables ==== */

    void Awake()
    {
        mainButton.onClick.AddListener(buttonClicked);
    }

    void buttonClicked()
    {
        stats.numClicks += 1;
    }
}
