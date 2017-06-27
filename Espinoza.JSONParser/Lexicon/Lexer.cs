﻿using System;
using System.Collections.Generic;

namespace Espinoza.JSONParser.Lexicon
{
    public class Lexer
    {
        private ISourceCodeReader _sourceCodeProvider;
        private readonly Dictionary<string, TokenType> ReservedKeywords;
        private readonly Dictionary<char, TokenType> PunctuationSymbols;
        private readonly Dictionary<char, Func<char, int, int, Token>> TriggerSymbols;

        private bool HasPendingSymbol { get; set; }
        private char PendingSymbol { get; set; }

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

        public Token GetNextToken()
        {
            ConsumeWhitespace();

            char nextSymbol = GetNextSymbol();
            var line = _sourceCodeProvider.CurrentLine;
            var column = _sourceCodeProvider.CurrentColumn;

            if (TriggerSymbols.ContainsKey(nextSymbol))
            {
                return TriggerSymbols[nextSymbol](nextSymbol, line, column);
            }

            if (char.IsDigit(nextSymbol))
            {
                return ParseNumberLiteral(nextSymbol, line, column);
            }

            if (PunctuationSymbols.ContainsKey(nextSymbol))
            {
                return BuildPunctuationSymbol(nextSymbol, line, column);
            }

            throw BuildExceptionDueToUnexpectedSymbol(nextSymbol);
        }

        private void ConsumeWhitespace()
        {
            char nextSymbol;
            while (true)
            {
                if (HasPendingSymbol)
                {
                    if (char.IsWhiteSpace(PendingSymbol) || PendingSymbol == SusyConstants.NewLine)
                    {
                        HasPendingSymbol = false;
                        continue;
                    }
                    nextSymbol = PendingSymbol;
                }
                else
                {
                    nextSymbol = _sourceCodeProvider.PreviewNextSymbol();
                }

                if (char.IsWhiteSpace(nextSymbol) || nextSymbol == SusyConstants.NewLine)
                {
                    nextSymbol = _sourceCodeProvider.ReadNextSymbol();
                }
                else
                {
                    break;
                }
            }
        }

        private char GetNextSymbol()
        {
            if (HasPendingSymbol)
            {
                HasPendingSymbol = false;
                return PendingSymbol;
            }
            return _sourceCodeProvider.ReadNextSymbol();
        }

        private Token ParseNumberLiteral(char currentSymbol, int line, int column)
        {
            var lexemme = string.Empty;
            while (char.IsDigit(currentSymbol))
            {
                lexemme += currentSymbol;
                currentSymbol = _sourceCodeProvider.ReadNextSymbol();
            }
            if (!char.IsWhiteSpace(currentSymbol))
            {
                if (currentSymbol == SusyConstants.Period)
                {
                    lexemme += currentSymbol;
                    return ParseDoubleLiteral(lexemme, line, column);
                }
                AccumulateSymbol(currentSymbol);
            }
            return BuildToken(lexemme, TokenType.LiteralNumber, line, column);
        }

        private Token ParseDoubleLiteral(string lexemme, int line, int column)
        {
            var nextSymbol = _sourceCodeProvider.ReadNextSymbol();
            while (char.IsDigit(nextSymbol))
            {
                lexemme += nextSymbol;
                nextSymbol = _sourceCodeProvider.ReadNextSymbol();
            }

            AccumulateSymbol(nextSymbol);
            return BuildToken(lexemme, TokenType.LiteralNumber, line, column);
        }

        private Token BuildPunctuationSymbol(char symbol, int line, int column)
        {
            var tokenType = PunctuationSymbols[symbol];
            return BuildToken(symbol.ToString(), tokenType, line, column);
        }

        private Token BuildToken(string lexemme, TokenType tokenType, int lineNumber, int columnNumber)
        {
            return new Token
            {
                Lexemme = lexemme,
                TokenType = tokenType,
                Column = columnNumber,
                Line = lineNumber
            };
        }

        private void AccumulateSymbol(char nextSymbol)
        {
            HasPendingSymbol = true;
            PendingSymbol = nextSymbol;
        }

        private Exception BuildExceptionDueToUnexpectedSymbol(char nextSymbol)
        {
            return new Exception(string.Format("Unexpected symbol '{0}' encountered at Line {1}, Col {2}",
                                                nextSymbol, _sourceCodeProvider.CurrentLine, _sourceCodeProvider.CurrentColumn));
        }
    }
}
