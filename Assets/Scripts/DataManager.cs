using System.Collections;
using System.Collections.Generic;
using Proyecto26;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System;
using System.Data;
using System.Linq;
using System.Net.Security;
using FullSerializer;
using Models;
using TMPro;
using Unity.VisualScripting;
using System.IO;

public class DataManager : MonoBehaviour
{
    /* ==== References ==== */
    [SerializeField] TimeManager timeManager;
    [SerializeField] Stats stats;
    [SerializeField] Resources resources;
    [SerializeField] Upgrades upgrades;
    [SerializeField] Profile profile;
    UserData loadedUser;

    /* ==== Game Objects ==== */
    public GameObject newUsernamePopup;
    public GameObject authFailedPopup;

    /* ==== Local Variables ==== */
    const string ProjectId = "Social-Mania";
    static readonly string DatabaseURL = "https://social-mania-12157807-default-rtdb.firebaseio.com/";
    static readonly fsSerializer Serializer = new fsSerializer();

    public string userAuth;
    bool signedIn; // get rid of this and the implementation in save() when local save is implemented
    string path;

    public List<UserData> loadedUserList;

    void Awake()
    {
        InvokeRepeating(nameof(getUsers), 0, 180); // Update leaderboard every 3 minutes
        // InvokeRepeating("save", 60, 60); // TODO: auto save?
        path = Path.Combine(Application.persistentDataPath, "SaveData.Dat");
    }

    public void Start()
    {
        if (File.Exists(path))
        {
            localLoad();
        }
    }

    public void saveAndQuit()
    {
        save();
        Application.Quit();
    }
    
    // "Sign in with Google" button
    public void onClickGoogleSignIn()
    {
        GoogleAuthHandler.SignInWithGoogle();
        profile.authPopup.SetActive(true);
        profile.disableButtons();
    }

    // "Click here once you have signed in with Google!" to pull authToken from the handler
    public void userAuthenticated()
    {
        userAuth = FirebaseAuthHandler.localId;
        if (userAuth == null)
        {
            authFailedPopup.SetActive(true);
        }
        else
        {
            Debug.Log("User Auth: " + userAuth);
            profile.enableButtons();
            StartCoroutine(load());
            signedIn = true;
        }

        profile.authPopup.SetActive(false);
        profile.googleSignInText.text = "";
    }

    // Save user data
    public void save()
    {
        if (!signedIn)
        {
            Debug.Log("Local save");
            UserData user = new UserData();
            saveData(user);
            localSave(user);
        }
        else
        {
            UserData user = new UserData();
            saveData(user);
            uploadToDatabase(user);
        }
    }
    
    // Data to be saved (augment UserData class to change)
    void saveData(UserData user)
    {
        user.username = profile.username;
        user.followers = resources.followers;
        user.lifetimeViews = resources.views;
        user.numClicks = stats.numClicks;
        user.upgradesPurchased = upgrades.GetPurchasedUpgrades();
        user.startDate = timeManager.startDate.ToString();
        user.lastSeen = DateTime.Now.ToString();
    }
    
    // Upload UserData class to database
    void uploadToDatabase(UserData user)
    {
        Debug.Log("Starting save...");
        RestClient.Put<UserData>($"{DatabaseURL}users/{userAuth}.json", user).Then(response =>
        {
            Debug.Log("The user was successfully uploaded to the database");
        });
    }

    void localSave(UserData user)
    {
        string json = JsonUtility.ToJson(user);
        File.WriteAllText(path, json);
    }

    void localLoad()
    {
        string json = File.ReadAllText(path);
        UserData response = new UserData();
        JsonUtility.FromJsonOverwrite(json, response);

        profile.username = response.username;
        resources.followers = response.followers;
        resources.views = response.lifetimeViews;
        stats.numClicks = response.numClicks;
        upgrades.LoadPurchasedUpgrades(response.upgradesPurchased);
        timeManager.startDate = DateTime.Parse(response.startDate);
        timeManager.lastSeen = DateTime.Parse(response.lastSeen);

        // Calculate offline time, display relevant offline info
        timeManager.offlinePopup();
    }

    // Load data from database, deconstruct response into saved data
    public IEnumerator load()
    {
        Debug.Log("Starting load...");
        profile.disableButtons();
        
        if (!checkUsernameTaken(profile.username))
        {
            profile.username = "";
            profile.hardReset();
        }

        RestClient.Get<UserData>($"{DatabaseURL}users/{userAuth}.json").Then(response =>
        {
            Debug.Log("Load successful.");

            // Load all information from database response (UserData class) into relevant player sources
            profile.username = response.username;
            resources.followers = response.followers;
            resources.views = response.lifetimeViews;
            stats.numClicks = response.numClicks;
            upgrades.LoadPurchasedUpgrades(response.upgradesPurchased);
            timeManager.startDate = DateTime.Parse(response.startDate);
            timeManager.lastSeen = DateTime.Parse(response.lastSeen);

            // Calculate offline time, display relevant offline info
            timeManager.offlinePopup();

            profile.usernameInput.gameObject.SetActive(true);
            profile.submitUsernameButton.gameObject.SetActive(true);
        });
        
        yield return new WaitForSeconds(0.5f);
        if (profile.username == "")
        {
            newUsernamePopup.SetActive(true);
            profile.disableButtons();
        }
    }

    public void getUsers()
    {
        Debug.Log("Updating leaderboard...");
        RestClient.Get($"{DatabaseURL}users.json").Then(response =>
        {
            var responseJson = response.Text;
            var data = fsJsonParser.Parse(responseJson);
            object deserialized = null;
            Serializer.TryDeserialize(data, typeof(Dictionary<string, UserData>), ref deserialized);

            var usersDict = deserialized as Dictionary<string, UserData>;

            List<UserData> userList = usersDict.Values.ToList().OrderByDescending(userData => userData.lifetimeViews).ToList();
            loadedUserList = userList;

            for (int i = 0; i < 10; i++)
            {
                profile.leaderboardPositions[i].text = userList[i].username + " - " + CalcUtils.FormatNumber((int)userList[i].lifetimeViews) + " views";
            }
        });
    }

    public bool localSaveFileExists()
    {
        return File.Exists(path);
    }

    public void deleteLocalSaveFile()
    {
        File.Delete(path);
    }

    public bool checkUsernameTaken(string usernameInput)
    {
        foreach (UserData user in loadedUserList)
        {
            if (user.username.Equals(usernameInput, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
        }
        return true;
    }
}
