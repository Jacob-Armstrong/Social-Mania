using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Profile : MonoBehaviour
{
    /* ==== References ==== */
    [SerializeField] TimeManager timeManager;
    [SerializeField] Stats stats;
    [SerializeField] Resources resources;
    [SerializeField] Upgrades upgrades;
    [SerializeField] DataManager dataManager;
    
    /* ==== Game Objects ==== */
    /* -- Scenes -- */
    public GameObject mainScene;
    public GameObject profileScene;
    
    /* -- Popups -- */
    public GameObject authPopup;
    public GameObject userTakenPopup;
    public GameObject userLengthPopup;
    public GameObject offlinePopup;
    public GameObject newUsernamePopup;
    
    /* -- Buttons -- */
    public Button googleSignInButton;
    public Button returnToGameButton;
    public Button submitUsernameButton;
    public Button updateLeaderboardButton;
    public Button hardResetButton;
    
    /* -- Text -- */
    public TextMeshProUGUI googleSignInText;
    public TextMeshProUGUI lifetimeViewsValue;
    public TextMeshProUGUI numClicksValue;
    public TextMeshProUGUI[] leaderboardPositions;
    
    /* -- Misc -- */
    public TMP_InputField usernameInput;
    public TMP_InputField newUsernameInput;

    public GameObject userInputObj;
    public GameObject userInputButtonObj;
    
    
    /* ==== Local Variables ==== */

    public string username = "";

    void Awake() // should move this to a scene handler or something, this is a band-aid for me not wanting to deactivate scenes all the time
    {
        authPopup.SetActive(false);
        returnToMain();
    }

    void start()
    {
        userInputObj.SetActive(false);
        userInputButtonObj.SetActive(false);
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

    public void disableButtons()
    {
        returnToGameButton.interactable = false;
        googleSignInButton.interactable = false;
        submitUsernameButton.interactable = false;
        updateLeaderboardButton.interactable = false;
        hardResetButton.interactable = false;
    }

    public void enableButtons()
    {
        returnToGameButton.interactable = true;
        googleSignInButton.interactable = true;
        submitUsernameButton.interactable = true;
        updateLeaderboardButton.interactable = true;
        hardResetButton.interactable = true;
    }

    public void setUsername(string buttonValue)
    {

        string userInput = "";

        switch (buttonValue)
        {
            case "username":
                userInput = usernameInput.text;
                break;
            case "newuser":
                userInput = newUsernameInput.text;
                break;
            default:
                Debug.Log("Set username failed");
                break;
        }

        bool usernameValid = true;

        if (!dataManager.checkUsernameTaken(userInput))
        {
            Debug.Log("This username is already taken!");
            usernameValid = false;
            userTakenPopup.SetActive(true);
            disableButtons();
        }

        if (userInput.Length > 16 || userInput.Length < 1)
        {
            Debug.Log("That username must be between 1 and 16 characters");
            usernameValid = false;
            userLengthPopup.SetActive(true);
            disableButtons();
        }

        if (usernameValid)
        {
            username = userInput;

            if (buttonValue == "newuser")
            {
                closeNewUsernamePopup();
            }
        }
    }

    public void closeTakenPopup()
    {
        userTakenPopup.SetActive(false);
        if (username != "")
        {
            enableButtons();
        }
    }

    public void closeLengthPopup()
    {
        userLengthPopup.SetActive(false);
        if (username != "")
        {
            enableButtons();
        }
    }

    public void closeOfflinePopup()
    {
        offlinePopup.SetActive(false);
        enableButtons();
    }

    public void closeNewUsernamePopup()
    {
        newUsernamePopup.SetActive(false);
        enableButtons();
    }

    public void hardReset()
    {
        resources.views = 0;
        resources.followers = 0;
        resources.attention = 1.00f;
        stats.lifetimeViews = 0;
        stats.numClicks = 0;
        upgrades.RemoveUpgrades();
        stats.totalNumUpgrades = 0;
        timeManager.startDate = DateTime.Now;
    }
}
