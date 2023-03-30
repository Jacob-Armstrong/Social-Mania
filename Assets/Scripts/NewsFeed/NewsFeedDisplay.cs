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
        // Read file to determine how many news stories to make


        // Instantiate news story objects
        for (int i = 0; i < 5; i++)
        {
            // Should make this a custom object type
            GameObject newText = Instantiate(newsTemplate) as GameObject;
            newsStoryList.Add(newText);

            newText.SetActive(true);

            newText.GetComponent<NewsObject>().SetText("this is number: " + i);

            newText.transform.SetParent(newsTemplate.transform.parent, false);
        }


    }

}


public class NewsContents
{
    private string description;

}