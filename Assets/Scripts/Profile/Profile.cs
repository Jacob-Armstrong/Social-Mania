using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Profile : MonoBehaviour
{
    // References
    
    // Game Objects
    public TextMeshProUGUI lifetimeViewsText;

    // Local Variables
    //int lifetimeViews;
    
    // Start is called before the first frame update
    void Start()
    {
        lifetimeViewsText.text = Stats.lifetimeViews.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void returnToMain()
    {
        SceneManager.LoadScene("Main");
    }
}
