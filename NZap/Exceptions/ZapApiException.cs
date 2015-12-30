using System;

namespace NZap.Exceptions
{
    public class ZapApiException : Exception
    {
        public ZapApiException(string message) : base(message)
        {
        }
    }
}
