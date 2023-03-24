using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    /* ==== References ==== */
    [SerializeField] Resources resources;
    [SerializeField] Button attentionUpgrade1;
    
    /* ==== Game Objects ==== */
    
    /* ==== Local Variables ==== */
    public double maxAttention;
    public double clickMultiplier;
    
    // Start is called before the first frame update
    void Start()
    {
        maxAttention = 2.0d;
        clickMultiplier = 1.0d;
    }

    public void maxAttentionUpgrade1()
    {
        maxAttention = 2.5d;
        resources.followers -= 50;
        Destroy(attentionUpgrade1.gameObject);
    }

    public void clickMultiplierUpgrade1()
    {
        clickMultiplier = 1.5d;
    }
}

