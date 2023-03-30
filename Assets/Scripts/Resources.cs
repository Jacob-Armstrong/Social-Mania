using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Text;
using UnityEngine.UI;

public class Resources : MonoBehaviour
{
    /* ==== References ==== */
    [SerializeField] Upgrades upgrades;
    [SerializeField] Stats stats;
    
    /* ==== Game Objects ==== */
    public TextMeshProUGUI textViewsCount;
    public TextMeshProUGUI textAttentionCount;
    public TextMeshProUGUI textFollowersCount;
    public Slider slider;

    /* ==== Local Variables ==== */
    int tickProgress;
    [SerializeField] float viewGain;
    
    // Major Resource Variables
    public float views;
    public int followers;
    public int haters;
    public float attention;

    // Attention Variables
    [SerializeField] float attLossBase;       // Default attention loss per tick
    [SerializeField] float attLossDelay = 5f; // Idle time in seconds before attention starts to drop off
    public float attLossMultiplier = 1f;      // Attention loss multiplier from upgrades/random events
    public float attFloor = 0;
    private float attLossTimer;               // Timer variable that gets set equal to attLossDelay
    
    //________________________
    // FUNCTIONS
    
    void Awake()
    {
        // Initialize starting values of resource variables
        views = 0;
        followers = 0;
        haters = 0;
        attention = 1.0f;
        attLossTimer = attLossDelay;
    }

    void Update()
    {
        AttentionCap();
    }

    void FixedUpdate()
    {
        // Tick counts 1-10 and then resets
        // Currently 5 ticks per second
        if (tickProgress >= 10)
        {
            tickProgress = 0;
            Tick();
        }
        tickProgress++;

        if (attLossTimer > 0)
        {
            attLossTimer -= Time.deltaTime;
        }
    }
    
    // ________________________________
    // IMPORTANT FUNCTION
    // Tick runs several times per second
    // and handles passive resource generation/loss
    void Tick()
    {
        ViewGains();
        UpdateDisplay();
        UpdateStats();

        if(attLossTimer <= 0)
            AttentionDecay();
    }

    void AttentionCap()
    {
        if (attention > upgrades.maxAttention)
        {
            attention = (float)upgrades.maxAttention;
        }
    }
    
    void ViewGains()
    {
        viewGain = (followers/10.0f) * (float)attention;
        views += viewGain;
    }

    void UpdateDisplay()    // Refreshes on-screen numbers (views, attention...)
    {
        textViewsCount.text = ((int)views).ToString();
        textAttentionCount.text = attention.ToString("0.00") + "x";
        textFollowersCount.text = followers.ToString();
        slider.value = attention;
    }

    void UpdateStats()
    {
        stats.lifetimeViews = (int)views;
    }

    void AttentionDecay()
    {
        attention -= attLossBase * attLossMultiplier;

        if (attention < attFloor)
            attention = attFloor;
    }

    public void AddFollowersAndAttention(int followerChange, float attChange)
    {
        followers += followerChange;
        attention += attChange;
        attLossTimer = attLossDelay;
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
