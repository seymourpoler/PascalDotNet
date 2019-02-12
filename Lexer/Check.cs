using System;

namespace PascalDotNet.Lexer
{
    public static class Check
    {
        public static void ThrowIf<TException>(Func<bool> condition)
        {
            if (condition.Invoke())
            {
                var exception = (Exception)Activator.CreateInstance(typeof(TException));
                throw exception;
            }
        }
    }
}