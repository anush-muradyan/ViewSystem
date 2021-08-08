using DefaultNamespace.Models.Autorization;
using DefaultNamespace.Validation.Form;
using TMPro;
using UIViews.Abstractions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UIViews.Views
{
    public class SignInView : AbstractUIView
    {
        [SerializeField] private TMP_InputField loginInputField;
        [SerializeField] private TMP_InputField passwordInputField;
        [SerializeField] private Button signIn;
        [SerializeField] private Button registration;

        public UnityEvent<SignInModel> OnLogin { get; } = new UnityEvent<SignInModel>();
        public UnityEvent OnRegistration { get; } = new UnityEvent();

        protected override void OnEnable()
        {
            base.OnEnable();
            signIn.onClick.AddListener(onSignInButtonClick);
            registration.onClick.AddListener(OnRegistrationButtonClick);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            signIn.onClick.RemoveListener(onSignInButtonClick);
            registration.onClick.RemoveListener(OnRegistrationButtonClick);
        }

        private void onSignInButtonClick()
        {
            var form = new Form(new LoginValidator(loginInputField.text),
                new PasswordValidator(passwordInputField.text));
            if (!form.Validate())
            {
                Debug.LogError(form.Exception);
                return;
            }

            var model = new SignInModel(loginInputField.text, passwordInputField.text);
            OnLogin?.Invoke(model);
        }

        private void OnRegistrationButtonClick()
        {
            OnRegistration?.Invoke();
        }
    }
}