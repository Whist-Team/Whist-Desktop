using System.Collections;
using Connections;
using NUnit.Framework;
using Session;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests.UI.Lobby
{
    public class TestLogin
    {
        private string _json;

        [OneTimeSetUp]
        public void SetUp()
        {
            SceneManager.LoadScene("LobbyScene");
            _json = "{ \"username\":\"marcel\", \"password\":\"pwd\"}";
        }


        [UnityTest]
        public IEnumerator TestLoginSuccess()
        {
            GameObject serverConnection = GameObject.Find("ServerConnection");
            Login.Login login = serverConnection.GetComponent<Login.Login>();

            login.StartCoroutine(ServerConnection.SendJsonString("http://localhost:9001/user/create", _json, null));
            yield return new WaitForSeconds(2);

            login.username.text = "marcel";
            login.password.text = "pwd";
            login.SendRequest();
            yield return new WaitForSeconds(2);

            Assert.IsNotNull(SessionManager.GetToken());
        }
    }
}