using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class User
{
    /* ==== References ==== */
    [SerializeField] Resources resources;
    [SerializeField] Stats stats;

    /* ==== Game Objects ==== */

    /* ==== Local Variables ==== */

    string username;
    int followers;
    float lifetimeViews;
    int numClicks;
    string timePlayed;

    public User(int followers, float lifetimeViews, int numClicks, string timePlayed)
    {
        this.followers = followers;
        this.lifetimeViews = lifetimeViews;
        this.numClicks = numClicks;
        this.timePlayed = timePlayed;
    }
}
