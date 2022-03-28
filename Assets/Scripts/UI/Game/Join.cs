using System.Collections.Generic;
using Connections;
using Newtonsoft.Json;
using Session;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace UI.Game.Join
{
    public class Join : MonoBehaviour
    {
        public InputField gameName;
        public InputField password;

        public void SendRequest()
        {
            string url = $"{SessionManager.serverUrl}game/info/id/{gameName.text}";
            StartCoroutine(ServerConnection.GetData(url, OnId));
        }

        private void OnId(DownloadHandler result)
        {
            string gameId = ExtractGameId(result);
            string url = $"{SessionManager.serverUrl}game/join/{gameId}";
            Dictionary<string, string> fields = new Dictionary<string, string>
            {
                { "password", password.text },
            };
            StartCoroutine(ServerConnection.SendJsonString(url, JsonFactory.FromDictionary(fields), OnJoin,
                SessionManager.GetToken()));
        }

        private static void OnJoin(DownloadHandler result)
        {
            string gameId = ExtractGameId(result);
            SessionManager.gameId = gameId;
        }

        private static string ExtractGameId(DownloadHandler result)
        {
            string jsonString = result.text;
            Dictionary<string, string> idDictionary =
                JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);
            string gameId = idDictionary["id"];
            return gameId;
        }
    }
}