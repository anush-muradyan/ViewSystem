using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Zenject;


public class PopUpManager : IInitializable, ITickable
{
    private PopupFactory container;

    private UIView activeView { get; set; }

    [Inject]
    public void Init(PopupFactory container)
    {
        this.container = container;
    }


    public void Initialize()
    {

    }

    private void closeActiveView()
    {
        Object.Destroy(activeView.gameObject);
    }


    public void Show<T>() where T : UIView
    {
        //TODO, implement this correct!
        activeView = container.Create<T>();
    }

    public void Close<T>() where T : UIView
    {
        //TODO, Hide if popup exists! (close means destroy them)
        
    }
    
    public void Tick()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Show<FirstPopUp>();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Show<SecondPopUp>();
        }
    }
}