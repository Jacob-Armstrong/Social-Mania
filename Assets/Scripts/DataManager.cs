using System.Collections;
using System.Collections.Generic;
using Proyecto26;
using UnityEngine;
using UnityEditor;
using System;

public class DataManager : MonoBehaviour
{
    /* ==== References ==== */
    [SerializeField] TimeManager timeManager;
    [SerializeField] Stats stats;
    [SerializeField] Resources resources;
    [SerializeField] User user;

    /* ==== Game Objects ==== */

    /* ==== Local Variables ==== */
    const string projectId = "Social-Mania";
    static readonly string DatabaseURL = $"https://social-mania.firebaseio.com/";
    
    void updateData()
    {
        user.followers = resources.followers;
        user.lifetimeViews = (int)resources.views;
        user.numClicks = stats.numClicks;
        user.timePlayed = stats.totalTimePlayed;
    }

    public void postButtonPushed()
    {
        updateData();
        postUser(user, "Bob Jones");
    }

    void postUser(User userObj, string userId)
    {
        RestClient.Put<User>($"{DatabaseURL}users/{userId}.json", userObj).Then(response =>
        {
            Debug.Log("The user was successfully uploaded to the database");
        });
    }

    public void signInUser()
    {
        
    }
}
