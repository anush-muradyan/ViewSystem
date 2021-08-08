using System;
using System.Collections.Generic;
using Factories;
using Managers.Abstractions;
using UIViews.Abstractions;
namespace Managers
{
    public class PopUpManager : AbstractManager<PopupFactory>
    {
        private List<AbstractUIView> views;

        public PopUpManager(PopupFactory factory) : base(factory)
        {
            views = new List<AbstractUIView>();
        }

        public override T Show<T>()
        {
            var view = Factory.Create<T>();
            views.Add(view);
            view.gameObject.SetActive(true);
            return view;
        }

        public override void Close<T>()
        {
            var idx = views.FindLastIndex(view => view.GetType() == typeof(T));
            if (idx >= 0)
            {
                UnityEngine.Object.Destroy(views[idx].gameObject);
                views.RemoveAt(idx);
                return;
            }

            throw new Exception("We dont have this popup!");
        }


        public override void Tick()
        {
        }
    }
}