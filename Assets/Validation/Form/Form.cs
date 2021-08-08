using System.Collections.Generic;
using System.Linq;

namespace DefaultNamespace.Validation.Form
{
    public class Form
    {
        private readonly IValidator[] validators;
        public string Exception { get; private set; }

        public Form(params IValidator[] validators)
        {
            this.validators = validators;
        }

        public bool Validate()
        {
            var isValid = validators.All(validator => validator.Validate());
            if (!isValid)
            {
                var exceptions = validators.Where(validator => !validator.Validate())
                    .Select(validator => validator.Exception).ToArray();
                var str = string.Join("\n", exceptions);
                Exception = str;
                return false;
            }

            Exception = null;
            return true;
        }
    }
}