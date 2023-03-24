using System.Collections;
using System.Collections.Generic;
using Proyecto26;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System;
using System.Net.Security;
using TMPro;

public class DataManager : MonoBehaviour
{
    /* ==== References ==== */
    [SerializeField] TimeManager timeManager;
    [SerializeField] Stats stats;
    [SerializeField] Resources resources;
    [SerializeField] Profile profile;
    UserData loadedUser;

    /* ==== Game Objects ==== */
    [SerializeField] TMP_InputField saveInputField;
    [SerializeField] TMP_InputField loadInputField;

/* ==== Local Variables ==== */
    const string ProjectId = "Social-Mania";
    static readonly string DatabaseURL = "https://social-mania-12157807-default-rtdb.firebaseio.com/";
    
    public string userAuth;
    
    // "Sign in with Google" button
    public void onClickGoogleSignIn()
    {
        GoogleAuthHandler.SignInWithGoogle();
        profile.authPopup.SetActive(true);
        profile.returnToGameButton.interactable = false;
        profile.googleSignInButton.interactable = false;
    }

    // "Click here once you have signed in with Google!" to pull authToken from the handler
    public void userAuthenticated()
    {
        userAuth = GoogleAuthHandler.authToken;
        userAuth = userAuth.Substring(0, 10);
        Debug.Log("User Auth: " + userAuth); // remove this once everything works
        if (userAuth == "")
        {
            Debug.Log("Sign in failed -- Please make sure you are signed in properly!");
        }
        else
        {
            load();
        }
        profile.authPopup.SetActive(false);
        profile.returnToGameButton.interactable = true;
        profile.googleSignInButton.interactable = true;
        profile.googleSignInText.text = "";
    }

    // Save user data
    public void save()
    {
        UserData user = new UserData();
        saveData(user);
        uploadToDatabase(user);
        // if userAuth = "", save to playerPrefs for anonymous login?
    }
    
    // Data to be saved (augment UserData class to change)
    void saveData(UserData user)
    {
        user.followers = resources.followers;
        user.lifetimeViews = (int)resources.views;
        user.numClicks = stats.numClicks;
        user.timePlayed = timeManager.timeSinceStartDate.ToString();
        user.startDate = timeManager.startDate.ToString();
    }
    
    // Upload UserData class to database
    void uploadToDatabase(UserData userObj)
    {
        Debug.Log("Starting save...");
        RestClient.Put<UserData>($"{DatabaseURL}users/{userAuth}.json", userObj).Then(response =>
        {
            Debug.Log("The user was successfully uploaded to the database");
        });
    }

    // Load data from database, deconstruct response into saved data
    public void load()
    {
        Debug.Log("Starting load...");
        RestClient.Get<UserData>($"{DatabaseURL}users/{userAuth}.json").Then(response =>
        {
            Debug.Log("Load successful.");
            resources.followers = response.followers;
            resources.views = response.lifetimeViews;
            stats.numClicks = response.numClicks;
            timeManager.timeSinceStartDate = TimeSpan.Parse(response.timePlayed);
            timeManager.startDate = DateTime.Parse(response.startDate);
        });
    }
}
