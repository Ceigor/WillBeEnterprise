using System.Collections.Generic;
using System.Linq;
using WillBeEnterprise.Bindings;

namespace WillBeEnterprise.Validations
{
    public class ValidatableObject<T> : ExtendedBindableObject, IValidity
    {
        public List<IValidationRule<T>> Validations { get; private set; }
        private List<string> Errors;
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
                RaisePropertyChanged(() => isValid);
            }
        }

        public ValidatableObject()
        {
            IsValid = true;
            Errors = new List<string>();
            Validations = new List<IValidationRule<T>>();
        }

        public bool Validate()
        {
            Errors.Clear();
            IEnumerable<string> errors = Validations.Where(v => !v.Check(Value))
                .Select(v => v.ValidationMessage);
            Errors = errors.ToList();
            IsValid = !Errors.Any();
            return IsValid;
        }
    }
}
