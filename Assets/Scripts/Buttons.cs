using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;


public class Buttons : MonoBehaviour
{

    public resources resources;

    public Button mainButton;
    public Button button10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void numberGoUp()
    {
        resources.followers += 1;
        resources.attention += 1;
    }

    public void numberGoUp10()
    {
        resources.followers += 10;
        resources.attention += 10;
        StartCoroutine(buttonCooldown(button10, 2f));
    }

    IEnumerator buttonCooldown(Button button, float cooldown)
    {
        button.interactable = false;
        yield return new WaitForSeconds(cooldown);
        button.interactable = true;
    }
}
