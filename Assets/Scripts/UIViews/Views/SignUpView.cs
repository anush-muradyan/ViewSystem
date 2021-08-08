using DefaultNamespace.Models.Autorization;
using DefaultNamespace.Validation.Form;
using TMPro;
using UIViews.Abstractions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UIViews.Views
{
    public class SignUpView : AbstractUIView
    {
        [SerializeField] private TMP_InputField nameInputField;
        [SerializeField] private TMP_InputField loginInputField;
        [SerializeField] private TMP_InputField passwordInputField;
        [SerializeField] private TMP_InputField confirmInputField;
        [SerializeField] private Button signUp;
        [SerializeField] private Button signIn;
        
        public UnityEvent<SignUpModel> OnSignUp { get; } = new UnityEvent<SignUpModel>();
        public UnityEvent OnSignIn { get; } = new UnityEvent();

        protected override void OnEnable()
        {
            base.OnDisable();
            signUp.onClick.AddListener(onSignUpButtonClick);
            signIn.onClick.AddListener(onSignInButtonClick);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            signUp.onClick.RemoveListener(onSignUpButtonClick);
            signIn.onClick.RemoveListener(onSignInButtonClick);
        }

        public void onSignUpButtonClick()
        {
            var form = new Form(
                new NotEmptyValidator(nameInputField.text),
                new LoginValidator(loginInputField.text),
                new PasswordValidator(passwordInputField.text),
                new PasswordValidator(confirmInputField.text),
                new ConfirmPasswordValidator(passwordInputField.text, confirmInputField.text));
            if (!form.Validate())
            {
                Debug.LogError(form.Exception);
                return;
            }

            var model = new SignUpModel(nameInputField.text, loginInputField.text, passwordInputField.text);
            OnSignUp?.Invoke(model);
        }

        private void onSignInButtonClick()
        {
            OnSignIn?.Invoke();
        }
    }
}