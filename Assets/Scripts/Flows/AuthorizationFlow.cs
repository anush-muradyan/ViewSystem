using DefaultNamespace.Models.Autorization;
using Managers;
using Services;
using Store;
using Tools;
using UIViews.Views;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace.Flows
{
    public class AuthorizationFlow : IFlow<bool>
    {
        private readonly ViewManager _viewManager;
        private readonly IAuthorizationService _authorizationService;
        public UnityEvent<bool> OnComplete { get; } = new UnityEvent<bool>();

        public AuthorizationFlow(ViewManager viewManager, IAuthorizationService authorizationService)
        {
            _viewManager = viewManager;
            _authorizationService = authorizationService;
        }

        public void Start()
        {
            showSignInView();
        }

        private void showSignInView()
        {
            var view = _viewManager.Show<SignInView>();
            view.OnLogin.AddListener(onLoginViewResult);
            view.OnRegistration.AddListener(onRegistrationViewResult);
        }

        private void onRegistrationViewResult()
        {
            var view = _viewManager.Show<SignUpView>();
            view.OnSignIn.AddListener(showSignInView);
            view.OnSignUp.AddListener(onSignUp);
        }

        private void onSignUp(SignUpModel model)
        {
            var user = _authorizationService.Register(model);
            if (user== null)
            {
                Debug.LogError("Try another login!!!");
                return;
            }
            
            PlayerPrefs.SetString(Utils.AUTH_KEY, user.Id);
            PlayerPrefs.Save();
            OnComplete?.Invoke(true);
        }

        private void onLoginViewResult(SignInModel model)
        {
            var user = _authorizationService.Login(model);
            if (user!=null)
            {
                PlayerPrefs.SetString(Utils.AUTH_KEY, user.Id);
            }
            
            OnComplete?.Invoke(user != null);
        }
    }
}
