using Espinoza.JSONParser.Lexicon;
using System;
using System.IO;

namespace Espinoza.JSONParser.SusyConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            TextReader textReader = new StreamReader(@"test.json");
            var sourceCode = textReader.ReadToEnd();

            var sourceCodeReader = new SourceCodeReader(sourceCode);

            var lexer = new Lexer(sourceCodeReader);


            Token token;
            Console.WriteLine("\t Generating Lexical Tokens...");
            do
            {
                token = lexer.GetNextToken();

                Console.WriteLine(string.Format("{0}", token));
            }
            while (token.TokenType != TokenType.EndOfFile);

            Console.WriteLine("\n\t Parsing Syntax...");

            ExecuteSyntaxTest(new Lexer(new SourceCodeReader(sourceCode)));

            Console.WriteLine("\n Syntax Analysis Complete. Validation Passed");

            Console.ReadKey();
        }

        private static void ExecuteSyntaxTest(Lexer lexer)
        {
            var analyzer = new SyntaxAnalyzer(lexer);
            analyzer.Parse();
        }
    }
}
