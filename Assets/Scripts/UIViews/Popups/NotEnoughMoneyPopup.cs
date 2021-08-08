using UIViews.Abstractions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UIViews.Popups
{
    public class NotEnoughMoneyPopup : AbstractUIView
    {
        [SerializeField] private Button closeButton;
        [SerializeField] private Button bgClosePopupButton;
        public UnityEvent OnClose { get; } = new UnityEvent();
        
        protected override void OnEnable()
        {
            base.OnEnable();
            closeButton.onClick.AddListener(OnClose.Invoke);
            bgClosePopupButton.onClick.AddListener(OnClose.Invoke);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            closeButton.onClick.RemoveListener(OnClose.Invoke);
            bgClosePopupButton.onClick.RemoveListener(OnClose.Invoke);
        }
    }
}