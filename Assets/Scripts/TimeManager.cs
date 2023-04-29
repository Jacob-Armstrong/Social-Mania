using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net.Security;
using System.Text;
using TMPro;
using Unity.VisualScripting;

public class TimeManager : MonoBehaviour
{
    /* ==== References ==== */
    [SerializeField] Stats stats;
    [SerializeField] Resources resources;
    [SerializeField] Profile profile;
    [SerializeField] Upgrades upgrades;
    // Upgrades here

    /* ==== Game Objects ==== */
    public TextMeshProUGUI textTimeElapsed;
    public GameObject offlineTimePopup;
    public TextMeshProUGUI[] offlineText;

    /* ==== Local Variables ==== */
    /* -- Saved Data -- */
    public DateTime startDate;
    public DateTime lastSeen;

    /* -- Calculations -- */
    public TimeSpan offlineTime;
    double offlineEarnings;

    // Start is called before the first frame update
    void Start()
    {
        startDate = DateTime.Now;
    }

    void FixedUpdate()
    {
        textTimeElapsed.text = "Time elapsed: " + timespanFormat(DateTime.Now.Subtract(startDate));
    }

    public void offlinePopup()
    {
        profile.disableButtons();
        
        // Calculate offline time
        offlineTime = DateTime.Now - lastSeen;
        
        // Calculate offline earnings

        if (upgrades.maxOfflineUpgrade.TotalSeconds > 0)
        {
            Debug.Log("Time since last save: " + timespanFormat(offlineTime)); // replace with popup
            offlineText[0].text = "You have been offline for " + timespanFormat(offlineTime) + ".";
            offlineText[1].text = "Your max offline time is " + timespanFormat(upgrades.maxOfflineUpgrade) + ".";
            if (offlineTime > upgrades.maxOfflineUpgrade)
            {
                offlineEarnings = ((resources.followers * 0.5f) / 5) * (float)upgrades.maxOfflineUpgrade.TotalSeconds;
                offlineText[2].text = "You have earned " + (int)offlineEarnings + " views from " + timespanFormat(upgrades.maxOfflineUpgrade) + " of offline time!";
            }
            else if (offlineTime < upgrades.maxOfflineUpgrade)
            {
                offlineEarnings = ((resources.followers * 0.5f) / 5) * (float)offlineTime.TotalSeconds;
                offlineText[2].text = "You have earned " + (int)offlineEarnings + " views from " + timespanFormat(offlineTime) + " of offline time!";
            }

            resources.views += offlineEarnings;
        
            offlineTimePopup.SetActive(true);
        }
        else
        {
            profile.enableButtons();
        }
        
        
        
        // you have been offline for {2 hours, 10 minutes, 15 seconds}
        // your max offline upgrade is {30 minutes}
        // you have earned {40,293} views from {30 minutes} of offline time!
    }
    
    public string timespanFormat(TimeSpan timespan)
    {

        StringBuilder sb = new StringBuilder("", 50);
        
        switch(timespan.Hours)
        {
            case >= 2:
                sb.Insert(0, (int)timespan.TotalHours + " hours");
                break;
            case 1:
                sb.Insert(0, (int)timespan.TotalHours + " hour");
                break;
        }

        switch(timespan.Hours)
        {
            case >= 1:
                switch (timespan.Minutes)
                {
                    case > 1:
                        sb.Append(", " + timespan.Minutes + " minutes");
                        break;
                    case 1:
                        sb.Append(", " + timespan.Minutes + " minute");
                        break;
                }
                break;
            case 0:
                switch (timespan.Minutes)
                {
                    case > 1:
                        sb.Append(timespan.Minutes + " minutes");
                        break;
                    case 1:
                        sb.Append(timespan.Minutes + " minute");
                        break;
                }
                break;
        }
        if (timespan.Hours >0  || timespan.Minutes > 0)
        {
            switch (timespan.Seconds)
            {
                case > 1:
                    sb.Append(", " + timespan.Seconds + " seconds");
                    break;
                case 1:
                    sb.Append(", " + timespan.Seconds + " second");
                    break;
            }
        }
        else if (timespan.Hours == 0 || timespan.Minutes == 0)
        {
            switch (timespan.Seconds)
            {
                case > 1:
                    sb.Append(timespan.Seconds + " seconds");
                    break;
                case 1:
                    sb.Append(timespan.Seconds + " second");
                    break;
            }
        }

        return sb.ToString();
    }
}
