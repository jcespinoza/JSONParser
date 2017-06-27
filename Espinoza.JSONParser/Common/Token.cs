namespace Espinoza.JSONParser
{
    public class Token
    {
        public int Column { get; set; }

        public string Lexemme { get; set; }

        public int Line { get; set; }

        public TokenType TokenType { get; set; }

        public override bool Equals(object otherObject)
        {
            // If parameter is null return false.
            if (otherObject == null)
            {
                return false;
            }

            // If parameter cannot be cast to Token return false.
            Token castedObject = otherObject as Token;
            if (castedObject == null)
            {
                return false;
            }

            var comparison = (Column == castedObject.Column) &&
                (Line == castedObject.Line) &&
                (Lexemme == castedObject.Lexemme) &&
                (TokenType == castedObject.TokenType);
            return comparison;
        }

        public bool Equals(Token otherToken)
        {
            // If parameter is null return false:
            if (otherToken == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (Column == otherToken.Column) &&
                (Line == otherToken.Line) &&
                (Lexemme == otherToken.Lexemme) &&
                (TokenType == otherToken.TokenType);
        }

        public override int GetHashCode()
        {
            return (Column.GetHashCode() + Line.GetHashCode()) ^ (Lexemme.GetHashCode() + TokenType.GetHashCode());
        }

        public static bool operator ==(Token oneToken, Token anotherToken)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(oneToken, anotherToken))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)oneToken == null) || ((object)anotherToken == null))
            {
                return false;
            }

            // Return true if the fields match:
            return (oneToken.Column == anotherToken.Column) &&
                (oneToken.Line == anotherToken.Line) &&
                (oneToken.Lexemme == anotherToken.Lexemme) &&
                (oneToken.TokenType == anotherToken.TokenType);
        }

        public static bool operator !=(Token a, Token b)
        {
            return !(a == b);
        }

        public override string ToString()
        {
            return string.Format("{0} {1} at Ln {2}, Col {3}", TokenType, Lexemme, Line, Column);
        }
    }
}
