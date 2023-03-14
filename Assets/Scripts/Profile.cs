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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void visitProfile() // Profile button clicked
    {
        // Change scenes
        mainScene.SetActive(false);
        profileScene.SetActive(true);
        
        // Update stats
        numClicksValue.text = stats.numClicks.ToString();
        lifetimeViewsValue.text = stats.lifetimeViews.ToString(); // potentially change updateStats() in Resources to reflect this change in real time?
    }

    public void returnToMain()
    {
        profileScene.SetActive(false);
        mainScene.SetActive(true);
    }
}
