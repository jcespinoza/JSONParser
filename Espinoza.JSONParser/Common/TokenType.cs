namespace Espinoza.JSONParser
{
    public enum TokenType
    {
        SingleQuotedString,
        DoubleQuotedString,
        NumberLiteral,

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
