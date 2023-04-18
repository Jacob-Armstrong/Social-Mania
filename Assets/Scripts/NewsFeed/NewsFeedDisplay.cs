using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewsFeedDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject newsTemplate;

    //[SerializeField]
    //private TextAsset textFile;


    //private List<GameObject> newsStoryList = new List<GameObject>();
    public List<NewsStory> newsStoryList = new List<NewsStory>();

    private float repeatDelay = 10.0f;

    public GameObject resourceObject;
    

    // Start is called before the first frame update
    void Start()
    {
        string objName;
        string content;
        double minViews;
        int minFollowers;
        int minAttention;

        content = "This story requires no views";
        minViews = 0.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s1 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s1);

        content = "Minimum views 100";
        minViews = 100.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s2 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s2);

        content = "Minimum views 1000";
        minViews = 1000.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s3 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s3);

        InvokeRepeating("DisplayNews", 1.0f, repeatDelay);

        // Read file to determine how many news stories to make
        //string text = textFile.text;
        //string[] textArr = text.Split('~');

        // Reference text array to display news stories
        // Requirements to unlock are on odd numbers
        // News story content is on the following even number


        // Create news story objects
        /*
        for (int i = 1; i < textArr.Length; i+=2)
        {
            GameObject newText = Instantiate(newsTemplate) as GameObject;
            newText.SetActive(false);
            textArr[i+1] = textArr[i+1].Replace("[NAME]", "[SOMETHING_ELSE]");
            newText.GetComponent<NewsObject>().SetRequirement(int.Parse(textArr[i]));
            newText.GetComponent<NewsObject>().SetText(textArr[i+1]);

            newText.transform.SetParent(newsTemplate.transform.parent, false);

            newsStoryList.Add(newText);
        }
        */

        // TO REFERENCE NEWS STORIES
        // Reference a story:       newsStoryList[i]
        // Unlock requirements:     newsStoryList[i].GetComponent<NewsObject>().GetRequirement()
        // Display it with:         newsStoryList[i].SetActive(true)
    }


    // *****************
    // WORK IN PROGRESS

    // Display news objects section:
    void DisplayNews()
    {
        // Create the object that will display the news story
        GameObject newText = Instantiate(newsTemplate) as GameObject;
        newText.SetActive(true);
        newText.transform.SetParent(newsTemplate.transform.parent, false);

        // Select a random news story (includes checking requirements)
        int storyID = SelectRandomNews();

        // Set the text of the news story
        newText.GetComponent<NewsObject>().SetText(newsStoryList[storyID].content);

        Debug.Log("Current views is actually: " + resourceObject.GetComponent<Resources>().views);

        // Delete object after a delay of several seconds
        Destroy(newText, repeatDelay);
    }

    int SelectRandomNews()
    {
        // ****************
        // WORK IN PROGRESS
        // ****************

        // Select a random news story
        int randomID = Random.Range(1, newsStoryList.Count + 1) - 1;
        Debug.Log("Selected number: " + randomID);
        //Debug.Log(newsStoryList[randomID].content);

        if (NewsRequirementsMet(newsStoryList[randomID]) == true) {
            return randomID;
        }

        else {
            return SelectRandomNews();
        }
        

    }

    // next, determine if displaying is valid
    bool NewsRequirementsMet(NewsStory thisStory)
    {
        //int tempViews = 100;
        //Debug.Log("tempViews is: " + tempViews);
        //Debug.Log("thisStory minViews is: " + thisStory.minViews);

        double views = resourceObject.GetComponent<Resources>().views;

        if (views >= thisStory.minViews)
        {
            //Debug.Log("It was true!!!");
            return true;
        }

        else
        {            
            //Debug.Log("It was false");
            return false;
        }
    }

    // else, choose another story
    // and display the story

    public class NewsStory
    {
        public string content;
        public double minViews;
        public int minFollowers;
        public int minAttention;

        public NewsStory(string c, double v, int f, int a)
        {
                content = c;
                minViews = v;
                minFollowers = f;
                minAttention = a;
        }
    }

}