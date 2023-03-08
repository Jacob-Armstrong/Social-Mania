using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using TMPro;

public class TimeManager : MonoBehaviour
{
    /* ==== References ==== */

    /* ==== Game Objects ==== */
    public TextMeshProUGUI textTimeElapsed;

    /* ==== Local Variables ==== */
    DateTime startTime;
    DateTime currentTime;
    TimeSpan sessionLength; // += this to totalTimePlayed in stats when game is saved pls (or something idk how timeSpan works)

    // Start is called before the first frame update
    void Start()
    {
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
    }
}
