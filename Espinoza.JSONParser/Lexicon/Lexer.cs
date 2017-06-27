using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Espinoza.JSONParser.Lexicon
{
    public class Lexer
    {
        private ISourceCodeReader _sourceCodeProvider;
        private readonly Dictionary<string, TokenType> ReservedKeywords;
        private readonly Dictionary<char, TokenType> PunctuationSymbols;
        private readonly Dictionary<char, Func<char, int, int, Token>> TriggerSymbols;

        public Lexer(ISourceCodeReader sourceCode)
        {
            _sourceCodeProvider = sourceCode;

            ReservedKeywords = GetReservedKeywordsDictionary();

            PunctuationSymbols = GetPunctuationSymbolsDictionary();
            
            TriggerSymbols = BuildTriggerSymbolsFunctionsDictionary();
        }

        private Dictionary<char, Func<char, int, int, Token>> BuildTriggerSymbolsFunctionsDictionary()
        {
            throw new NotImplementedException();
        }

        private Dictionary<char, TokenType> GetPunctuationSymbolsDictionary()
        {
            var punctuationSymbolsDictionary = new Dictionary<char, TokenType>();

            punctuationSymbolsDictionary.Add(SusyConstants.Comma, TokenType.PunctComma);
            punctuationSymbolsDictionary.Add(SusyConstants.Colon, TokenType.PunctColon);
            punctuationSymbolsDictionary.Add(SusyConstants.Period, TokenType.PunctPeriod);
            punctuationSymbolsDictionary.Add(SusyConstants.LeftSquareBracket, TokenType.PunctLeftSquareBracket);
            punctuationSymbolsDictionary.Add(SusyConstants.RightSquareBracket, TokenType.PunctRightSquareBracket);
            punctuationSymbolsDictionary.Add(SusyConstants.LeftCurlyBrace, TokenType.PunctLeftCurlyBrace);
            punctuationSymbolsDictionary.Add(SusyConstants.RightCurlyBrace, TokenType.PunctRightCurlyBrace);
            return punctuationSymbolsDictionary;
        }

        private Dictionary<string, TokenType> GetReservedKeywordsDictionary()
        {
            var reservedKeywords = new Dictionary<string, TokenType>();
            reservedKeywords.Add(SusyConstants.NullKeyword, TokenType.ReservedWordNull);
            return reservedKeywords;
        }
    }
}
