namespace Espinoza.JSONParser
{
    public enum TokenType
    {
        SingleQuotedString,
        DoubleQuotedString,
        LiteralNumber,

        ReservedWordNull,

        PunctComma,
        PunctColon,
        PunctPeriod,
        PunctLeftSquareBracket,
        PunctRightSquareBracket,
        PunctLeftCurlyBrace,
        PunctRightCurlyBrace
    }
}
