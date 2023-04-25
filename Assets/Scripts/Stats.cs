using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    /* ==== References ==== */
    [SerializeField] TimeManager timeManager;
    [SerializeField] Resources resources;

    /* ==== Game Objects ==== */

    /*  ==== Local Variables ==== */
    /* -- cool stats! -- */
    public float viewsPerSecond;
    
    /* -- saved data -- */
    public int lifetimeViews;
    
    public int numClicks;
    public int totalNumUpgrades;
}