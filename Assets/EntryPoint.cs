using Flows;
using ScriptableObject;
using UIViews.Views;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class EntryPoint : MonoBehaviour
    {
        private StartupFlow _startupFlow;
  

        [Inject]
        private void construct(StartupFlow startupFlow)
        {
            _startupFlow = startupFlow;
            
        }

        private void Start()
        {
            _startupFlow.Start();

        }
    }
}