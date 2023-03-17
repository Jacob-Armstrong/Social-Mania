using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Profile : MonoBehaviour
{
    /* ==== References ==== */
    [SerializeField] TimeManager timeManager;
    [SerializeField] Stats stats;
    [SerializeField] Resources resources;
    
    /* ==== Game Objects ==== */
    public GameObject mainScene;
    public GameObject profileScene;
    
    public TextMeshProUGUI lifetimeViewsValue;
    public TextMeshProUGUI numClicksValue;

    /* ==== Local Variables ==== */
    float lifetimeViews;
    
    TimeSpan totalTimePlayed;

    void Awake()
    {
        returnToMain();
    }
    
    void FixedUpdate()
    {
        lifetimeViewsValue.text = stats.lifetimeViews.ToString();
        numClicksValue.text = stats.numClicks.ToString();
    }
    
    public void visitProfile() // Profile button clicked
    {
        // Change scenes
        mainScene.SetActive(false);
        profileScene.SetActive(true);
    }

    public void returnToMain()
    {
        profileScene.SetActive(false);
        mainScene.SetActive(true);
    }

    public void hardReset()
    {
        resources.views = 0;
        resources.followers = 0;
        resources.attention = 1.00f;
        stats.lifetimeViews = 0;
        stats.numClicks = 0;
        stats.totalNumUpgrades = 0;
        timeManager.startDate = DateTime.Now;
    }
}
