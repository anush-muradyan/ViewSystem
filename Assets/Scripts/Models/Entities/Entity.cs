using System;
using Store;
using Tools;

namespace Models.Entities
{
    public abstract class Entity
    {
        public string Id { get; set; }
        private readonly DataUnit _dataUnit;

        protected Entity()
        {
            Id = Guid.NewGuid().ToString();
            _dataUnit = new DataUnit(StringConstants.GetStorePath());
        }

        protected T Read<T>(string name) where T : class
        {
            return _dataUnit.Read<T>(name);
        }

        protected void Write<T>(string name, T data) where T : class
        {
            _dataUnit.Write(name, data);
        }

        protected virtual void Delete<T>(string name) where T : class
        {
            _dataUnit.Delete<T>(name);
        }

        protected virtual void Update<T>(string name,T data) where T:class
        {
            Write(name, data);
        }
        
        public virtual void Delete()
        {
        }
        public virtual void Update()
        {
        }
    }
}