using DefaultNamespace;
using Models.Account;
using Newtonsoft.Json;
using TMPro;
using Tools;
using UIViews.Abstractions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace UIViews.Views
{
    public class ProfileView : AbstractUIView
    {
        [SerializeField] private Button update;
        [SerializeField] private Button delete;
        [SerializeField] private Button ok;
        [SerializeField] private Button back;
        [SerializeField] private TMP_InputField inputNameField;
        [SerializeField] private TMP_InputField inputLoginField;
        [SerializeField] private TMP_InputField inputPasswordField;
        [SerializeField] private TextMeshProUGUI name;

        private Session _session;

        public UnityEvent<string, UserUpdateModel> OnUpdate { get; } = new UnityEvent<string, UserUpdateModel>();
        public UnityEvent<string> OnDeleteAccount { get; } = new UnityEvent<string>();
        public UnityEvent OnBack { get; } = new UnityEvent();

        [Inject]
        private void construct(Session session)
        {
            _session = session;
            name.text = session.User.Name;
            
            inputNameField.text = _session.User.Name;
            inputLoginField.text=_session.User.Login;
            inputPasswordField.text=_session.User.Password;
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            ok.onClick.AddListener(onBackButtonClicked);
            update.onClick.AddListener(onUpdateButtonClicked);
            delete.onClick.AddListener(onDeleteButtonClicked);
            back.onClick.AddListener(onBackButtonClicked);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            ok.onClick.RemoveListener(onBackButtonClicked);
            update.onClick.RemoveListener(onUpdateButtonClicked);
            delete.onClick.RemoveListener(onDeleteButtonClicked);
        }

        private void onDeleteButtonClicked()
        {
            OnDeleteAccount?.Invoke(_session.User.Id);
        }

        private void onBackButtonClicked()
        {
           OnBack?.Invoke();
        }

        private void onUpdateButtonClicked()
        {
            var userUpdate = new UserUpdateModel()
                .SetName(inputNameField.text).SetLogin(inputLoginField.text)
                .SetPassword(inputPasswordField.text);
            
            OnUpdate?.Invoke(_session.User.Id, userUpdate);
            
            name.text = inputNameField.text;
            
            _session.User.Name = inputNameField.text;
            _session.User.Login = inputLoginField.text;
            _session.User.Password = inputPasswordField.text;

        }
        
    }
}