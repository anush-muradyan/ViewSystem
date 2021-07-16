public interface IFactory<out TConfig> where TConfig : IFactoryConfig
{
    TConfig Config { get; }
}