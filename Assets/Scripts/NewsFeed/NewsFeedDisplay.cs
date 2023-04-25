using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewsFeedDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject newsTemplate;

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



        // Max Length:
        // content: BREAKING NEWS: Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do
        // eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam dol

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

        content = "New trend of content creators uploading silent videos to honor the deaf " +
            "outrages the blind.";
        minViews = 0.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s4 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s4);
        
        content = "BREAKING NEWS: \"Everything is fine\" claims CEO standing in front of " +
            "burning building.";
        minViews = 0.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s5 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s5);

        content = "\"Artificial intelligence is not a problem, just carry on\" says real human.";
        minViews = 0.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s6 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s6);

        content = "\"Whoever said that news stories are being written by artificial intelligence " +
            "is a dingus\" says bingus.";
        minViews = 0.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s7 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s7);

        content = "BREAKING NEWS: Rioters smash like button. \"We can never put it back " +
            "together again,\" says Chief of Internet Police.";
        minViews = 0.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s8 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s8);

        content = "New cleaning trend sweeps the nation. \"Well at least it's not something " +
            "pointless like social media,\" says mother.";
        minViews = 0.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s9 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s9);

        content = "BREAKING NEWS: Podcast about cancel culture cancelled. \"I don't know what " +
            "we expected.\"";
        minViews = 0.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s10 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s10);

        content = "Health claims about new online diet disputed by out of touch parents. " +
            "\"Potato chips won't cure influenza!\"";
        minViews = 0.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s11 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s11);

        content = "TODAY: Outrage towards crypto CEO who defrauded investors. \"I learned " +
            "my lesson, and to make ammends I am proud to announce the new IMSORRY token...\"";
        minViews = 0.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s12 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s12);

        content = "Social media influencer Clevus McBevus arrested after multi-hour shootout " +
            "with police. \"It was just a prank, bro.\"";
        minViews = 0.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s13 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s13);

        content = "THIS JUST IN: Celebrities release video song about saving the world. " +
            "Moments later, all world problems were solved.";
        minViews = 0.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s14 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s14);

        content = "TONIGHT AT 11: Interview with controversial creator of content for children. " +
            "\"It's not for the views, I just really like Elsa and Spiderman.\"";
        minViews = 0.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s15 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s15);

        content = "\"This isn't about money\" says highest paid content creator on the platform.";
        minViews = 0.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s16 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s16);

        content = "TODAY: Debate whether corporate money influences news media. \"This is " +
            "preposterous!\" claims CEO of company that makes delicious yet affordable potato chips.";
        minViews = 0.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s17 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s17);

        content = "\"Traditional news media no longer relevant,\" says person who is wrong " +
            "and should shut up.";
        minViews = 0.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s18 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s18);

        content = "Social media influencer #USERNAME# growing in popularity. \"I've never " +
            "been so proud to be disappointed in them,\" says their mother.";
        minViews = 10000.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s19 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s19);

        content = "#USERNAME# now has millions of views. \"Isn't there a war going on?\" " +
            "asks out of touch citizen.";
        minViews = 1000000.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s20 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s20);

        content = "Social media empire of #USERNAME# growing out of control. Countless fans " +
            "call for them to run for president or upload videos more regularly.";
        minViews = 1000000000.0f;
        minFollowers = 0;
        minAttention = 0;
        NewsStory s21 = new NewsStory(content, minViews, minFollowers, minAttention);
        newsStoryList.Add(s21);



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

        //Debug.Log("Current views is actually: " + resourceObject.GetComponent<Resources>().views);

        // Delete object after a delay of several seconds
        Destroy(newText, repeatDelay);
    }

    int SelectRandomNews()
    {
        // Select a random news story
        int randomID = Random.Range(1, newsStoryList.Count + 1) - 1;
        //Debug.Log("Selected number: " + randomID);

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
        // Get views from resources script
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

    // Class to hold content and minimum values
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