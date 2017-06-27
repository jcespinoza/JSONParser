using System;

namespace Espinoza.JSONParser
{
    public class LexicalException : CompilerException
    {
        public LexicalException(string message) : base(message)
        {

        }
        public override ExceptionKind ExceptionKind { get { return ExceptionKind.Lexical; } }
        public LexicalException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
