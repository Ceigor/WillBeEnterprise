using System;

namespace WillBeEnterprise.Exceptions
{
    public class InvalidTypeException : ApplicationException
    {
        private InvalidTypeException(Type expectedType, Type actualType) :
            base(String.Format("Expected type: {0}, but was: {1}", expectedType, actualType))
        {
        }

        public static InvalidTypeException CreateExpectedActualException(Type expectedType, Type actualType)
        {
            return new InvalidTypeException(expectedType, actualType);
        }
    }
}
