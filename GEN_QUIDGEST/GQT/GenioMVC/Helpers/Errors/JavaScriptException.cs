using System;

namespace GenioMVC.Helpers.Errors
{
    public class JavaScriptException : Exception
    {
        public JavaScriptException(string message)
            : base(message)
        {
        }
    }
}