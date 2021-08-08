namespace DefaultNamespace.Validation.Form
{
    public class PasswordValidator : IValidator
    {
        private readonly string _text;
        public string Exception { get; private set; }

        public PasswordValidator(string text)
        {
            _text = text;
        }

        public bool Validate()
        {
            var isValid= !string.IsNullOrEmpty(_text);
            if (isValid)
            {
                Exception = null;
                return true;
            }

            Exception = "Password is empty";
            return false;
        }
    }
}