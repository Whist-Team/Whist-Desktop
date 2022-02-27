using System.Collections.Generic;
using Connections;
using Session;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Login
{
    /// <summary>
    /// Retrieves login input from the UI and forwards it to the server connection.
    /// </summary>
    public class Login : MonoBehaviour
    {
        public InputField username;
        public InputField password;

        /// <summary>
        /// Sends the login request to the whist server. It will store the authentication token in the SessionManager
        /// upon successful login.
        /// </summary>
        public void SendRequest()
        {
            string url = $"{SessionManager.serverUrl}user/auth/";
            Dictionary<string, string> fields = new Dictionary<string, string>
            {
                { "username", username.text },
                { "password", password.text }
            };
            StartCoroutine(ServerConnection.SendForm(url, FormDataFactory.Create(fields), OnLogin));
        }

        private static void OnLogin(DownloadHandler result)
        {
            AuthToken token = AuthToken.FromString(result.text);
            SessionManager.token = token;
        }
    }
}