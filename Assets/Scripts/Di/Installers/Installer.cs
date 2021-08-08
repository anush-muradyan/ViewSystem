using DefaultNamespace;
using DefaultNamespace.Flows;
using Factories;
using Flows;
using Managers;
using ScriptableObject;
using Services;
using Store;
using Tools;
using UIFactoryConfigs;
using UnityEngine;
using Zenject;

namespace Di.Installers
{
    public class Installer : MonoInstaller<Installer>
    {
        [SerializeField] private RectTransform viewContainer;
        [SerializeField] private RectTransform popupContainer;
        [SerializeField] private Executor executor;
        [SerializeField] private InitialDataScriptableObject initialDataScriptableObject;

        [Header("View Config")] [SerializeField]
        private string viewPath;

        [SerializeField] private string popupPath;

        [Header("Store Config")] [SerializeField]
        private string storeFolderName;

        public override void InstallBindings()
        {
            Container.Bind<IInitialData>().To<InitialDataScriptableObject>().FromInstance(initialDataScriptableObject)
                .AsSingle().NonLazy();
            Container.Bind<IStoreConfig>().FromInstance(new MainStoreConfig(storeFolderName)).AsSingle().NonLazy();
            Container.Bind<IDataStore>().To<DataStore>().AsSingle().NonLazy();

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

            Container.Bind<IAuthorizationService>().To<AuthorizationService>().AsSingle().NonLazy();
            Container.Bind<Session>().AsSingle().NonLazy();
            Container.Bind<Executor>().FromInstance(executor).AsSingle().NonLazy();
            Container.Bind<ViewFactory>().AsSingle().NonLazy();
            Container.Bind<PopupFactory>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ViewManager>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PopUpManager>().AsSingle().NonLazy();


            Container.Bind<AuthorizationFlow>().AsTransient().NonLazy();
            Container.Bind<StartupFlow>().AsSingle().NonLazy();
            Container.Bind<GameFlow>().AsSingle().NonLazy();
            Container.Bind<HomeFlow>().AsSingle().NonLazy();
        }
    }
}