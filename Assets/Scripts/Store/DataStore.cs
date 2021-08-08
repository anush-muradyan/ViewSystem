using System.Collections.Generic;
using Tools;

namespace Store
{
    public interface IDataStore
    {
        public void Write<T>(string name, T data) where T : class;
        T Read<T>(string name) where T : class;

        public List<T> ReadMany<T>() where T : class;
        public void Update<T>(string id, T data) where T : class;

        public void Delete<T>(string name) where T : class;
    }

    public class DataStore : IDataStore
    {
        private readonly DataUnit _dataUnit; 

        public DataStore()
        {
            _dataUnit = new DataUnit(StringConstants.GetStorePath());
        }
        
        public void Write<T>(string name, T data) where T : class
        {
            _dataUnit.Write(name,data);
        }

        public T Read<T>(string name) where T : class
        {
            return _dataUnit.Read<T>(name);
        }

        public List<T> ReadMany<T>() where T : class
        {
            return _dataUnit.ReadMany<T>();
        }

        public void Update<T>(string id, T data) where T : class
        {
            Write(id, data);
        }

        public void Delete<T>(string name) where T : class
        {
        }
    }
}