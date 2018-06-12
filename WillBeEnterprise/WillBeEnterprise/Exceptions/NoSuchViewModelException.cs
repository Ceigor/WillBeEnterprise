using System;

namespace WillBeEnterprise.Exceptions
{
    public class NoSuchViewModelException : ApplicationException
    {
        private NoSuchViewModelException(string message) : base(message)
        {

        }

        public static NoSuchViewModelException CreateException(Type viewModelType)
        {
            return new NoSuchViewModelException("There is no viewModel of type: " + viewModelType);
        }
    }
}
