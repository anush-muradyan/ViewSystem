using DefaultNamespace.Flows;
using Managers;
using UIViews.Popups;
using UIViews.Views;
using Zenject;

namespace Flows
{
    public class GameFlow : IFlow
    {
        private readonly ViewManager _viewManager;
        private readonly PopUpManager _popUpManager;
        private readonly DiContainer _container;

        private GameFlow(ViewManager viewManager, PopUpManager popUpManager,DiContainer container)
        {
            _viewManager = viewManager;
            _popUpManager = popUpManager;
            _container = container;
        }

        public void Start()
        {
            var view = _viewManager.Show<GameView>();
            _container.InjectGameObject(view.gameObject);
            view.showScorePopup.AddListener(OnGameScorePopup);
            view.showMoney.AddListener(OnNotEnoughMoneyPopup);
        }

        private void OnNotEnoughMoneyPopup()
        {
            var popup = _popUpManager.Show<NotEnoughMoneyPopup>();
            popup.OnClose.AddListener(OnCloseNotEnoughMoneyPopup);

        }

        private void OnCloseNotEnoughMoneyPopup()
        {
            _popUpManager.Close<NotEnoughMoneyPopup>();
        }

        private void OnGameScorePopup(int a)
        {
            var popup = _popUpManager.Show<GameScorePopup>();
            popup.SetData(new GameScoreData(a));
            popup.OnClose.AddListener(OnCloseGameScorePopup);
        }

        private void OnCloseGameScorePopup()
        {
            _popUpManager.Close<GameScorePopup>();
        }
    }
}