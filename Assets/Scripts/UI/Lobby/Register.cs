using System.Collections.Generic;
using Connections;
using Session;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace UI.Lobby.Register
{
    public class Register : MonoBehaviour
    {
        public InputField username;
        public InputField password;
        public InputField passwordRepeat;


        /// <summary>
        /// Sends the user registration request to the whist server. It will store the user id in the SessionManager
        /// upon successful registration.
        /// </summary>
        public void SendRequest()
        {
            if (password.text != passwordRepeat.text)
            {
                Debug.LogWarning("Password didn't match.");
            }
            string url = $"{SessionManager.serverUrl}user/create";
            Dictionary<string, string> fields = new Dictionary<string, string>
            {
                { "username", username.text },
                { "password", password.text },
            };
            StartCoroutine(ServerConnection.SendJsonString(url, JsonFactory.FromDictionary(fields), OnRegister));
        }

        private static void OnRegister(DownloadHandler result)
        {
            SessionManager.userId = result.text;
        }
    }
}

