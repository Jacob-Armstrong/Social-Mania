using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickDetector : MonoBehaviour
{
    /* ==== References ==== */
    [SerializeField] Stats stats;

    /* ==== Game Objects ==== */
    [SerializeField] Button mainButton;

/* ==== Local Variables ==== */
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        mainButton.onClick.AddListener(buttonClicked);
    }

    void buttonClicked()
    {
        stats.numClicks += 1;
    }
}
