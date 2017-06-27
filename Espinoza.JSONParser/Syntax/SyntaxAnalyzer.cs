using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Espinoza.JSONParser
{
    public class SyntaxAnalyzer
    {
        private readonly ILexer Lexer;
        public Token CurrentToken { get; private set; }

        public SyntaxAnalyzer(ILexer lexer)
        {
            Lexer = lexer;
        }

        public void Parse()
        {
            ConsumeToken();

            ParseFileContent();

            if (!EndOfFileHasBeenReached())
            {
                throw BuildUnexpectedTokenException(TokenType.EndOfFile);
            }
        }

        private void ParseFileContent()
        {
            if (CurrentToken.Is(TokenType.PunctLeftSquareBracket)){
                ParseObjectArray();
            }else
            {
                ParseSingleObject();
            }
        }

        private void ParseSingleObject()
        {
            if (CurrentToken.Is(TokenType.ReservedWordNull))
            {
                ConsumeToken();
            }else if (CurrentToken.Is(TokenType.DoubleQuotedString))
            {
                ConsumeToken();
            }else if (CurrentToken.Is(TokenType.LiteralNumber))
            {
                ConsumeToken();
            }else if (CurrentToken.Is(TokenType.PunctLeftCurlyBrace))
            {
                ConsumeToken();

                if (CurrentToken.IsNot(TokenType.PunctRightCurlyBrace))
                {
                    ParseKeyValuePairs();
                }

                ParseMandatoryToken(TokenType.PunctRightCurlyBrace);
            }else
            {
                throw new SyntaxException("Unexpected Token " + CurrentToken);
            }
        }

        private void ParseKeyValuePairs()
        {
            ParseMandatoryToken(TokenType.DoubleQuotedString);

            ParseMandatoryToken(TokenType.PunctColon);

            ParseSingleObject();

            ParseMoreKeyValuePairs();
        }

        private void ParseMoreKeyValuePairs()
        {
            if (CurrentToken.Is(TokenType.PunctComma))
            {
                ParseKeyValuePairs();
            }else
            {
                //No more key-value pairs
            }
        }

        private void ParseObjectArray()
        {
            ParseMandatoryToken(TokenType.PunctLeftSquareBracket);

            if (CurrentToken.IsNot(TokenType.PunctRightCurlyBrace))
            {
                ParseSingleObject();
                ParseMoreValues();
            }

            ParseMandatoryToken(TokenType.PunctRightSquareBracket);
        }

        private void ParseMoreValues()
        {
            if (CurrentToken.Is(TokenType.PunctComma))
            {
                ParseSingleObject();
            }else
            {
                // There are no more values in the array
            }
        }

        private Token ConsumeToken()
        {
            var oldToken = CurrentToken;
            CurrentToken = Lexer.GetNextToken();
            return oldToken;
        }

        private bool EndOfFileHasBeenReached()
        {
            return CurrentToken.Is(TokenType.EndOfFile);
        }

        private Token ParseMandatoryToken(TokenType expectedTokenType)
        {
            if (CurrentToken.IsNot(expectedTokenType))
            {
                throw BuildUnexpectedTokenException(expectedTokenType);
            }
            return ConsumeToken();
        }

        private Exception BuildColumnLineException(string message)
        {
            throw BuildSyntaxException(message, CurrentToken.Column, CurrentToken.Line);
        }

        private Exception BuildUnexpectedTokenException(TokenType expectedTokenType)
        {
            return BuildSyntaxException(SusyConstants.MessageUnexpectedToken, CurrentToken.Column, CurrentToken.Line, expectedTokenType, CurrentToken.Lexemme);
        }

        private Exception BuildSyntaxException(string message, object arg1, params object[] args)
        {
            var actualArgs = args.ToList();
            actualArgs.Insert(0, arg1);
            var actualMessage = string.Format(message, actualArgs.ToArray());
            return new SyntaxException(message);
        }
    }
}
