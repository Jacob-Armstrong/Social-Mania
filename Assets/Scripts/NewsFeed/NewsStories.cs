using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsStories : MonoBehaviour
{
    public List<NewsStory> newsStoryList = new List<NewsStory>();

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
    }

    public class NewsStory
    {
        public string content;
        public int minViews;
        public int minFollowers;
        public int minAttention;
    }
}
