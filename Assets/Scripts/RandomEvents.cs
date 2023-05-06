using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class RandomEvents : MonoBehaviour
{
    // References
    public Upgrades upgrades;
    public DataManager dataManager;
    public Resources resources;
    
    // Game Objects
    public GameObject randomEventPopup;
    public TextMeshProUGUI infoText;
    public TextMeshProUGUI valuesText;
    public TextMeshProUGUI chanceText;
    public Slider timerSlider;

    public GameObject yesButton;
    public GameObject noButton;
    public GameObject closeButton;

    float maxTime = 15f;
    float timeRemaining;

    double gainValue;
    double lossValue;

    // Local Variables
    
    
    void Start()
    {
        timerSlider.maxValue = maxTime;
        timerSlider.value = maxTime;
        randomEventPopup.SetActive(false);
        
        StartCoroutine(collabEvent());
    }

    void Update()
    {
        if (timerSlider.IsActive())
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                timerSlider.value = timeRemaining;
            }
            else
            {
                declineCollab();
            }
        }
    }

    IEnumerator collabEvent()
    {
        while (true)
        {
            yield return new WaitForSeconds((int)upgrades.eventTime.TotalSeconds);
            eventRoll();
        }
    }

    void eventRoll()
    {
        Debug.Log("Event chance: " + upgrades.eventChance);
        int roll = Random.Range(0, 100);
        if (roll < upgrades.eventChance)
        {
            Debug.Log("Success! Value: " + roll + ". Chance floor: " + upgrades.eventChance);
            eventPopup();
        }
        else
        {
            Debug.Log("Failed. Value: " + roll + ". Chance floor: " + upgrades.eventChance);
        }
    }

    void eventPopup()
    {
        gainValue = resources.followers * upgrades.eventGainMultiplier;
        lossValue = resources.followers * upgrades.eventLossMultiplier;
        string gainDelta = CalcUtils.FormatNumber(gainValue);
        string lossDelta = CalcUtils.FormatNumber(lossValue);

        List<UserData> nonZeroList = new List<UserData>();
        
        foreach (UserData user in dataManager.loadedUserList)
        {
            if (user.lifetimeViews != 0)
            {
                nonZeroList.Add(user);
            }
        }
        
        UserData randomUser = nonZeroList[Random.Range(0, dataManager.loadedUserList.Count)];
        infoText.text = randomUser.username + ", a creator with " + CalcUtils.FormatNumber(randomUser.lifetimeViews) + " views, wants to collab!";
        valuesText.text = "Success: +" + gainDelta + " followers" + "\nFailure: -" + lossDelta + " followers";
        chanceText.text = "Chance of success: " + upgrades.successChance + "%";

        timerSlider.value = maxTime;
        timeRemaining = maxTime;

        yesButton.SetActive(true);
        noButton.SetActive(true);
        closeButton.SetActive(false);
        randomEventPopup.SetActive(true);
    }

    public void acceptCollab()
    {
        int roll = Random.Range(0, 100);

        if (roll < upgrades.successChance)
        {
            infoText.text = "Success!";
            valuesText.text = "Gained " + CalcUtils.FormatNumber(gainValue) + " followers.";
            resources.followers += gainValue;
        }
        else
        {
            infoText.text = "Failure.";
            valuesText.text = "Lost " + CalcUtils.FormatNumber(lossValue) + " followers.";
            Debug.Log("Followers before loss: " + resources.followers);
            Debug.Log("Loss value: " + lossValue);
            resources.followers -= lossValue;
            Debug.Log("Followers after loss: " + resources.followers);
        }

        chanceText.text = "";
        
        yesButton.SetActive(false);
        noButton.SetActive(false);
        closeButton.SetActive(true);
    }

    public void declineCollab()
    {
        randomEventPopup.SetActive(false);
    }
}
