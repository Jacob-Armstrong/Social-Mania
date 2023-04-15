using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class UserData
{
    /* ==== References ==== */

    /* ==== Game Objects ==== */

    /* ==== Local Variables ==== */
    public string username;
    public double followers;
    public double lifetimeViews;
    public int numClicks;
    public string startDate;
    public string lastSeen;
    public List<string> upgradesPurchased;
}
