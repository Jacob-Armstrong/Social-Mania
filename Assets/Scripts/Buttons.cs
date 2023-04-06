using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Buttons : MonoBehaviour
{
    /* ==== References ==== */
    public Resources resources;

    /* ==== Game Objects ==== */
    public Button mainButton;

    /* ==== Local Variables ==== */

    public void numberGoUp()
    {
        resources.AddFollowersAndAttention(1, .01f);
    }

    // Reusable Coroutine to put a cooldown with a length <cooldown> seconds on any Unity UI Button
    static IEnumerator buttonCooldown(Button button, float cooldown)
    {
        button.interactable = false;
        yield return new WaitForSeconds(cooldown);
        button.interactable = true;
    }
    
    
}
