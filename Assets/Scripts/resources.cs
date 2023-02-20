using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
}
