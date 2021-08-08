using UnityEngine.Events;

namespace DefaultNamespace.Flows
{
    public interface IFlow
    {
        void Start();
    }
    
    public interface IFlow<TResult>:IFlow
    {
        UnityEvent<TResult> OnComplete { get; }
    }
}