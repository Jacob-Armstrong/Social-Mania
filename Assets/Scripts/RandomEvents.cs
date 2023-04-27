using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEvents : MonoBehaviour
{

    int chance = 75;

    public Upgrades upgrades;
    void Start()
    {
        //StartCoroutine(collabEvent());
    }

    IEnumerator collabEvent()
    {
        while (true)
        {
            eventPopup();
            yield return new WaitForSeconds(1);
        }
    }

    void eventPopup()
    {
        int roll = Random.Range(0, 100);
        if (roll < chance)
        {
            Debug.Log("75% chance success! Value: " + roll + ". Chance floor: " + chance);
        }
        else
        {
            Debug.Log("Failed. Value: " + roll + ". Chance floor: " + chance);
        }
    }
}
