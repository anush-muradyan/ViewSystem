namespace DefaultNamespace.Validation.Form
{
    public class ConfirmPasswordValidator:IValidator
    {
        private readonly string _firstPassword;
        private readonly string _secondPassword;

        public ConfirmPasswordValidator(string firstPassword,string secondPassword)
        {
            _firstPassword = firstPassword;
            _secondPassword = secondPassword;
        }

        public string Exception { get; private set; }
        public bool Validate()
        {
            if (_firstPassword.Equals(_secondPassword))
            {
                Exception = null;
                return true;
            }

            Exception = "Passwords not match.";
            return false;
        }
    }
}