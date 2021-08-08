namespace Models.Entities
{
 public class User : Entity
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public EntityNode<UserGame> UserGameNode { get; set; }
        
        public User()
        {
        }

        public User(string name, string login, string password,UserGame userGame)
        {
            Name = name;
            Login = login;
            Password = password;
            UserGameNode = new EntityNode<UserGame>(userGame);
        }


        public User(string id, string name, string login, string password,EntityNode<UserGame> userGameNode )
        {
            Id = id;
            Name = name;
            Login = login;
            Password = password;
            UserGameNode = userGameNode;
        }

        protected override void Delete<T>(string name)
        {
            UserGameNode.Delete();
            base.Delete<T>(name);
        }


        protected override void Update<T>(string name, T data)
        {
            UserGameNode.Update();
            base.Update(name, data);
        }

        public override void Delete()
        {
            Delete<User>(Id);
        }
        
        public override void Update()
        {
            Update<User>(Id,this);
        }
        
        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Login)}: {Login}, {nameof(Password)}: {Password}";
        }
    }
}