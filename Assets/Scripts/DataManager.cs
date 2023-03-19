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
    UserData loadedUser;

    /* ==== Game Objects ==== */
    [SerializeField] TMP_InputField saveInputField;
    [SerializeField] TMP_InputField loadInputField;

/* ==== Local Variables ==== */
    const string ProjectId = "Social-Mania";
    static readonly string DatabaseURL = $"https://social-mania.firebaseio.com/";
    
    string userAuth;

    void saveData(UserData user)
    {
        user.followers = resources.followers;
        user.lifetimeViews = (int)resources.views;
        user.numClicks = stats.numClicks;
        user.timePlayed = timeManager.sessionLength.ToString();
        user.startDate = timeManager.startDate.ToString();
    }

    public void postButtonPushed()
    {
        UserData user = new UserData();
        saveData(user);
        userAuth = saveInputField.text;
        postUser(user);
    }

    void postUser(UserData userObj)
    {
        Debug.Log("Starting save...");
        RestClient.Put<UserData>($"{DatabaseURL}users/{userAuth}.json", userObj).Then(response =>
        {
            Debug.Log("The user was successfully uploaded to the database");
        });
    }

    public void loadButtonPushed()
    {
        userAuth = loadInputField.text;
        getUser();
    }

    void getUser()
    {
        Debug.Log("Starting load...");
        RestClient.Get<UserData>($"{DatabaseURL}users/{userAuth}.json").Then(response =>
        {
            Debug.Log("Load successful.");
            resources.followers = response.followers;
            resources.views = response.lifetimeViews;
            stats.numClicks = response.numClicks;
            timeManager.sessionLength = TimeSpan.Parse(response.timePlayed);
            timeManager.startDate = DateTime.Parse(response.startDate);
        });
    }
    
    
    
}
