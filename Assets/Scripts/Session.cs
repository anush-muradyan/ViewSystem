using DefaultNamespace.Models;
using Models.Entities;

namespace DefaultNamespace
{
    public class Session
    {
        public User User { get; private set; }

        public void SetUser(User user)
        {
            User = user;
        }
    }
}