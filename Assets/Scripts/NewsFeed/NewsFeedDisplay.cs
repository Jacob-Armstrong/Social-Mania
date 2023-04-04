using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewsFeedDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject newsTemplate;

    [SerializeField]
    private TextAsset textFile;


    private List<GameObject> newsStoryList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // Read file to determine how many news stories to make
        string text = textFile.text;
        string[] textArr = text.Split('~');

        // Reference text array to display news stories
        // Requirements to unlock are on odd numbers
        // News story content is on the following even number


        // Create news story objects
        for (int i = 1; i < textArr.Length; i+=2)
        {
            GameObject newText = Instantiate(newsTemplate) as GameObject;
            newText.SetActive(false);

            newText.GetComponent<NewsObject>().SetRequirement(int.Parse(textArr[i]));
            newText.GetComponent<NewsObject>().SetText(textArr[i+1]);

            newText.transform.SetParent(newsTemplate.transform.parent, false);

            newsStoryList.Add(newText);
        }

        // TO REFERENCE NEWS STORIES
        // Reference a story:       newsStoryList[i]
        // Unlock requirements:     newsStoryList[i].GetComponent<NewsObject>().GetRequirement()
        // Display it with:         newsStoryList[i].SetActive(true)
    }


    // *****************
    // WORK IN PROGRESS

    // Display news objects section:
    // first, select random news story
    void DisplayNews()
    {

    }

    void SelectRandomNews()
    {

    }

    // next, determine if displaying is valid
    bool CheckNewsRequirements()
    {

        return false;
    }

    // else, choose another story
    // and display the story



}