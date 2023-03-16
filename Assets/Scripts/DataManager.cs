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

    /* ==== Game Objects ==== */

    /* ==== Local Variables ==== */
    const string projectId = "Social-Mania";
    static readonly string DatabaseURL = $"https://social-mania.firebaseio.com/";

    public void postButtonPushed()
    {
        User user = new User(resources.followers, resources.views, stats.numClicks, stats.totalTimePlayed);
        postUser(user, "12345");
    }

    public static void postUser(User user, string userId)
    {
        RestClient.Put<User>($"{DatabaseURL}users/{userId}.json", user).Then(response =>
        {
            Debug.Log("The user was successfully uploaded to the database");
        });
    }

    public void signInUser()
    {
        
    }
}
