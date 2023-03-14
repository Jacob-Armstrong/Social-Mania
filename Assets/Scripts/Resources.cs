using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Text;

public class Resources : MonoBehaviour
{
    /* ==== References ==== */
    [SerializeField] Upgrades upgrades;
    [SerializeField] Stats stats;
    
    /* ==== Game Objects ==== */
    public TextMeshProUGUI textViewsCount;
    public TextMeshProUGUI textAttentionCount;
    public TextMeshProUGUI textFollowersCount;
    
    /* ==== Local Variables ==== */
    int tickProgress;
    [SerializeField] float viewGain;
    
    // Major Resource Variables
    public float views;
    public int followers;
    public int haters;
    public double attention;
    
    //________________________
    // FUNCTIONS
    
    void Start()
    {
        // Initialize starting values of resource variables
        views = 0;
        followers = 0;
        haters = 0;
        attention = 1.0d;
    }

    void Update()
    {
        attentionCap();
    }

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
        viewGains();
        updateDisplay();
        updateStats();
    }

    void attentionCap()
    {
        if (attention > upgrades.maxAttention)
        {
            attention = (float)upgrades.maxAttention;
        }
    }
    
    void viewGains()
    {
        viewGain = (followers/10.0f) * (float)attention;
        views += viewGain;
    }

    void updateDisplay()    // Refreshes on-screen numbers (views, attention...)
    {
        textViewsCount.text = ((int)views).ToString();
        textAttentionCount.text = attention.ToString("0.00") + "x";
        textFollowersCount.text = followers.ToString();
    }

    void updateStats()
    {
        stats.lifetimeViews = (int)views;
    }
    
    // temporarily deprecated attention code
    
    /*
    // Attention-specific modifiers
    float attDecayBase;     // Base amount of decay lost per tick
    float attDecayAmt;      // Modifier to decay loss, increase/decrease based on progression
    float attLoss;          // Attention lost this tick
*/

    /*
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
    }
    /*


    /*
    void generateViews(float loss)    // Converts decayed attention into views
    {
        if (loss < 1)
            loss = 1;

        views += (int)loss;
        //Debug.Log("Views: " + views);
    }
    */
    
}
