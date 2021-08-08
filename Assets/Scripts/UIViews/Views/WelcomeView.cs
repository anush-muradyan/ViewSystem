using Managers;
using UIViews.Abstractions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UIViews.Views
{
    public class WelcomeView:AbstractUIView
    {
        [SerializeField] private Button Start;
        [SerializeField] private Button Profile;
        [SerializeField] private Button States;
        [SerializeField] private Button Quite;

        public readonly ViewManager _viewManager;
        public UnityEvent OnProfile { get; } = new UnityEvent();
        public UnityEvent OnStart { get; } = new UnityEvent();
        public UnityEvent OnStates { get; } = new UnityEvent();
        public UnityEvent OnQuite { get; } = new UnityEvent();
        
        
        protected override void OnEnable()
        {
            base.OnEnable();
            Start.onClick.AddListener(OnStartButtonClicked);
            Profile.onClick.AddListener(OnProfileButtonClicked);
            States.onClick.AddListener(OnStateButtonClicked);
            Quite.onClick.AddListener(OnQuiteButtonClicked);
        }

        protected override void OnDisable()
        {
            Start.onClick.RemoveListener(OnStartButtonClicked);
            Profile.onClick.RemoveListener(OnProfileButtonClicked);
            States.onClick.RemoveListener(OnStateButtonClicked);
            Quite.onClick.RemoveListener(OnQuiteButtonClicked);
        }

        private void OnStartButtonClicked()
        {
            OnStart?.Invoke();
        }

        private void OnProfileButtonClicked()
        {
            OnProfile?.Invoke();
        }

        private void OnStateButtonClicked()
        {
            OnStates?.Invoke();
        }

        private void OnQuiteButtonClicked()
        {
            OnQuite?.Invoke();
        }
    }
}