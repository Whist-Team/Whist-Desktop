using System.Collections.Generic;
using Connections;
using UnityEngine;
using UnityEngine.UI;

namespace Login
{
    public class Login : MonoBehaviour
    {
        public InputField username;
        public InputField password;

        public void SendRequest()
        {
            string url = "http://localhost:9001/user/auth/";
            Dictionary<string, string> fields = new Dictionary<string, string>
            {
                { "username", username.text },
                { "password", password.text }
            };
            StartCoroutine(ServerConnection.SendForm(url, FormDataFactory.Create(fields)));
        }
    }
}