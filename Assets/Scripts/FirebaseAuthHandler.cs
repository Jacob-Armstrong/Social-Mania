using Proyecto26;
using UnityEngine;

/// <summary>
/// Handles authentication calls to Firebase
/// </summary>

public static class FirebaseAuthHandler
{
    private const string ApiKey = "AIzaSyD7l-171C5Ey5MN7JU7pwcRyyrQWXqZpN4"; //TODO: Change [API_KEY] to your API_KEY
    public static string localId;
    public static string responseText;
    
    /// <summary>
    /// Signs in a user with their Id Token
    /// </summary>
    /// <param name="token"> Id Token </param>
    /// <param name="providerId"> Provider Id </param>
    public static void SignInWithToken(string token, string providerId)
    {
        var payLoad =
            $"{{\"postBody\":\"id_token={token}&providerId={providerId}\",\"requestUri\":\"http://localhost\",\"returnIdpCredential\":true,\"returnSecureToken\":true}}";
        RestClient.Post($"https://identitytoolkit.googleapis.com/v1/accounts:signInWithIdp?key={ApiKey}", payLoad).Then(
            response =>
            {
                // You now have the userId (localId) and the idToken of the user!
                Debug.Log(response.Text);
                responseText = "response!";
                var data =
                    StringSerializationAPI.Deserialize(typeof(GoogleIdTokenResponse), response.Text) as
                        GoogleIdTokenResponse;
                localId = data.localId;
            });
    }
}