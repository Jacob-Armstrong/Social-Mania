using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class User
{
    /* ==== References ==== */

    /* ==== Game Objects ==== */

    /* ==== Local Variables ==== */

    string username;
    public int followers;
    public int lifetimeViews;
    public int numClicks;
    public string timePlayed;
    public string startDate;

    /*
    public User()
    {
        followers = 0;
        lifetimeViews = 0;
        numClicks = 0;
        timePlayed = "";
    }
    */
}
