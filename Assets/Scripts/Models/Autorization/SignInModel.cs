namespace DefaultNamespace.Models.Autorization
{
    public struct SignInModel
    {
        public string Login { get; }
        public string Password { get; }
        
        
        public SignInModel(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}