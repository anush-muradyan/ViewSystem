using UnityEngine;

public class ViewFactoryConfig : IUIFactoryConfig
{
    public string Path { get; }
    public RectTransform Container { get; }


    public ViewFactoryConfig(string path, RectTransform container)
    {
        Path = path;
        Container = container;
    }
}