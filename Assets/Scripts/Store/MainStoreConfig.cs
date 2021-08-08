using System.IO;
using UnityEngine;

namespace Store
{
    public class MainStoreConfig : IStoreConfig
    {
        public string StorePath { get; }

        public MainStoreConfig(string storeName)
        {
            StorePath = Path.Combine(Application.persistentDataPath, storeName);
            EnsureValid();
        }

        private void EnsureValid()
        {
            if (Directory.Exists(StorePath))
            {
                return;
            }
            Directory.CreateDirectory(StorePath);
        }
    }
}