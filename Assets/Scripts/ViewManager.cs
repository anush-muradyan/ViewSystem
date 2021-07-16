using DefaultNamespace;
using UnityEngine;
using Zenject;

public class ViewManager : IInitializable, ITickable
{
    private ViewFactory container;
    private UIView _activeView;

    private UIView activeView
    {
        get => _activeView;
        set
        {
            closeActiveView();
            _activeView = value;
        }
    }

    [Inject]
    public void Init(ViewFactory container)
    {
        this.container = container;
    }
    

    public void Initialize()
    {
    }

    private void closeActiveView()
    {
        if (activeView == null)
        {
            return;
        }

        Object.Destroy(activeView.gameObject);
    }
    
    public void Tick()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            activeView = container.Create<FirstView>();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            activeView=container.Create<SecondView>();
        }
    }
    
}