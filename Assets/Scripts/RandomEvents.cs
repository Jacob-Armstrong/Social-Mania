using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEvents : MonoBehaviour
{
    public Upgrades upgrades;
    void Start()
    {
        StartCoroutine(collabEvent());
    }

    IEnumerator collabEvent()
    {
        while (true)
        {
            eventPopup();
            yield return new WaitForSeconds((int)upgrades.eventTime.TotalSeconds);
        }
    }

    void eventPopup()
    {
        Debug.Log("Event chance: " + upgrades.eventChance);
        int roll = Random.Range(0, 100);
        if (roll < upgrades.eventChance)
        {
            Debug.Log("75% chance success! Value: " + roll + ". Chance floor: " + upgrades.eventChance);
        }
        else
        {
            Debug.Log("Failed. Value: " + roll + ". Chance floor: " + upgrades.eventChance);
        }
    }
}
