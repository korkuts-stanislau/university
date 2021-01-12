using System;

namespace ExceptionLib
{
    public class PolynomException : Exception
    {
        public PolynomException(string message) : base(message)
        {
        }
    }
}