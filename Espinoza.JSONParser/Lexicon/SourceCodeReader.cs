using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Espinoza.JSONParser.Lexicon
{
    public class SourceCodeReader
    {
        private readonly string _sourceCode;

        /// <summary>
        /// Tells if a new line character was found
        /// </summary>
        private bool IsReadyToJumpLine { get; set; }

        public int CurrentColumn { get; private set; }

        public int CurrentLine { get; private set; }

        public int CurrentPointer { get; private set; }

        public char CurrentSymbol { get; private set; }

        public SourceCodeReader(string sourceCodeText)
        {
            _sourceCode = GetSanitizedSource(sourceCodeText);

            InitializeCounters();

            CurrentSymbol = SusyConstants.EndOfFile;
        }

        /// <summary>
        /// Eliminates mixed line separators and replaces them by the standard New Line character
        /// </summary>
        /// <param name="sourceCodeText">The source code to sanitize</param>
        /// <returns>The sanitized source code</returns>
        private string GetSanitizedSource(string sourceCodeText)
        {
            if (sourceCodeText == null)
            {
                return string.Empty;
            }

            return sourceCodeText.GetNewLineCleanString();
        }

        /// <summary>
        /// Initializes the Line, Column and Pointer counters
        /// </summary>
        private void InitializeCounters()
        {
            CurrentLine = 0;

            if (_sourceCode.Length > 0)
            {
                CurrentLine = 1;
            }

            CurrentColumn = 0;
            CurrentPointer = 0;
        }

        public char ReadNextSymbol()
        {
            if (CurrentPointer < _sourceCode.Length)
            {
                CurrentSymbol = _sourceCode[CurrentPointer];
                IncrementCounters();
                return CurrentSymbol;
            }
            return SusyConstants.EndOfFile;
        }

        public char PreviewNextSymbol()
        {
            if (CurrentPointer < _sourceCode.Length)
            {
                return _sourceCode[CurrentPointer];
            }
            return SusyConstants.EndOfFile;
        }

        public List<char> PreviewNextSymbols(int quantity)
        {
            var resultList = new List<char>();
            for (int i = 0; i < quantity; i++)
            {
                if ((CurrentPointer + i) < _sourceCode.Length)
                {
                    resultList.Add(_sourceCode[CurrentPointer + i]);
                }
                else
                {
                    resultList.Add(SusyConstants.EndOfFile);
                }
            }
            return resultList;
        }

        /// <summary>
        /// Handles the logic to increase the Line and Column counters
        /// </summary>
        private void IncrementCounters()
        {
            CurrentColumn++;
            CurrentPointer++;

            HandleLineJump();
        }

        /// <summary>
        /// Handles the logic to increase the Line number and reset the Column counter
        /// </summary>
        private void HandleLineJump()
        {
            if (CurrentSymbol == SusyConstants.NewLine && IsReadyToJumpLine)
            {
                ResetColumnAndSetLineJumpReadyness(true);
                return;
            }
            else if (CurrentSymbol == SusyConstants.NewLine)
            {
                IsReadyToJumpLine = true;
                return;
            }

            if (IsReadyToJumpLine)
            {
                ResetColumnAndSetLineJumpReadyness(false);
            }
        }

        private void ResetColumnAndSetLineJumpReadyness(bool jumpLine)
        {
            IsReadyToJumpLine = jumpLine;
            CurrentColumn = 1;
            CurrentLine++;
        }
    }

}
