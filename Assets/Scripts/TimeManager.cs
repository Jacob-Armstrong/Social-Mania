using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using TMPro;
using Unity.VisualScripting;

public class TimeManager : MonoBehaviour
{
    /* ==== References ==== */
    [SerializeField] Stats stats;

    /* ==== Game Objects ==== */
    public TextMeshProUGUI textTimeElapsed;

    /* ==== Local Variables ==== */
    /* -- Saved Data -- */
    public DateTime startDate;
    public DateTime lastSeen;
    public TimeSpan maxOfflineUpgrade;

    /* -- Calculations -- */
    public TimeSpan offlineTime;

    // Start is called before the first frame update
    void Start()
    {
        startDate = DateTime.Now;
        maxOfflineUpgrade = TimeSpan.Zero;
    }

    void FixedUpdate()
    {
        textTimeElapsed.text = "Time elapsed: " + timespanFormat(DateTime.Now.Subtract(startDate));
    }

    public void offlinePopup()
    {
        offlineTime = DateTime.Now - lastSeen;
        Debug.Log("Time since last save: " + timespanFormat(offlineTime)); // replace with popup
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
