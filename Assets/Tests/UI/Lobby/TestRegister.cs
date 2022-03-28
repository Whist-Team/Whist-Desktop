using System.Collections;
using NUnit.Framework;
using Session;
using UI.Lobby.Register;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests.UI.Lobby
{
    public class TestRegister
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            SceneManager.LoadScene("LobbyScene");
        }
        [UnityTest]
        public IEnumerator TestRegisterSuccess()
        {
            GameObject serverConnection = GameObject.Find("ServerConnection");
            Register register = serverConnection.GetComponent<Register>();

            
            register.username.text = "miles";
            register.password.text = "pwd";
            register.passwordRepeat.text = "pwd";
            register.SendRequest();
            yield return new WaitForSeconds(2);
            
            Assert.IsNotNull(SessionManager.GetUserId());
        }
    }
}