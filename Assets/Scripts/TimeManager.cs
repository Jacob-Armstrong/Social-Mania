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
    public DateTime startDate;
    public string startDateString;
    DateTime currentTime;
    
    public TimeSpan timeSinceStartDate;

    // Start is called before the first frame update
    void Start()
    {
        startDate = DateTime.Now;
    }

    void FixedUpdate()
    {
        timeElapsed();
        startDateString = startDate.ToString();
    }

    void timeElapsed()
    {
        currentTime = DateTime.Now;
        timeSinceStartDate = currentTime.Subtract(startDate);

        StringBuilder sb = new StringBuilder("", 50);

        sb.Insert(0, "Time elapsed: ");

        switch(timeSinceStartDate.Hours)
        {
            case >= 2:
                sb.Insert(14, (int)timeSinceStartDate.TotalHours + " hours");
                break;
            case 1:
                sb.Insert(14, (int)timeSinceStartDate.TotalHours + " hour");
                break;
        }

        switch(timeSinceStartDate.Hours)
        {
            case >= 1:
                switch (timeSinceStartDate.Minutes)
                {
                    case > 1:
                        sb.Append(", " + timeSinceStartDate.Minutes + " minutes");
                        break;
                    case 1:
                        sb.Append(", " + timeSinceStartDate.Minutes + " minute");
                        break;
                }
                break;
            case 0:
                switch (timeSinceStartDate.Minutes)
                {
                    case > 1:
                        sb.Append(timeSinceStartDate.Minutes + " minutes");
                        break;
                    case 1:
                        sb.Append(timeSinceStartDate.Minutes + " minute");
                        break;
                }
                break;
        }

        if (timeSinceStartDate.Hours >0  || timeSinceStartDate.Minutes > 0)
        {
            switch (timeSinceStartDate.Seconds)
            {
                case > 1:
                    sb.Append(", " + timeSinceStartDate.Seconds + " seconds");
                    break;
                case 1:
                    sb.Append(", " + timeSinceStartDate.Seconds + " second");
                    break;
            }
        }
        else if (timeSinceStartDate.Hours == 0 || timeSinceStartDate.Minutes == 0)
        {
            switch (timeSinceStartDate.Seconds)
            {
                case > 1:
                    sb.Append(timeSinceStartDate.Seconds + " seconds");
                    break;
                case 1:
                    sb.Append(timeSinceStartDate.Seconds + " second");
                    break;
            }
        }

        textTimeElapsed.text = sb.ToString();
    }
}
