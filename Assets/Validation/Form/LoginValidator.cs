using System.Text.RegularExpressions;

namespace DefaultNamespace.Validation.Form
{
    public interface IValidator
    {
        string Exception { get; }
        bool Validate();
    }

    public class LoginValidator : IValidator
    {
        private readonly string _text;
        public string Exception { get; private set; }

        public LoginValidator(string text)
        {
            _text = text;
        }

        public bool Validate()
        {
            var regex = new Regex("^[a-zA-Z]+([a-zA-Z ]?[a-zA-Z]*)*$");
            if (regex.IsMatch(_text))
            {
                Exception = null;
                return true;
            }

            Exception = "Login field error";
            return false;
        }
    }
}