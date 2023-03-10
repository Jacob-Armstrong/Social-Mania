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
    [SerializeField]
    TimeManager timeManager;
    [SerializeField]
    Stats stats;
    
    /* ==== Game Objects ==== */
    public TextMeshProUGUI lifetimeViewsText;
    public GameObject mainScene;
    public GameObject profileScene;

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

    public void visitProfile()
    {
        mainScene.SetActive(false);
        profileScene.SetActive(true);
    }

    public void returnToMain()
    {
        profileScene.SetActive(false);
        mainScene.SetActive(true);
    }
}
