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
    }
    
    public void visitProfile() // Profile button clicked
    {
        // Change scenes
        mainScene.SetActive(false);
        profileScene.SetActive(true);
        
        // Update stats
        numClicksValue.text = stats.numClicks.ToString();
        // lifetimeViewsValue.text = stats.lifetimeViews.ToString(); // if updating views in realtime ends up being bad
    }

    public void returnToMain()
    {
        profileScene.SetActive(false);
        mainScene.SetActive(true);
    }
}
