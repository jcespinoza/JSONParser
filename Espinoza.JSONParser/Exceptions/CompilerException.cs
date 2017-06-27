using System;

namespace Espinoza.JSONParser
{
    public abstract class CompilerException : Exception
    {
        public virtual ExceptionKind ExceptionKind { get; }
        public CompilerException(ExceptionKind kind) : base("Found exception of kind: " + kind.ToString())
        {
            ExceptionKind = kind;
        }

        public CompilerException(string message) : base(message)
        {
        }

        public CompilerException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
