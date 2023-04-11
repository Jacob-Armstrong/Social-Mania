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

    private string newsText;
    private float repeatDelay = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        NewsStory story = new NewsStory();

        story.content = "sweet sweet content";
        story.minViews = 19;
        story.minFollowers = 202;
        story.minAttention = 33333;
        newsStoryList.Add(story);


        story.content = "yet more stuff";
        story.minViews = 69;
        story.minFollowers = 420;
        story.minAttention = 666;
        newsStoryList.Add(story);


        story.content = "real mature bud";
        story.minViews = 0;
        story.minFollowers = 0;
        story.minAttention = 0;
        newsStoryList.Add(story);

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
    // first, select random news story
    void DisplayNews()
    {
        GameObject newText = Instantiate(newsTemplate) as GameObject;
        newText.SetActive(true);
        newText.transform.SetParent(newsTemplate.transform.parent, false);

        newsText = SelectRandomNews();

        Debug.Log(newsText);

        Destroy(newText, repeatDelay);
    }

    string SelectRandomNews()
    {
        //Random.Range(1, newsStoryList.Length);
        
        if (NewsRequirementsMet() == true) {
            return "nice.";
        }

        else {
            return SelectRandomNews();
        }

    }

    // next, determine if displaying is valid
    bool NewsRequirementsMet()
    {

        return true;
    }

    // else, choose another story
    // and display the story

    public class NewsStory
    {
        public string content;
        public int minViews;
        public int minFollowers;
        public int minAttention;
    }

}