using System.Collections;
using NUnit.Framework;
using Session;
using UI.Game.Create;
using UI.Lobby.Register;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests.UI.Game
{
    public class TestCreate
    {
        [UnitySetUp]
        public IEnumerator SetUp()
        {
            const string username = "hornblower";
            const string password = "pwd";

            SceneManager.LoadScene("LobbyScene");
            yield return null;
            GameObject serverConnection = GameObject.Find("ServerConnection");
            Register register = serverConnection.GetComponent<Register>();
            Login.Login login = serverConnection.GetComponent<Login.Login>();

            register.username.text = username;
            register.password.text = password;
            register.passwordRepeat.text = password;
            register.SendRequest();
            yield return new WaitUntil(() => SessionManager.GetUserId() != null);

            login.username.text = username;
            login.password.text = password;
            login.SendRequest();
            yield return new WaitUntil((() => SessionManager.GetToken() != null));
            SceneManager.LoadScene("GameLobbyScene");
        }

        [UnityTest]
        public IEnumerator TestGameCreationSuccess()
        {
            GameObject serverConnection = GameObject.Find("GameLobbyConnection");
            Create gameCreate = serverConnection.GetComponent<Create>();

            gameCreate.gameName.text = "hornblower";
            gameCreate.password.text = "pwd";
            gameCreate.SendRequest();
            yield return new WaitUntil(() => SessionManager.GetGameId() != null);

            Assert.IsNotNull(SessionManager.GetGameId());
        }
    }
}