using System.Collections.Generic;
using Connections;
using Session;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Login
{
    public class Login : MonoBehaviour
    {
        public InputField username;
        public InputField password;

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