using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Tools;

namespace Store
{
    public class DataUnit
    {
        private readonly string _basePath;

        public DataUnit(string basePath)
        {
            _basePath = basePath;
        }

        public void ensureFolder<T>(out string path) where T : class
        {
            var type = typeof(T);
            var folderName = type.Name;
            path = Path.Combine(_basePath, folderName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private string getPath<T>(string name) where T : class
        {
            ensureFolder<T>(out var path);
            var fileName = string.Format(StringConstants.FILE_FORMAT, typeof(T).Name, name);
            var fullPath = Path.Combine(path, fileName);
            return fullPath;
        }

        public T Read<T>(string name) where T : class
        {
            var path = getPath<T>(name);
            if (!File.Exists(path))
            {
                return default;
            }

            var content = File.ReadAllText(path);
            var data = JsonConvert.DeserializeObject<T>(content);
            return data;
        }
        
        public List<T> ReadMany<T>() where T : class
        {
            var searchPattern = string.Format(StringConstants.SEARCH_FILE_FORMAT, typeof(T).Name);
            ensureFolder<T>(out var path);
            var files = Directory.GetFiles(path, searchPattern);
            return files
                .Select(File.ReadAllText)
                .Select(JsonConvert.DeserializeObject<T>).ToList();
        }

        public void Write<T>(string name, T data) where T : class
        {
            var path = getPath<T>(name);
            var content = JsonConvert.SerializeObject(data);
            File.WriteAllText(path, content);
        }

        public void Delete<T>(string name) where T : class
        {
            var path = getPath<T>(name);
            if (!File.Exists(path))
            {
                return;
            }

            File.Delete(path);
        }
    }

}