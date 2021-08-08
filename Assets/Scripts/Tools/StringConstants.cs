using System.IO;
using UnityEngine;

namespace Tools
{
    public class StringConstants
    {
        public const string STORE_FOLDER = "Store";
        public const string FILE_FORMAT = "{0}-{1}.anush";
        public const string SEARCH_FILE_FORMAT = "{0}*.anush";

        public static string GetStorePath()
        {
            return Path.Combine(Application.persistentDataPath, STORE_FOLDER);
        }
    }
}