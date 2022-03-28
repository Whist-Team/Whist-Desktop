using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests.UI.Lobby
{
    public class TestSwitchMode
    {
        private GameObject _repeatField;
        private GameObject _submitButton;
        private GameObject _switchButton;
        private const string LoginText = "Login";
        private const string RegisterText = "Register";

        [UnitySetUp]
        public IEnumerator SetUp()
        {
            SceneManager.LoadScene("LobbyScene");
            yield return null;
            _repeatField = GameObject.Find("PasswordRepeatInputField");
            _submitButton = GameObject.Find("SubmitButton");
            _switchButton = GameObject.Find("SwitchButton");

        }

        [UnityTest]
        public IEnumerator TestSwitchLoginSuccess()
        {
            _switchButton.GetComponentInChildren<Text>().text = LoginText;

            _switchButton.GetComponent<Button>().onClick.Invoke();
            yield return null;
            Assert.AreEqual(RegisterText, _switchButton.GetComponentInChildren<Text>().text);
            Assert.AreEqual(LoginText, _submitButton.GetComponentInChildren<Text>().text);
            Assert.IsFalse(_repeatField.gameObject.activeInHierarchy);
        }

        [UnityTest]
        public IEnumerator TestSwitchRegisterSuccess()
        {
            _switchButton.GetComponentInChildren<Text>().text = RegisterText;

            _switchButton.GetComponent<Button>().onClick.Invoke();
            yield return null;
            Assert.AreEqual(LoginText, _switchButton.GetComponentInChildren<Text>().text);
            Assert.AreEqual(RegisterText, _submitButton.GetComponentInChildren<Text>().text);
            Assert.IsTrue(_repeatField.gameObject.activeInHierarchy);
        }
    }
}