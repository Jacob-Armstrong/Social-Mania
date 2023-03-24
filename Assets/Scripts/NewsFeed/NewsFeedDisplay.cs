using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewsFeedDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject newsTemplate;

    private List<GameObject> newsStoryList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        GameObject newText = Instantiate(newsTemplate) as GameObject;
        newText.SetActive(true);

        newText.GetComponent<NewsObject>().SetText("test these nuts");

        newText.transform.SetParent(newsTemplate.transform.parent, false);

    }

}
