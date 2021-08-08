using UnityEngine;

namespace ScriptableObject
{
    [CreateAssetMenu(menuName = "Anush/Create Initial Data",fileName = "Initial Data")]
    public class InitialDataScriptableObject : UnityEngine.ScriptableObject,IInitialData
    {
        [SerializeField] private int money;
        public int Money => money;
    }
}