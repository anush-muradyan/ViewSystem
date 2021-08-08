using System.Collections.Generic;
using DefaultNamespace.Models;
using DefaultNamespace.Models.Autorization;
using UnityEngine;

namespace Tools
{
   
    public class Utils
    {
        public const string AUTH_KEY = "AUTHORIZATION";
        
        private static int GenerateUserHash(string user)
        {
            return user.GetHashCode();
        }
        
        public static List<T> GetInterfaces<T>() where T : class
        {
            var objects = Object.FindObjectsOfType<MonoBehaviour>(true);
            var holder = new List<T>();
            for (var i = 0; i < objects.Length; i++)
            {
                var components = objects[i].GetComponents<T>();
                if (components == null || components.Length == 0)
                {
                    continue;
                }

                foreach (var component in components)
                {
                    if (!(component is T cmp))
                    {
                        continue;
                    }

                    holder.Add(cmp);
                }
            }

            return holder;
        }
    }
}