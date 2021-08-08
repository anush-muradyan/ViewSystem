using Models;
using Models.Entities;

namespace DefaultNamespace.Models.Autorization
{
    public struct SignUpModel
    {
        public string Name { get; }
        public string Login{ get; }
        public string Password{ get; }

        public SignUpModel(string name, string login, string password)
        {
            Name = name;
            Login = login;
            Password = password;
        }
        
    }
}