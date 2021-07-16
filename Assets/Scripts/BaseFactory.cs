using UnityEngine;

public abstract class BaseFactory<TFactoryConfig>: IFactory<TFactoryConfig> where TFactoryConfig : IFactoryConfig
{   
    public TFactoryConfig Config { get; }

    protected BaseFactory(TFactoryConfig config)
    {
        Config = config;
    }
    
    public abstract T Create<T>() where T : Object;
}
