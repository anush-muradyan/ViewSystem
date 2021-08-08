using TMPro;
using UIViews.Abstractions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UIViews.Popups
{
    public class GameScoreData
    {
        public int Value { get; }

        public GameScoreData(int value)
        {
            Value = value;
        }
    }

    public class GameScorePopup : AbstractUIView<GameScoreData>
    {
        [SerializeField] private TextMeshProUGUI winLooseText;
        [SerializeField] private Button closePopupButton;
        [SerializeField] private Button bgClosePopupButton;
        public UnityEvent OnClose { get; } = new UnityEvent();

        protected override void Start()
        {
            base.Start();
            winLooseText.text = ViewData.Value <= 0 ? $"You loose {ViewData.Value}!" : $"You win {ViewData.Value}!!!";
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            closePopupButton.onClick.AddListener(OnClose.Invoke);
            bgClosePopupButton.onClick.AddListener(OnClose.Invoke);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            closePopupButton.onClick.RemoveListener(OnClose.Invoke);
            bgClosePopupButton.onClick.RemoveListener(OnClose.Invoke);
        }
    }
}