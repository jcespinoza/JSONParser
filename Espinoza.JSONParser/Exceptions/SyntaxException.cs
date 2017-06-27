using System;

namespace Espinoza.JSONParser
{
    public class SyntaxException : CompilerException
    {
        public SyntaxException(string message) : base(message)
        {
        }

        public SyntaxException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public override ExceptionKind ExceptionKind
        {
            get
            {
                return ExceptionKind.Syntactic;
            }
        }
    }
}
