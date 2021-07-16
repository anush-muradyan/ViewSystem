using UnityEngine;

public interface IFactoryConfig
{
}

public interface IUIFactoryConfig : IFactoryConfig
{
    public string Path { get; }
    public RectTransform Container { get; }
}