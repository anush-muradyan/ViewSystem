namespace Models.Entities
{
    public class UserGame : Entity
    {
        public int Money { get; private set; }

        public UserGame(int money)
        {
            Money = money;
        }

        public void AddMoney(int amount)
        {
            Money += amount;
        }

        public void SubtractMoney(int amount)
        {
            Money -= amount;
        }
    }
}