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
    public DateTime startTime;
    DateTime currentTime;
    public TimeSpan sessionLength; // += this to totalTimePlayed in stats when game is saved pls (or something idk how timeSpan works)

    // Start is called before the first frame update
    void Start()
    {
        // SET THIS TO THE FIRST TIME THEY START THE GAME INSTEAD
        // if <database has table with string> or <user is authenticated> get timespan
        startTime = DateTime.Now; // Time session begins
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        timeElapsed();
    }

    void timeElapsed()
    {
        currentTime = DateTime.Now;

        sessionLength = currentTime - startTime;

        StringBuilder sb = new StringBuilder("", 50);

        sb.Insert(0, "Time elapsed: ");

        switch(sessionLength.Hours)
        {
            case > 1:
                sb.Insert(14, sessionLength.Hours + " hours");
                break;
            case 1:
                sb.Insert(14, sessionLength.Hours + " hour");
                break;
        }

        switch(sessionLength.Hours)
        {
            case > 0:
                switch (sessionLength.Minutes)
                {
                    case > 1:
                        sb.Append(", " + sessionLength.Minutes + " minutes");
                        break;
                    case 1:
                        sb.Append(", " + sessionLength.Minutes + " minute");
                        break;
                }
                break;
            case 0:
                switch (sessionLength.Minutes)
                {
                    case > 1:
                        sb.Append(sessionLength.Minutes + " minutes");
                        break;
                    case 1:
                        sb.Append(sessionLength.Minutes + " minute");
                        break;
                }
                break;
        }

        if (sessionLength.Hours > 0 || sessionLength.Minutes > 0)
        {
            switch (sessionLength.Seconds)
            {
                case > 1:
                    sb.Append(", " + sessionLength.Seconds + " seconds");
                    break;
                case 1:
                    sb.Append(", " + sessionLength.Seconds + " second");
                    break;
            }
        }
        else if (sessionLength.Hours == 0 || sessionLength.Minutes == 0)
        {
            switch (sessionLength.Seconds)
            {
                case > 1:
                    sb.Append(sessionLength.Seconds + " seconds");
                    break;
                case 1:
                    sb.Append(sessionLength.Seconds + " second");
                    break;
            }
        }

        textTimeElapsed.text = sb.ToString();
        stats.totalTimePlayed = sb.ToString();
    }
}
