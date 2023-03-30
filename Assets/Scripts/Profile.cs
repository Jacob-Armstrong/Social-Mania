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
    [SerializeField] DataManager dataManager;
    
    /* ==== Game Objects ==== */
    public GameObject mainScene;
    public GameObject profileScene;
    public GameObject authPopup;
    public Button googleSignInButton;
    public Button returnToGameButton;
    public TextMeshProUGUI googleSignInText;
    public TMP_InputField usernameInput;

    public TextMeshProUGUI lifetimeViewsValue;
    public TextMeshProUGUI numClicksValue;

    /* ==== Local Variables ==== */

    public string username;

    void Awake() // should move this to a scene handler or something, this is a band-aid for me not wanting to deactivate scenes all the time
    {
        authPopup.SetActive(false);
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

    public void setUsername()
    {
        string userInput = usernameInput.text;
        if (dataManager.checkValidUsername(userInput))
        {
            username = userInput;
        }
        else
        {
            Debug.Log("This username is already taken!");
        }
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
