using UnityEngine;

namespace UIFactoryConfigs.Abstractions
{
    public interface IUIFactoryConfig : IFactoryConfig
    {
        public string Path { get; }
        public RectTransform Container { get; }
    }
}