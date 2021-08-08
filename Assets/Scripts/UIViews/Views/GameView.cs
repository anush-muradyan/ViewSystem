using UIViews.Abstractions;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace UIViews.Views
{
    public class GameView : AbstractUIView
    {
        [SerializeField] private FortuneWheel fortuneWheel;

        public UnityEvent<int> showScorePopup = new UnityEvent<int>();
        public UnityEvent showMoney = new UnityEvent();
        
        protected override void OnEnable()
        {
            base.OnEnable();
            fortuneWheel.OnResult.AddListener(SetResult);
            fortuneWheel.OnPlayerMoney.AddListener(SetMoney);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            fortuneWheel.OnResult.RemoveListener(SetResult);
            fortuneWheel.OnPlayerMoney.RemoveListener(SetMoney);
        }

        private void SetResult(int value)
        {
            showScorePopup?.Invoke(fortuneWheel.price);
        }

        private void SetMoney()
        {
            showMoney?.Invoke();
        }
    }
}