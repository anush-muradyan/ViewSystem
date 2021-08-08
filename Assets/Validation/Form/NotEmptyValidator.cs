namespace DefaultNamespace.Validation.Form
{
    public class NotEmptyValidator:IValidator
    {
        private readonly string _text;
        public string Exception { get; private set; }

        public NotEmptyValidator(string text)
        {
            _text = text;
        }
        public bool Validate()
        {
            if (string.IsNullOrEmpty(_text))
            {
                Exception = "Something is empty";
                return false;
            }

            Exception = null;
            return true;
        }
    }
}