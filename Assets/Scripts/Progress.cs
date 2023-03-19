using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    /* ==== References ==== */
    [SerializeField] Resources resources;

    /* ==== Game Objects ==== */
    [SerializeField] Button maxAttentionUpgrade1;
    
    /* ==== Local Variables ==== */

    // Update is called once per frame
    void Update()
    {
        progressObserver();
    }

    // this is ugly and bad please don't track progress this way
    // first rule of GameObject.Find() -> don't use GameObject.Find()
    void progressObserver()
    {
        if (GameObject.Find("attentionUpgrade1") != null)
        {
            maxAttentionUpgrade1.interactable = resources.followers >= 50;
        }
    }
    
    
}
