using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TestScript : MonoBehaviour
{
    float number = 0f;
    float multiplier = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Test");
    }

    

    // Update is called once per frame
    void Update()
    {
        multiplier += 0.001f;
    }

    int roundedNumber = 0;

    void FixedUpdate()
    {
        number += (1 * multiplier);
        roundedNumber = (int)Math.Round(number) / 50;
        Debug.Log("Views: " + roundedNumber);
        Debug.Log("Multiplier: " + multiplier + "x");
    }

    void LateUpdate()
    {
        
    }
}
