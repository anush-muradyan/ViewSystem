using UIViews.Abstractions;
using Zenject;
using IFactory = Factories.Abstractions.IFactory;

namespace Managers.Abstractions
{
    public abstract class AbstractManager<TFactory> : ITickable where TFactory : IFactory
    {
        public TFactory Factory { get; private set; }

        protected AbstractManager(TFactory factory)
        {
            Factory = factory;
        }

        public abstract void Tick();

        public abstract T Show<T>() where T : AbstractUIView;
        public abstract void Close<T>() where T : AbstractUIView;
    }
}