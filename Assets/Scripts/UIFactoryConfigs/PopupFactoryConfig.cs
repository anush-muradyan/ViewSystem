using UIFactoryConfigs.Abstractions;
using UnityEngine;

public class PopupFactoryConfig : IUIFactoryConfig
{
    public string Path { get; }
    public RectTransform Container { get; }


    public PopupFactoryConfig(string path, RectTransform container)
    {
        Path = path;
        Container = container;
    }
}