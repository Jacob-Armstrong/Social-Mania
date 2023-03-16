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
    public int totalNumUpgrades;
    public string totalTimePlayed;
    public int numClicks;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        totalTimePlayed = timeManager.sessionLength.ToString();
    }
}