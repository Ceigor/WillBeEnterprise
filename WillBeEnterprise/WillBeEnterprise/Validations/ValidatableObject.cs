using System.Diagnostics;
using WillBeEnterprise.Bindings;

namespace WillBeEnterprise.Validations
{
    public class ValidatableObject<T> : ExtendedBindableObject, IValidity
    {
        public IValidationRule<T> ValidationRule { get; set; }
        private string error;
        public string Error
        {
            get { return error; }
            private set
            {
                error = value;
                RaisePropertyChanged(() => Error);
            }
        }
        private T value;
        public T Value
        {
            get { return value; }
            set
            {
                this.value = value;
                RaisePropertyChanged(() => Value);
            }
        }
        private bool isValid;
        public bool IsValid
        {
            get{ return isValid; }
            set
            {
                isValid = value;
                RaisePropertyChanged(() => IsValid);
            }
        }

        public ValidatableObject()
        {
            IsValid = true;
            Error = string.Empty;
        }

        public bool Validate()
        {
            if (ValidationRule == null)
                return true;
            Error = ValidationRule.Check(Value) ? string.Empty : ValidationRule.ValidationMessage;
            IsValid = Error.Length == 0;
            Debug.WriteLine("Valid after validation = " + IsValid);
            if(!IsValid)
                Debug.WriteLine("Error message = " + Error);
            return IsValid;
        }
    }
}
