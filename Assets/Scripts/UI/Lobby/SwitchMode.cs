using UnityEngine;
using UnityEngine.UI;

namespace UI.Lobby
{
    public class SwitchMode : MonoBehaviour
    {
        public InputField passwordRepeat;
        public Button submitButton;
        public Button switchButton;
        private Text _switchButtonText;
        private Text _submitButtonText;
        const string registerText = "Register";
        const string loginText = "Login";

        private void Start()
        {
            _switchButtonText = switchButton.GetComponentInChildren<Text>();
            _submitButtonText = submitButton.GetComponentInChildren<Text>();
            SetRegisterMode();
        }

        public void Switch()
        {
            switch (_switchButtonText.text)
            {
                case registerText:
                    SetRegisterMode();
                    break;
                case loginText:
                    SetLoginMode();
                    break;
            }
        }

        private void SetLoginMode()
        {
            _switchButtonText.text = registerText;
            _submitButtonText.text = loginText;
            passwordRepeat.gameObject.SetActive(false);
        }

        private void SetRegisterMode()
        {
            _switchButtonText.text = loginText;
            _submitButtonText.text = registerText;
            passwordRepeat.gameObject.SetActive(true);
        }
    }
}