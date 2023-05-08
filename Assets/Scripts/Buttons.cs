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
    public Upgrades upgrades;
    public AudioSource clickSFX;

    /* ==== Game Objects ==== */
    public Button mainButton;

    /* ==== Local Variables ==== */

    public void numberGoUp()
    {
        resources.AddFollowersAndAttention(1 * upgrades.clickMultiplier, 0.1f);
    }

    // Reusable Coroutine to put a cooldown with a length <cooldown> seconds on any Unity UI Button
    static IEnumerator buttonCooldown(Button button, float cooldown)
    {
        button.interactable = false;
        yield return new WaitForSeconds(cooldown);
        button.interactable = true;
    }
    
    public void playClickSFX()
    {
        clickSFX.Play();
    }
}
