using Models.Entities;

namespace Models.Account
{
    public class UserUpdateModel
    {
        public string Name { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }

        public UserUpdateModel SetName(string name)
        {
            Name = name;
            return this;
        }

        public UserUpdateModel SetLogin(string login)
        {
            Login = login;

            return this;
        }

        public UserUpdateModel SetPassword(string password)
        {
            Password = password;
            return this;
        }

        public User Build(User oldUser)
        {
            var newUser = new User(oldUser.Id, string.IsNullOrEmpty(Name) ? oldUser.Name : Name,
                string.IsNullOrEmpty(Login) ? oldUser.Login : Login,
                string.IsNullOrEmpty(Password) ? oldUser.Password : Password,
                oldUser.UserGameNode);
           return newUser;
        }
    }
}