using System;

namespace CvsHealthCare.CqrsMediator.Domain.Exceptions
{
    public class AdAccountInvalidException : Exception
    {
        public AdAccountInvalidException(string message, Exception innerException) : base($"AD Account \"{message}\" is invalid.", innerException)
        {
        }
    }
}
