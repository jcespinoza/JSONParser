namespace Espinoza.JSONParser
{
    public static class TokenExtensions
    {
        public static bool Is(this Token token, TokenType tokenType)
        {
            return token.TokenType == tokenType;
        }

        public static bool IsNot(this Token token, TokenType tokenType)
        {
            return !token.Is(tokenType);
        }
    }
}
