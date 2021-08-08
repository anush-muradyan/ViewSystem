using DefaultNamespace;
using DefaultNamespace.Flows;
using DefaultNamespace.Models;
using Services;
using Store;
using Tools;
using UnityEngine;

namespace Flows
{
    public class StartupFlow : IFlow
    {
        private readonly AuthorizationFlow _authorizationFlow;
        private readonly IAuthorizationService _authorizationService;
        private readonly HomeFlow _homeFlow;

        public StartupFlow(AuthorizationFlow authorizationFlow, IAuthorizationService authorizationService,
            HomeFlow homeFlow)
        {
            _authorizationFlow = authorizationFlow;
            _authorizationService = authorizationService;
            _homeFlow = homeFlow;
        }

        public void Start()
        {
            startUp();
        }

        private void startUp()
        {
            if (silentLogin())
            {
                _homeFlow.Start();
                return;
            }

            startAuthorizationFlow();
        }

        private bool silentLogin()
        {
            var userAccount = _authorizationService.SilentLogin();
            return userAccount != null;
        }

        private void startAuthorizationFlow()
        {
            _authorizationFlow.OnComplete.AddListener(authFlowOnComplete);
            _authorizationFlow.Start();
        }

        private void authFlowOnComplete(bool state)
        {
            if (!state)
            {
                Debug.LogError("Ara login exiiiiiii");
                return;
            }

            _homeFlow.Start();
        }
    }
}