using UnityEngine;

namespace DefaultNamespace
{
    public class UIFactory<TConfig> : BaseFactory<TConfig> where TConfig : IUIFactoryConfig
    {
        public UIFactory(TConfig config) : base(config)
        {
        }

        public override T Create<T>()
        {
            var prefabName = typeof(T).Name;
            var path = $"{Config.Path}/{prefabName}";
            var productPrefab = Resources.Load<T>(path);
            var product = Object.Instantiate(productPrefab, Config.Container);
            return product;
        }
    }
}