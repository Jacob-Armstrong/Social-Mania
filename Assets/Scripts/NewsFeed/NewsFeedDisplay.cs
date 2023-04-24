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

    private float repeatDelay = 20.0f;

    public GameObject resourceObject;
    
    public GameObject profile;

    private string username;

    // Start is called before the first frame update
    void Start()
    {
        string objName;
        string content;
        double minViews;
        int minFollowers;
        int minAttention;

        username = "[name unknown]";

        content = "New social media influencer #USERNAME# starts online career. " +
            "\"Is this really news?\" asks expert.";
        minViews = 0.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s1 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s1);

        
        content = "New study reports over ten thousand videos uploaded to the internet per second " +
            "\"I don't care, I'm going to make it!\" says moron.";
        minViews = 0.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s2 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s2);

        content = "BREAKING NEWS: social media influencer uploads new video.";
        minViews = 0.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s3 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s3);

        content = "Massively popular news website claims it has made news tickers obsolete. " +
            "In other news, massively popular news website is wrong and stupid.";
        minViews = 0.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s4 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s4);
        
        content = "blank";
        minViews = 0.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s5 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s5);

        content = "blank";
        minViews = 0.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s6 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s6);

        content = "blank";
        minViews = 0.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s7 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s7);

        content = "blank";
        minViews = 0.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s8 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s8);

        content = "blank";
        minViews = 0.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s9 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s9);

        content = "blank";
        minViews = 0.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s10 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s10);

        content = "blank";
        minViews = 0.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s11 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s11);

        content = "blank";
        minViews = 0.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s12 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s12);

        content = "blank";
        minViews = 0.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s13 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s13);

        content = "blank";
        minViews = 0.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s14 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s14);

        content = "blank";
        minViews = 0.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s15 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s15);

        content = "blank";
        minViews = 0.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s16 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s16);

        content = "blank";
        minViews = 0.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s17 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s17);

        content = "blank";
        minViews = 0.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s18 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s18);

        content = "blank";
        minViews = 0.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s19 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s19);

        content = "blank";
        minViews = 0.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s20 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s20);
        



        // Repeating function which actually creates the news stories
        InvokeRepeating("DisplayNews", 1.0f, repeatDelay);
    }



    void DisplayNews()
    {
        // Create the object that will display the news story
        GameObject newText = Instantiate(newsTemplate) as GameObject;
        newText.SetActive(true);
        newText.transform.SetParent(newsTemplate.transform.parent, false);

        // Select a random news story (includes checking requirements)
        int storyID = SelectRandomNews();

        // Replace placeholder username with actual
        string originalText = newsStoryList[storyID].content;
        if (profile.GetComponent<Profile>().username != "")
        {
            username = profile.GetComponent<Profile>().username;
        }
        newsStoryList[storyID].content = newsStoryList[storyID].content.Replace("#USERNAME#", username);

        // Set the text of the news story
        newText.GetComponent<NewsObject>().SetText(newsStoryList[storyID].content);

        // Replace text with original (necessary for username to change dynamically)
        newsStoryList[storyID].content = originalText;

        Debug.Log("Current views is actually: " + resourceObject.GetComponent<Resources>().views);

        // Delete object after a delay of several seconds
        Destroy(newText, repeatDelay);
    }

    int SelectRandomNews()
    {
        // Select a random news story
        int randomID = Random.Range(1, newsStoryList.Count + 1) - 1;
        Debug.Log("Selected number: " + randomID);

        // Check if the requirements are met
        if (NewsRequirementsMet(newsStoryList[randomID]) == true) {

            // If yes, return the ID
            return randomID;
        }

        // If not, recursively call this function again
        else {
            return SelectRandomNews();
        }
        

    }

    // next, determine if displaying is valid
    bool NewsRequirementsMet(NewsStory thisStory)
    {
        double views = resourceObject.GetComponent<Resources>().views;

        if (views >= thisStory.minViews)
        {
            return true;
        }

        else
        {            
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