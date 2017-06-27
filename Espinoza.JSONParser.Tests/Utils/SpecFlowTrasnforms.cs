using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Espinoza.JSONParser.Tests
{
    [Binding]
    public class SpecFlowTrasnforms
    {
        [StepArgumentTransformation]
        public static Token ParseTokenFromTable(Table table)
        {
            var newToken = new Token
            {
                Lexemme = table.Rows[0]["Lexemme"],
                Column = int.Parse(table.Rows[0]["Column"]),
                Line = int.Parse(table.Rows[0]["Line"]),
                TokenType = (TokenType)Enum.Parse(typeof(TokenType), table.Rows[0]["TokenType"])
            };
            return newToken;
        }

        [StepArgumentTransformation]
        public static List<Token> ConvertTableToListOfTokens(Table tokenTable)
        {
            var tokenList = new List<Token>();
            foreach (var row in tokenTable.Rows)
            {
                var newToken = new Token
                {
                    Lexemme = row["Lexemme"],
                    Column = int.Parse(row["Column"]),
                    Line = int.Parse(row["Line"]),
                    TokenType = (TokenType)Enum.Parse(typeof(TokenType), row["TokenType"])
                };
                tokenList.Add(newToken);
            }
            return tokenList;
        }

        [StepArgumentTransformation(@"(.*)")]
        public TokenType ParseTokenTypeFromString(string tokenType)
        {
            return (TokenType)Enum.Parse(typeof(TokenType), tokenType);
        }

        [StepArgumentTransformation(@"(.*)")]
        public bool ParseBooleanFromString(string parameter)
        {
            if (parameter == null) return false;
            return parameter.ToLower() == "true";
        }
    }
}
