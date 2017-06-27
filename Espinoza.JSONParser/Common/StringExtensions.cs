namespace Espinoza.JSONParser
{
    public static class StringExtensions
    {
        public static string GetNewLineCleanString(this string inputString)
        {
            if (inputString == null)
            {
                return string.Empty;
            }

            var carriageReturnNewLinePattern = string.Empty
                                            + SusyConstants.CarriageReturn
                                            + SusyConstants.NewLine;

            var newLineString = string.Empty + SusyConstants.NewLine;

            var sourceWithNoCarriageNewLineCombination = inputString
                    .Replace(carriageReturnNewLinePattern, newLineString);

            return sourceWithNoCarriageNewLineCombination
                    .Replace(SusyConstants.CarriageReturn, SusyConstants.NewLine);
        }
    }
}
