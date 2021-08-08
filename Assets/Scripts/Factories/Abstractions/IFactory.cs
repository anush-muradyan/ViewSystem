using UIFactoryConfigs.Abstractions;

namespace Factories.Abstractions
{
    public interface IFactory
    {
    }
    
    public interface IFactory<out TConfig> : IFactory where TConfig : IFactoryConfig
    {
        TConfig Config { get; }
    }
}