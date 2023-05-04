using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ChatBox : MonoBehaviour
{
    private Resources resources; //for calling global variables

    private int chatMax = 50; //max strings in list
    public GameObject chatPanel, textObject; //chatbox and text
    private double viewGate = 0; //gating based on current view amount
    private int viewGateTier = 0; //determining tier condition
    private string[] comments; //array of possible comment output from file
    private string usernameReplace; //username holder
    public GameObject profile; //for obtaining username

    [SerializeField]
    List<MessageTextMesh> chatListTextMesh = new List<MessageTextMesh>();

    public TextMeshProUGUI textMeshProObject;

    // Start is called before the first frame update
    void Start()
    {
        resources = new Resources();
        usernameReplace = "[name unknown]";
        viewGate = resources.views;
        if(viewGate < 100000)
        {
            try
            {
                comments = File.ReadAllLines(Application.dataPath + "/tier1.txt");
                //AddChatTextMesh("tier1.txt");
                viewGateTier = 1;
                StartCoroutine(AddRandomText(comments));
            }
            catch (Exception e)
            {
                // Call the ChatError function if an exception is caught
                //ChatError(e.Message);

                AddChatTextMesh("Channel 1: connection lost,  " + Application.dataPath);
            }
        }
        else if(viewGate > 100000 && viewGate < 1000000)
        {
            try
            {
                comments = File.ReadAllLines(Application.dataPath + "/tier2.txt");
                //AddChatTextMesh("tier2.txt");
                viewGateTier = 2;
                StartCoroutine(AddRandomText(comments));
            }
            catch (Exception e)
            {
                // Call the ChatError function if an exception is caught
                //ChatError(e.Message);

                AddChatTextMesh("Channel 2: connection lost");
            }
        }
        else 
        {
            try
            {
                comments = File.ReadAllLines(Application.dataPath + "/tier3.txt");
                //AddChatTextMesh("tier3.txt");
                viewGateTier = 3;
                StartCoroutine(AddRandomText(comments));
            }
            catch (Exception e)
            {
                // Call the ChatError function if an exception is caught
                //ChatError(e.Message);

                AddChatTextMesh("Channel 3: connection lost");
            }
        }
    }

    private IEnumerator AddRandomText(string[] comments)
    {
        while (true)
        {
            resources = new Resources();

            //function timer
            //float waitTime = ((UnityEngine.Random.Range(3f, 7f) - resources.attention )/(0.8f + resources.attention * resources.attention));
            float waitTime = UnityEngine.Random.Range(0.1f, 3f);
            
            //randomly select a string from list of strings
            string comment = comments[UnityEngine.Random.Range(0, comments.Length)];
            
            //call function for comment posting
            AddChatTextMesh(comment);

            //check changes to View gate conditions
            changeViewGate();

            //repeat after calculated timer
            yield return new WaitForSeconds(waitTime);
        }
    }

    public void AddChatTextMesh(string commentText)
    {
        // Check if the chat list has reached its maximum capacity
        if(chatListTextMesh.Count >= chatMax)
        {
            // Destroy the oldest message in the chat list
            Destroy(chatListTextMesh[0].textObject.gameObject);
            chatListTextMesh.Remove(chatListTextMesh[0]);
        }

        // Create a new Message object to hold the new comment's information
        MessageTextMesh newComment = new MessageTextMesh();

        
        if (profile.GetComponent<Profile>().username != "")
        {
            usernameReplace = profile.GetComponent<Profile>().username;
        }
        

        // Set the text of the new comment
        //newComment.text = commentText;
        newComment.text = commentText.Replace("#USERNAME#", usernameReplace);

        // Instantiate a new text object using the TextMeshProUGUI object
        TextMeshProUGUI newTextMesh = Instantiate(textMeshProObject, chatPanel.transform);

        // Get the TextMeshProUGUI component of the new text object and assign it to the new comment's textObject property
        newComment.textObject = newTextMesh.GetComponent<TextMeshProUGUI>();

        // Set the text of the new text object to the text of the new comment
        newComment.textObject.text = newComment.text;

        // Add the new comment to the chat list
        chatListTextMesh.Add(newComment);

        // Add a button component to the new text object
        Button button = newTextMesh.gameObject.AddComponent<Button>();

        // Add an event listener to the button component that listens for the click event
        button.onClick.AddListener(() =>
        {
            // Perform the action you want to perform when the text is clicked
            //Debug.Log("TextMeshPro object clicked!");

            newComment.text = "<User banned>";

            // Set the text of the new text object to the text of the new comment
            newComment.textObject.text = newComment.text;
        });
    }

    private void changeViewGate()
    {
        switch(viewGateTier)
        {
            case 1:
                if(viewGate > 100000)
                {
                    try
                    {
                        comments = File.ReadAllLines(Application.dataPath + "/tier2.txt");
                        viewGateTier = 2;
                    }
                    catch (Exception e)
                    {
                        //Call the ChatError function if an exception is caught
                        //ChatError(e.Message);
                        Array.Clear(comments, 0, comments.Length);

                        AddChatTextMesh("Channel 4: connection lost");
                    }
                }
                break;
            case 2:
                if(viewGate > 1000000)
                {
                    try
                    {
                        comments = File.ReadAllLines(Application.dataPath + "/tier3.txt");
                        viewGateTier = 3;
                    }
                    catch
                    {
                        //Call the ChatError function if an exception is caught
                        //ChatError(e.Message);
                        Array.Clear(comments, 0, comments.Length);

                        AddChatTextMesh("Channel 5: connection lost");
                    }
                }
                break;
            case 3:
                break;
            default:
                Array.Clear(comments, 0, comments.Length);

                AddChatTextMesh("Channel 6: connection lost");
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        //test AddChatTextMesh function
        /*
        if(Input.GetKeyDown(KeyCode.Space))
        {
            AddChatTextMesh("It works");
        }
        */
        
    }
}

[System.Serializable]
public class MessageTextMesh
{
    public string text; // The text of the message
    public TextMeshProUGUI textObject; // The TextMeshProUGUI component of the message
}