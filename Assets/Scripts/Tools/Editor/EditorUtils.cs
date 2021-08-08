using UnityEditor;
using UnityEngine;

namespace Tools.Editor
{
    public static class EditorUtils
    {
        [MenuItem("Anush/Clear Prefs")]
        public static void ClearPrefs()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
    }
}