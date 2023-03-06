using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Buttons : MonoBehaviour
{
    // References
    public Resources resources;
    [SerializeField] Stats stats;
    
    // Game Objects
    public Button mainButton;
    public Button button10;
    public Button changeSceneTest;
    
    // Local Variables
    
    
    
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
        resources.attention += .01f;
    }

    public void numberGoUp10()
    {
        resources.followers += 10;
        resources.attention += 10;
        StartCoroutine(buttonCooldown(button10, 2f));
    }

    static IEnumerator buttonCooldown(Button button, float cooldown)
    {
        button.interactable = false;
        yield return new WaitForSeconds(cooldown);
        button.interactable = true;
    }

    public void changeSceneProfile()
    {
        Stats.lifetimeViews = (int)resources.views;
        SceneManager.LoadScene("Profile");
    }
}
