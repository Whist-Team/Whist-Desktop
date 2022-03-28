using System.Collections;
using NUnit.Framework;
using Session;
using UI.Game.Create;
using UI.Game.Join;
using UI.Lobby.Register;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests.UI.Game
{
    public class TestJoin
    {
        [UnitySetUp]
        public IEnumerator SetUp()
        {
            const string username = "albatross";
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
            yield return null;
            serverConnection = GameObject.Find("GameLobbyConnection");
            Create create = serverConnection.GetComponent<Create>();

            create.gameName.text = "albatross";
            create.password.text = "pwd";
            create.passwordRepeat.text = "pwd";
            create.SendRequest();
            yield return new WaitUntil(() => SessionManager.GetGameId() != null);
        }
        [UnityTest]
        public IEnumerator TestGameJoinSuccess()
        {
            GameObject serverConnection = GameObject.Find("GameLobbyConnection");
            Join gameJoin = serverConnection.GetComponent<Join>();

            gameJoin.gameName.text = "albatross";
            gameJoin.password.text = "pwd";
            gameJoin.SendRequest();
            yield return new WaitUntil(() => SessionManager.GetGameId() != null);

            Assert.IsNotNull(SessionManager.GetGameId());
        }
    }
}