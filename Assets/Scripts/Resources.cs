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
    [SerializeField] double viewGain;
    
    // Major Resource Variables
    public double views;
    public double followers;
    public float attention;

    // Attention Variables
    [SerializeField] float attLossBase;       // Default attention loss per tick
    private float attLossTimer;               // Timer variable that gets set equal to attLossDelay
    
    //________________________
    // FUNCTIONS
    
    void Awake()
    {
        // Initialize starting values of resource variables
        views = 0;
        followers = 0;
        attention = 1.0f;
        attLossTimer = upgrades.attLossDelay;
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
        viewGain = (followers/10.0d) * (double)attention;
        views += viewGain;
    }

    void UpdateDisplay()    // Refreshes on-screen numbers (views, attention...)
    {
        textViewsCount.text = CalcUtils.FormatNumber(views);
        textAttentionCount.text = attention.ToString("0.00") + "x";
        textFollowersCount.text = CalcUtils.FormatNumber(followers);
        slider.value = attention;
    }

    void UpdateStats()
    {
        stats.lifetimeViews = (int)views;
    }

    void AttentionDecay()
    {
        if(attention > upgrades.attFloor)
            attention -= attLossBase * upgrades.attLossMultiplier;
    }

    public void AddFollowersAndAttention(double followerChange, float attChange)
    {
        followers += followerChange;
        attention += attChange;
        attLossTimer = upgrades.attLossDelay;
    }

}
