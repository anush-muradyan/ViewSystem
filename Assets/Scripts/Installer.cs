using DefaultNamespace;
using UnityEngine;
using Zenject;

public class Installer : MonoInstaller<Installer>
{
    [SerializeField] private RectTransform viewContainer;
    [SerializeField] private RectTransform popupContainer;
    [SerializeField] private Executor executor;
    [SerializeField] private string viewPath;
    [SerializeField] private string popupPath;

    public override void InstallBindings()
    {
        Container
            .Bind<ViewFactoryConfig>()
            .FromInstance(new ViewFactoryConfig(viewPath, viewContainer))
            .AsSingle()
            .NonLazy();
        Container
            .Bind<PopupFactoryConfig>()
            .FromInstance(new PopupFactoryConfig(popupPath, popupContainer))
            .AsSingle()
            .NonLazy();
        
        Container.Bind<Executor>().FromInstance(executor).AsSingle().NonLazy();
        Container.Bind<ViewFactory>().AsSingle().NonLazy();
        Container.Bind<PopupFactory>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<ViewManager>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<PopUpManager>().AsSingle().NonLazy();
    }
}