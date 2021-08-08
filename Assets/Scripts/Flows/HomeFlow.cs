using DefaultNamespace;
using DefaultNamespace.Flows;
using Managers;
using Store;
using UIViews.Views;
using UnityEngine;

namespace Flows
{
    public class HomeFlow : IFlow
    {
        private readonly ViewManager _viewManager;
        private readonly Session _session;
        private readonly GameFlow _gameFlow;

        private HomeFlow(ViewManager viewManager, Session session, GameFlow gameFlow)
        {
            _viewManager = viewManager;
            _session = session;
            _gameFlow = gameFlow;
        }

        public void Start()
        {
            var view = _viewManager.Show<WelcomeView>();
            view.OnProfile.AddListener(showProfileView);
            view.OnQuite.AddListener(quitGame);
            view.OnStart.AddListener(StartGame);
        }

        private void StartGame()
        {
            _gameFlow.Start();
        }

        private void quitGame()
        {
            Application.Quit();
        }

        private void showProfileView()
        {
            var view = _viewManager.Show<ProfileView>();
            view.OnDeleteAccount.AddListener((_) => _session.User.Delete());
            view.OnUpdate.AddListener((id, updateModel) =>
            {
                updateModel.Build(_session.User).Update();
            });
            view.OnBack.AddListener(Start);
        }
    }
}