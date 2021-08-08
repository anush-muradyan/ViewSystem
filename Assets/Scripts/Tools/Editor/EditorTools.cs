using System.IO;
using UnityEditor;
using UnityEngine;

namespace Tools.Editor
{
    public static class EditorTools
    {
        [MenuItem("Anush/Flush")]
        public static void Flush()
        {
            var path = Application.streamingAssetsPath;
            var dirs = Directory.GetDirectories(path);
            var files = Directory.GetFiles(path);

            foreach (var p in dirs)
            {
                Directory.Delete(p, true);
            }

            foreach (var f in files)
            {
                File.Delete(f);
            }

            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();

            Debug.Log("Flush Complete!");
        }
    }
}