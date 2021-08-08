using System;
using Factories;
using Managers.Abstractions;
using UIViews.Abstractions;
using Zenject;
using Object = UnityEngine.Object;

namespace Managers
{
    public class ViewManager : AbstractManager<ViewFactory>
    {
        private readonly DiContainer _container;
        private AbstractUIView _activeView;

        private AbstractUIView activeView
        {
            get => _activeView;
            set
            {
                closeActiveView();
                _activeView = value;
            }
        }

        public ViewManager(ViewFactory factory,DiContainer container) : base(factory)
        {
            _container = container;
        }


        private void closeActiveView()
        {
            if (activeView == null)
            {
                return;
            }

            Object.Destroy(activeView.gameObject);
        }

        public override T Show<T>()
        {
            var view = Factory.Create<T>();
            _container.Inject(view);
            activeView = view;
            activeView.gameObject.SetActive(true);
            return view;
        }

        public override void Close<T>()
        {
            if (_activeView.GetType() != typeof(T))
            {
                throw new Exception("It isn't current active view!!!");
            }

            Object.Destroy(activeView.gameObject);
        }

        public override void Tick()
        {
            // if (Input.GetKeyDown(KeyCode.A))
            // {
            //     Show<FirstView>();
            // }
            //
            // if (Input.GetKeyDown(KeyCode.B))
            // {
            //     Show<SecondView>();
            // }
            //
            // if (Input.GetKeyDown(KeyCode.O))
            // {
            //     Close<FirstView>();
            // }
            //
            // if (Input.GetKeyDown(KeyCode.P))
            // {
            //     Close<SecondView>();
            // }
        }
    }
}