using System.Collections.Generic;

namespace Espinoza.JSONParser
{
    public interface ISourceCodeReader
    {
        /// <summary>
        /// The 1-based index of the current Line
        /// </summary>
        int CurrentLine { get; }

        /// <summary>
        /// The 1-based index of the current Column
        /// </summary>
        int CurrentColumn { get; }

        /// <summary>
        /// The 0-based index of the current symbol
        /// </summary>
        int CurrentPointer { get; }

        /// <summary>
        /// The symbol at the current pointer position
        /// </summary>
        char CurrentSymbol { get; }

        /// <summary>
        /// Gets the next available symbol from the source code
        /// </summary>
        /// <returns>The character under the current pointer</returns>
        char ReadNextSymbol();

        /// <summary>
        /// Gets the next available symbol without moving the pointer
        /// </summary>
        /// <returns>The character under the current pointer</returns>
        char PreviewNextSymbol();

        /// <summary>
        /// Gets the next available symbols without movint the pointer
        /// </summary>
        /// <returns>The <paramref name="quantity"/> characters after the current pointer</returns>
        List<char> PreviewNextSymbols(int quantity);
    }
}