using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    // References
    [SerializeField] Resources resources;
    [SerializeField] GameObject canvas;
    
    // Game Objects
    [SerializeField] Button maxAttentionUpgrade1;
    
    // Local Variables
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        progressObserver();
    }

    void FixedUpdate()
    {
        
    }

    void progressObserver()
    {
        if (GameObject.Find("attentionUpgrade1") != null)
        {
            maxAttentionUpgrade1.interactable = resources.followers >= 50;
        }
    }
    
    
}
