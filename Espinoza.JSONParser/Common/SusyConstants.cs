namespace Espinoza.JSONParser
{
    public class SusyConstants
    {
        public static readonly char CarriageReturn = '\r';
        public static readonly char EndOfFile = '\0';
        public static readonly char NewLine = '\n';
        public static readonly char LeftCurlyBrace = '{';
        public static readonly char RightCurlyBrace = '}';
        public static readonly char LeftSquareBracket = '[';
        public static readonly char RightSquareBracket = ']';
        public static readonly char Period = '.';
        public static readonly char Comma = ',';
        public static readonly char Colon = ':';
        public static readonly char DoubleQuote = '\"';
        public static readonly char BackSlash = '\\';
        public static readonly char Slash = '/';
        public static readonly char Underscore = '_';
        public static readonly char SingleQuote = '\'';
        public static readonly string NullKeyword = "null";
        public static readonly string NewLineEscapeSequence = "\\\n";
        public static readonly string DoubleQuoteEscapeSequence = "\\\"";

        public static readonly string MessageUnexpectedToken = "An Unexpected token was found at Col {0} Ln {1}. The Expected token was {2} but got {3}";
    }
}
