using System.Diagnostics;

namespace WillBeEnterprise.Validations
{
    public class IsNotNullOrEmptyRule : IValidationRule<string>
    {
        public string ValidationMessage { get; set; }

        public bool Check(string value)
        {
            Debug.WriteLine("Checking value = " + value);
            Debug.WriteLine("Returning = " + !string.IsNullOrWhiteSpace(value));
            return !string.IsNullOrWhiteSpace(value);
        }
    }
}
