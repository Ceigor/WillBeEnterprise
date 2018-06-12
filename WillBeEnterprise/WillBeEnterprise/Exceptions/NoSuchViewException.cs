using System;

namespace WillBeEnterprise.Exceptions
{
    public class NoSuchViewException : ApplicationException
    {
        private NoSuchViewException(string message) : base(message)
        {

        }

        public static NoSuchViewException CreateException(Type viewType)
        {
            return new NoSuchViewException("There is no view of type: " + viewType);
        }
    }
}
