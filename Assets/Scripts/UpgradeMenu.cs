using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    [SerializeField] GameObject content;
    [SerializeField] UpgradeButton buttonTemplate;

    List<UpgradeButton> buttons = new();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnUpgrade(Upgrade upgrade)
    {
        UpgradeButton b = Instantiate(buttonTemplate, content.transform);
        b.Initialize(upgrade);

        buttons.Add(b);
    }
}
