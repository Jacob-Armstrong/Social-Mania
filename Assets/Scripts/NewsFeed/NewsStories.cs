using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsStories : MonoBehaviour
{
    public List<NewsStory> newsStoryList = new List<NewsStory>();

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
    }

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
