namespace Espinoza.JSONParser
{
    public class SusyConstants
    {
        internal static readonly char CarriageReturn = '\r';
        internal static readonly char EndOfFile = '\0';
        internal static readonly char NewLine = '\n';
        internal static readonly char LeftCurlyBrace = '{';
        internal static readonly char RightCurlyBrace = '}';
        internal static readonly char LeftSquareBracket = '[';
        internal static readonly char RightSquareBracket = ']';
        internal static readonly char Period = '.';
        internal static readonly char Comma = ',';
        internal static readonly char Colon = ':';
        internal static readonly char DoubleQuote = '\"';
        internal static readonly char BackSlash = '\\';
        internal static readonly char Slash = '/';
        internal static readonly char Underscore = '_';
        internal static readonly char SingleQuote = '\'';
        internal static readonly string NullKeyword = "null";
        internal static readonly string NewLineEscapeSequence = "\\\n";
        internal static readonly string DoubleQuoteEscapeSequence = "\\\"";

        internal static readonly string MessageUnexpectedToken = "An Unexpected token was found at Col {0} Ln {1}. The Expected token was {2} but got {3}";
    }
}
