using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Text;

public class resources : MonoBehaviour
{
    // Major resource variables
    public int views;
    public int followers;
    public int haters;
    public float attention;

    // Attention-specific modifiers
    float attDecayBase;     // Base amount of decay lost per tick
    float attDecayAmt;      // Modifier to decay loss, increase/decrease based on progression
    float attLoss;          // Attention lost this tick

    // Time variables
    int tickProgress;       // Counter increases until next tick occurs, then resets

    // External Objects
    public TextMeshProUGUI textViewsCount;      // Controls on-screen display number
    public TextMeshProUGUI textAttentionCount;
    public TextMeshProUGUI textFollowersCount;
    public TextMeshProUGUI textTimeElapsed;

    //timeElapsed prototype
    DateTime startTime;
    DateTime currentTime;
    DateTime sessionLength;


    //________________________
    // FUNCTIONS

    void Start()
    {
        // Initialize starting values of resource variables
        views = 0;
        followers = 0;
        haters = 0;
        attention = 50;
        attDecayAmt = 0.5f;     // This one changes based on upgrades
        attDecayBase = 1.0f;
        attLoss = 0.0f;
        tickProgress = 0;

        startTime = DateTime.Now; // Time session begins
    }

    void Update(){}

    void FixedUpdate()
    {
        // Tick counts 1-10 and then resets
        // Currently 5 ticks per second
        if (tickProgress >= 10)
        {
            tickProgress = 0;
            tick();
        }
        tickProgress++;
    }


    // ________________________________
    // IMPORTANT FUNCTION
    // Tick runs several times per second
    // and handles passive resource generation/loss
    void tick()
    {
        attentionDecay(attDecayAmt);

        if (attLoss > 0)
            generateViews(attLoss);

        timeElapsed();

        updateDisplay();

    }


    void attentionDecay(float decayAmt)    // Handles passive decrease of decay
    {
        attLoss = 0;

        // Check attention is above zero
        if (attention <= 0)
        {
            attention = 0;
            return;
        }

        // Decrease attention based on decay
        attLoss = attDecayBase * decayAmt;
        attention -= attLoss;

        //Debug.Log("Attention: " + attention);
    }


    void generateViews(float loss)    // Converts decayed attention into views
    {
        if (loss < 1)
            loss = 1;

        views += (int)loss;
        //Debug.Log("Views: " + views);
    }

    void updateDisplay()    // Refreshes on-screen numbers (views, attention...)
    {
        textViewsCount.text = views.ToString();
        textAttentionCount.text = "\n" + ((int)attention).ToString();
        textFollowersCount.text = "\n\n" + followers.ToString();
    }

    void timeElapsed()
    {
        currentTime = DateTime.Now;

        TimeSpan sessionLength = currentTime - startTime;

        StringBuilder sb = new StringBuilder("", 50);

        sb.Insert(0, "Time elapsed: ");

        if (sessionLength.Hours > 1)
        {
            sb.Insert(14, sessionLength.Hours + " hours");
        }
        else if (sessionLength.Hours == 1)
        {
            sb.Insert(14, sessionLength.Hours + " hour");
        }

        if (sessionLength.Hours > 0)
        {
            if (sessionLength.Minutes > 1)
            {
                sb.Append(", " + sessionLength.Minutes + " minutes");
            }
            else if (sessionLength.Minutes == 1)
            {
                sb.Append(", " + sessionLength.Minutes + " minute");
            }
        }
        else if (sessionLength.Hours == 0)
        {
            if (sessionLength.Minutes > 1)
            {
                sb.Append(sessionLength.Minutes + " minutes");
            }
            else if (sessionLength.Minutes == 1)
            {
                sb.Append(sessionLength.Minutes + " minute");
            }
        }

        if (sessionLength.Hours > 0 || sessionLength.Minutes > 0)
        {
            if (sessionLength.Seconds > 1)
            {
                sb.Append(", " + sessionLength.Seconds + " seconds");
            }
            else if (sessionLength.Seconds == 1)
            {
                sb.Append(", " + sessionLength.Seconds + " second");
            }
        }
        else if (sessionLength.Hours == 0 || sessionLength.Minutes == 0)
        {
            if (sessionLength.Seconds > 1)
            {
                sb.Append(sessionLength.Seconds + " seconds");
            }
            else if (sessionLength.Seconds == 1)
            {
                sb.Append(sessionLength.Seconds + " second");
            }
        }

        textTimeElapsed.text = sb.ToString();

        /*
        if (sessionLength.Hours > 1 && sessionLength.Minutes == 0 && sessionLength.Seconds == 0)
        {
            sb.Insert(14, sessionLength.Hours + " hour");
        }
        else if (sessionLength.Hours > 1 && sessionLength.Minutes != 0 || sessionLength.Seconds != 0)
        {
            sb.Insert(14, sessionLength.Hours + " hours, ");
        }
        else if (sessionLength.Hours == 1 && sessionLength.Minutes == 0 && sessionLength.Seconds == 0)
        {
            sb.Insert(14, sessionLength.Hours + " hour");
        }
        else if (sessionLength.Hours == 1 && sessionLength.Minutes != 0 || sessionLength.Seconds != 0)
        {
            sb.Insert(14, sessionLength.Hours + " hour, ");
        }

        if (sessionLength.Minutes > 1 && sessionLength.Seconds == 0) 
        {
            sb.Append(sessionLength.Minutes + " minutes");
        }
        else if (sessionLength.Minutes > 1 && sessionLength.Seconds != 0) 
        {
            sb.Append(sessionLength.Minutes + " minutes, ");
        }
        else if (sessionLength.Minutes == 1)
        {
            sb.Append(sessionLength.Minutes + " minute ");
        }

        if (sessionLength.Seconds > 1)
        {
            sb.Append(sessionLength.Seconds + " seconds");
        }
        else if (sessionLength.Seconds == 1)
        {
            sb.Append(sessionLength.Seconds + " second");
        }
        */

        /*
        if (sessionLength.Hours >= 1)
        {
            textTimeElapsed.text = "Time elapsed: " + sessionLength.Hours + " hours, " + sessionLength.Minutes + " minutes, " + sessionLength.Seconds + " seconds".ToString();
        } else
        if (sessionLength.Hours < 1 && sessionLength.Minutes >= 1)
        {
            textTimeElapsed.text = "Time elapsed: " + sessionLength.Minutes + " minutes, " + sessionLength.Seconds + " seconds".ToString();
        }
        else
        if (sessionLength.Hours < 1 && sessionLength.Minutes < 1)
        {
            textTimeElapsed.text = "Time elapsed: " + sessionLength.Seconds + " seconds".ToString();
        }
        */
    }
}
