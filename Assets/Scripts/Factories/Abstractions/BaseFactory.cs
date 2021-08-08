using UIFactoryConfigs.Abstractions;
using UnityEngine;

namespace Factories.Abstractions
{
    public abstract class BaseFactory<TFactoryConfig>: IFactory<TFactoryConfig> where TFactoryConfig : IFactoryConfig
    {   
        public TFactoryConfig Config { get; }

        protected BaseFactory(TFactoryConfig config)
        {
            Config = config;
        }
    
        public abstract T Create<T>() where T : Object;
    }
}
