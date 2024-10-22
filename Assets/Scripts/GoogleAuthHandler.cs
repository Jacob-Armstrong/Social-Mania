using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Proyecto26;
using UnityEngine;

/// <summary>
/// Handles calls to the Google provider for authentication
/// </summary>
public static class GoogleAuthHandler
{
    private const string ClientId ="730199544360-5crkigap5jud7rqs0es2chisrkkmoqla.apps.googleusercontent.com";

    private const string ClientSecret = "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";

    private static string RedirectUri = "https://us-central1-social-mania-12157807.cloudfunctions.net/saveAuthToken"; // Endpoint you can find in https://console.firebase.google.com/u/0/project/[PROJECT_ID]/functions
    private static string GetAuthTokenEndpoint = "https://us-central1-social-mania-12157807.cloudfunctions.net/getAuthToken"; // Endpoint you can find in https://console.firebase.google.com/u/0/project/[PROJECT_ID]/functions

    public static string authToken;

    /// <summary>
    /// Opens a webpage that prompts the user to sign in and copy the auth code 
    /// </summary>
    public static void SignInWithGoogle()
    {
        var guid = Guid.NewGuid().ToString();
        Application.OpenURL(
            $"https://accounts.google.com/o/oauth2/v2/auth?client_id={ClientId}&redirect_uri={RedirectUri}&response_type=code&scope=email&state={guid}");

        WaitForCode(guid);
        
    }

    private static void WaitForCode(string guid)
    {
        RestClient.Request(new RequestHelper
        {
            Method = "GET",
            Uri = GetAuthTokenEndpoint,
            Params = new Dictionary<string, string>
            {
                {"state", guid}
            }
        }).Then(async response =>
            {
                var success = response.Text != "";

                if (success)
                {
                    ExchangeAuthCodeWithIdToken(response.Text,
                        idToken => { FirebaseAuthHandler.SignInWithToken(idToken, "google.com"); });
                }
                else
                {
                    await Task.Delay(3000);
                    WaitForCode(guid);
                }
            }).Catch(Debug.Log);
    }

    /// <summary>
    /// Exchanges the Auth Code with the user's Id Token
    /// </summary>
    /// <param name="code"> Auth Code </param>
    /// <param name="callback"> What to do after this is successfully executed </param>
    private static void ExchangeAuthCodeWithIdToken(string code, Action<string> callback)
    {
        RestClient.Request(new RequestHelper
        {
            Method = "POST",
            Uri = "https://oauth2.googleapis.com/token",
            Params = new Dictionary<string, string>
            {
                {"code", code},
                {"client_id", ClientId},
                {"client_secret", ClientSecret},
                {"redirect_uri", RedirectUri},
                {"grant_type", "authorization_code"}
            }
        }).Then(
            response =>
            {
                var data =
                    StringSerializationAPI.Deserialize(typeof(GoogleIdTokenResponse), response.Text) as GoogleIdTokenResponse;
                callback(data.id_token);
                authToken = data.id_token;
                Debug.Log("authToken set");
            }).Catch(null);
    }
}