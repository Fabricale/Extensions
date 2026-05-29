// *****************************************************************************
// Copyright (c) Fabricale(TM)
// Licensed under the Apache License, Version 2.0
// *****************************************************************************

#pragma warning disable IDE0059 // Unnecessary assignment of a value

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fabricale.Extensions;

/// <summary>
/// Provides Extension Methods for the <see cref="System.String"/> class
/// </summary>
public static class StringExtensions
{
    // ================================================================================
    // Find String in String
    // ================================================================================

    /// <summary>
    /// Finds all the positions of a string inside another string
    /// </summary>
    /// <param name="originalString">The original string</param>
    /// <param name="stringToFind">The string to find</param>
    /// <remarks>The search will be done using the <see cref="StringComparison.OrdinalIgnoreCase"/> option</remarks>
    /// <returns>A <see cref="Dictionary{TKey, TValue}"/> keyed by the position where the text is found</returns>
    public static IDictionary<int, FoundLocation> Find(this string originalString, string stringToFind)
    {
        return Find(originalString, StringComparison.OrdinalIgnoreCase, stringToFind);
    }

    /// <summary>
    /// Finds all the positions of a string inside another string
    /// </summary>
    /// <param name="originalString">The original string</param>
    /// <param name="comparisonType">A flag to define how the comparison should be made</param>
    /// <param name="stringToFind">The string to find</param>
    /// <returns>A <see cref="Dictionary{TKey, TValue}"/> keyed by the position where the text is found</returns>
    public static IDictionary<int, FoundLocation> Find(this string originalString, StringComparison comparisonType, string stringToFind)
    {
        // A sorted dictionary representing the location where each instance of any text was found
        var dictionaryOfReplacements = new SortedDictionary<int, FoundLocation>();

        int index = 0;

        while ((index = originalString.IndexOf(stringToFind, index, comparisonType)) != -1)
        {
            dictionaryOfReplacements.Add(index, new FoundLocation(0, index, index + stringToFind.Length));
            index += stringToFind.Length;
        }

        return dictionaryOfReplacements;
    }

    // ================================================================================
    // Replace String in String
    // ================================================================================

    // *********************************************
    // **** BEGIN: CONSTRUCTOR WITH 1 PARAMETER ****
    // *********************************************

    /// <summary>
    /// Finds and Replaces multiple strings at the same time
    /// </summary>
    /// <param name="originalString">The original string</param>
    /// <param name="stringToFind">The string to be replaced</param>
    /// <param name="replacementString">The replacement string</param>
    /// <returns>A <see cref="string"/> containing the original string with the replaced contents</returns>
    public static string MultiReplace(this string originalString, string stringToFind, string replacementString)
    {
        return MultiReplace(originalString, new MultiReplaceOptions(stringToFind, replacementString));
    }

    /// <summary>
    /// Finds and Replaces multiple strings at the same time
    /// </summary>
    /// <param name="originalString">The original string</param>
    /// <param name="comparisonType">A flag to define how the comparison should be made</param>
    /// <param name="stringToFind">The string to be replaced</param>
    /// <param name="replacementString">The replacement string</param>
    /// <returns>A <see cref="string"/> containing the original string with the replaced contents</returns>
    public static string MultiReplace(this string originalString, StringComparison comparisonType, string stringToFind, string replacementString)
    {
        return MultiReplace(originalString, comparisonType, new MultiReplaceOptions(stringToFind, replacementString));
    }

    // **********************************************
    // **** BEGIN: CONSTRUCTOR WITH 2 PARAMETERS ****
    // **********************************************

    /// <summary>
    /// Finds and Replaces multiple strings at the same time
    /// </summary>
    /// <param name="originalString">The original string</param>
    /// <param name="stringToFind01">The first string to find</param>
    /// <param name="replacementString01">The replacement for the <paramref name="stringToFind01"/></param>
    /// <param name="stringToFind02">The second string to find</param>
    /// <param name="replacementString02">The replacement for the <paramref name="stringToFind02"/></param>
    /// <returns>A <see cref="string"/> containing the original string with the replaced contents</returns>
    public static string MultiReplace(this string originalString, string stringToFind01, string replacementString01,
                                                                  string stringToFind02, string replacementString02)
    {
        return MultiReplace(originalString, StringComparison.OrdinalIgnoreCase, new MultiReplaceOptions(stringToFind01, replacementString01),
                                                                                new MultiReplaceOptions(stringToFind02, replacementString02));
    }

    /// <summary>
    /// Finds and Replaces multiple strings at the same time
    /// </summary>
    /// <param name="originalString">The original string</param>
    /// <param name="comparisonType">A flag to define how the comparison should be made</param>
    /// <param name="stringToFind01">The first string to find</param>
    /// <param name="replacementString01">The replacement for the <paramref name="stringToFind01"/></param>
    /// <param name="stringToFind02">The second string to find</param>
    /// <param name="replacementString02">The replacement for the <paramref name="stringToFind02"/></param>
    /// <returns>A <see cref="string"/> containing the original string with the replaced contents</returns>
    public static string MultiReplace(this string originalString, StringComparison comparisonType, string stringToFind01, string replacementString01,
                                                                                                   string stringToFind02, string replacementString02)
    {
        return MultiReplace(originalString, comparisonType, new MultiReplaceOptions(stringToFind01, replacementString01),
                                                            new MultiReplaceOptions(stringToFind02, replacementString02));
    }

    // **********************************************
    // **** BEGIN: CONSTRUCTOR WITH 3 PARAMETERS ****
    // **********************************************

    /// <summary>
    /// Finds and Replaces multiple strings at the same time
    /// </summary>
    /// <param name="originalString">The original string</param>
    /// <param name="stringToFind01">The first string to find</param>
    /// <param name="replacementString01">The replacement for the <paramref name="stringToFind01"/></param>
    /// <param name="stringToFind02">The second string to find</param>
    /// <param name="replacementString02">The replacement for the <paramref name="stringToFind02"/></param>
    /// <param name="stringToFind03">The third string to find</param>
    /// <param name="replacementString03">The replacement for the <paramref name="stringToFind03"/></param>
    /// <returns>A <see cref="string"/> containing the original string with the replaced contents</returns>
    public static string MultiReplace(this string originalString, string stringToFind01, string replacementString01,
                                                                  string stringToFind02, string replacementString02,
                                                                  string stringToFind03, string replacementString03)
    {
        return MultiReplace(originalString, StringComparison.OrdinalIgnoreCase, new MultiReplaceOptions(stringToFind01, replacementString01),
                                                                                new MultiReplaceOptions(stringToFind02, replacementString02),
                                                                                new MultiReplaceOptions(stringToFind03, replacementString03));
    }

    /// <summary>
    /// Finds and Replaces multiple strings at the same time
    /// </summary>
    /// <param name="originalString">The original string</param>
    /// <param name="comparisonType">A flag to define how the comparison should be made</param>
    /// <param name="stringToFind01">The first string to find</param>
    /// <param name="replacementString01">The replacement for the <paramref name="stringToFind01"/></param>
    /// <param name="stringToFind02">The second string to find</param>
    /// <param name="replacementString02">The replacement for the <paramref name="stringToFind02"/></param>
    /// <param name="stringToFind03">The third string to find</param>
    /// <param name="replacementString03">The replacement for the <paramref name="stringToFind03"/></param>
    /// <returns>A <see cref="string"/> containing the original string with the replaced contents</returns>
    public static string MultiReplace(this string originalString, StringComparison comparisonType, string stringToFind01, string replacementString01,
                                                                                                   string stringToFind02, string replacementString02,
                                                                                                   string stringToFind03, string replacementString03)
    {
        return MultiReplace(originalString, comparisonType, new MultiReplaceOptions(stringToFind01, replacementString01),
                                                            new MultiReplaceOptions(stringToFind02, replacementString02),
                                                            new MultiReplaceOptions(stringToFind03, replacementString03));
    }

    // **********************************************
    // **** BEGIN: CONSTRUCTOR WITH 4 PARAMETERS ****
    // **********************************************

    /// <summary>
    /// Finds and Replaces multiple strings at the same time
    /// </summary>
    /// <param name="originalString">The original string</param>
    /// <param name="stringToFind01">The first string to find</param>
    /// <param name="replacementString01">The replacement for the <paramref name="stringToFind01"/></param>
    /// <param name="stringToFind02">The second string to find</param>
    /// <param name="replacementString02">The replacement for the <paramref name="stringToFind02"/></param>
    /// <param name="stringToFind03">The third string to find</param>
    /// <param name="replacementString03">The replacement for the <paramref name="stringToFind03"/></param>
    /// <param name="stringToFind04">The fourth string to find</param>
    /// <param name="replacementString04">The replacement for the <paramref name="stringToFind04"/></param>
    /// <returns>A <see cref="string"/> containing the original string with the replaced contents</returns>
    public static string MultiReplace(this string originalString, string stringToFind01, string replacementString01,
                                                                  string stringToFind02, string replacementString02,
                                                                  string stringToFind03, string replacementString03,
                                                                  string stringToFind04, string replacementString04)
    {
        return MultiReplace(originalString, StringComparison.OrdinalIgnoreCase, new MultiReplaceOptions(stringToFind01, replacementString01),
                                                                                new MultiReplaceOptions(stringToFind02, replacementString02),
                                                                                new MultiReplaceOptions(stringToFind03, replacementString03),
                                                                                new MultiReplaceOptions(stringToFind04, replacementString04));
    }

    /// <summary>
    /// Finds and Replaces multiple strings at the same time
    /// </summary>
    /// <param name="originalString">The original string</param>
    /// <param name="comparisonType">A flag to define how the comparison should be made</param>
    /// <param name="stringToFind01">The first string to find</param>
    /// <param name="replacementString01">The replacement for the <paramref name="stringToFind01"/></param>
    /// <param name="stringToFind02">The second string to find</param>
    /// <param name="replacementString02">The replacement for the <paramref name="stringToFind02"/></param>
    /// <param name="stringToFind03">The third string to find</param>
    /// <param name="replacementString03">The replacement for the <paramref name="stringToFind03"/></param>
    /// <param name="stringToFind04">The fourth string to find</param>
    /// <param name="replacementString04">The replacement for the <paramref name="stringToFind04"/></param>
    /// <returns>A <see cref="string"/> containing the original string with the replaced contents</returns>
    public static string MultiReplace(this string originalString, StringComparison comparisonType, string stringToFind01, string replacementString01,
                                                                                                   string stringToFind02, string replacementString02,
                                                                                                   string stringToFind03, string replacementString03,
                                                                                                   string stringToFind04, string replacementString04)
    {
        return MultiReplace(originalString, comparisonType, new MultiReplaceOptions(stringToFind01, replacementString01),
                                                            new MultiReplaceOptions(stringToFind02, replacementString02),
                                                            new MultiReplaceOptions(stringToFind03, replacementString03),
                                                            new MultiReplaceOptions(stringToFind04, replacementString04));
    }

    // **********************************************
    // **** BEGIN: CONSTRUCTOR WITH 5 PARAMETERS ****
    // **********************************************

    /// <summary>
    /// Finds and Replaces multiple strings at the same time
    /// </summary>
    /// <param name="originalString">The original string</param>
    /// <param name="stringToFind01">The first string to find</param>
    /// <param name="replacementString01">The replacement for the <paramref name="stringToFind01"/></param>
    /// <param name="stringToFind02">The second string to find</param>
    /// <param name="replacementString02">The replacement for the <paramref name="stringToFind02"/></param>
    /// <param name="stringToFind03">The third string to find</param>
    /// <param name="replacementString03">The replacement for the <paramref name="stringToFind03"/></param>
    /// <param name="stringToFind04">The fourth string to find</param>
    /// <param name="replacementString04">The replacement for the <paramref name="stringToFind04"/></param>
    /// <param name="stringToFind05">The fifth string to find</param>
    /// <param name="replacementString05">The replacement for the <paramref name="stringToFind05"/></param>
    /// <returns>A <see cref="string"/> containing the original string with the replaced contents</returns>
    public static string MultiReplace(this string originalString, string stringToFind01, string replacementString01,
                                                                  string stringToFind02, string replacementString02,
                                                                  string stringToFind03, string replacementString03,
                                                                  string stringToFind04, string replacementString04,
                                                                  string stringToFind05, string replacementString05)
    {
        return MultiReplace(originalString, StringComparison.OrdinalIgnoreCase, new MultiReplaceOptions(stringToFind01, replacementString01),
                                                                                new MultiReplaceOptions(stringToFind02, replacementString02),
                                                                                new MultiReplaceOptions(stringToFind03, replacementString03),
                                                                                new MultiReplaceOptions(stringToFind04, replacementString04),
                                                                                new MultiReplaceOptions(stringToFind05, replacementString05));
    }

    /// <summary>
    /// Finds and Replaces multiple strings at the same time
    /// </summary>
    /// <param name="originalString">The original string</param>
    /// <param name="comparisonType">A flag to define how the comparison should be made</param>
    /// <param name="stringToFind01">The first string to find</param>
    /// <param name="replacementString01">The replacement for the <paramref name="stringToFind01"/></param>
    /// <param name="stringToFind02">The second string to find</param>
    /// <param name="replacementString02">The replacement for the <paramref name="stringToFind02"/></param>
    /// <param name="stringToFind03">The third string to find</param>
    /// <param name="replacementString03">The replacement for the <paramref name="stringToFind03"/></param>
    /// <param name="stringToFind04">The fourth string to find</param>
    /// <param name="replacementString04">The replacement for the <paramref name="stringToFind04"/></param>
    /// <param name="stringToFind05">The fifth string to find</param>
    /// <param name="replacementString05">The replacement for the <paramref name="stringToFind05"/></param>
    /// <returns>A <see cref="string"/> containing the original string with the replaced contents</returns>
    public static string MultiReplace(this string originalString, StringComparison comparisonType, string stringToFind01, string replacementString01,
                                                                                                   string stringToFind02, string replacementString02,
                                                                                                   string stringToFind03, string replacementString03,
                                                                                                   string stringToFind04, string replacementString04,
                                                                                                   string stringToFind05, string replacementString05)
    {
        return MultiReplace(originalString, comparisonType, new MultiReplaceOptions(stringToFind01, replacementString01),
                                                            new MultiReplaceOptions(stringToFind02, replacementString02),
                                                            new MultiReplaceOptions(stringToFind03, replacementString03),
                                                            new MultiReplaceOptions(stringToFind04, replacementString04),
                                                            new MultiReplaceOptions(stringToFind05, replacementString05));
    }

    // ***************************************************
    // **** END: CONSTRUCTOR WITH MULTIPLE PARAMETERS ****
    // ***************************************************

    /// <summary>
    /// Finds and Replaces multiple strings at the same time
    /// </summary>
    /// <param name="originalString">The original string</param>
    /// <param name="options">An array containing the instructions for the find/replace operation</param>
    /// <returns>A <see cref="string"/> containing the original string with the replaced contents</returns>
    public static string MultiReplace(this string originalString, params MultiReplaceOptions[] options)
    {
        return MultiReplace(originalString, StringComparison.OrdinalIgnoreCase, options);
    }

    /// <summary>
    /// Finds and Replaces multiple strings at the same time
    /// </summary>
    /// <param name="originalString">The original string</param>
    /// <param name="comparisonType">A flag to define how the comparison should be made</param>
    /// <param name="options">An array containing the instructions for the find/replace operation</param>
    /// <returns>A <see cref="string"/> containing the original string with the replaced contents</returns>
    public static string MultiReplace(this string originalString, StringComparison comparisonType, params MultiReplaceOptions[] options)
    {
        // A sorted dictionary representing the location where each instance of any text was found
        var dictionaryOfReplacements = new SortedDictionary<int, FoundLocation>();


        int currentTextSizeDifference = 0;                      // Store the difference between the current text and the replacement text
        int bufferSize = originalString.Length;                 // Store the size of the string buffer, to prevent memory reallocation

        // Map Locations where the replacements have to happen
        for (int iStructure = 0; iStructure < options.Length; iStructure++)
        {
            int index = 0;

            currentTextSizeDifference = options[iStructure].ReplacementString.Length - options[iStructure].StringToFind.Length;

            while ((index = originalString.IndexOf(options[iStructure].StringToFind, index, comparisonType)) != -1)
            {
                dictionaryOfReplacements.Add(index, new FoundLocation(iStructure, index, index + options[iStructure].StringToFind.Length));
                bufferSize += currentTextSizeDifference;
                index += options[iStructure].StringToFind.Length;
            }
        }

        // Make sure there are replacements to do
        if (dictionaryOfReplacements.Count == 0)
            return originalString;

        // Perform Replacements
        using var enumerator = dictionaryOfReplacements.GetEnumerator();
        bool enumeratorIsValid = enumerator.MoveNext();

        if (!enumeratorIsValid)
            return originalString;

        // Create the String Builder with the final size
        var sb = new StringBuilder(bufferSize);

        int iRead = 0;

        while (iRead < originalString.Length)
        {
            if (enumeratorIsValid && enumerator.Current.Key == iRead)
            {
                sb.Append(options[enumerator.Current.Value.IndexOfTerm].ReplacementString);
                iRead = enumerator.Current.Value.EndPosition - 1;
                enumeratorIsValid = enumerator.MoveNext();
            }
            else
            {
                sb.Append(originalString[iRead]);
            }

            iRead++;
        }

        return sb.ToString();
    }

    // ================================================================================
    // Contains Only
    // ================================================================================

    /// <summary>
    /// Checks if a string only contain certain characters
    /// </summary>
    /// <param name="input">Reference to the original string</param>
    /// <param name="allowedCharacters">The acceptable characters</param>
    /// <param name="ignoreCase">Defines whether the case is taken into consideration or not</param>
    /// <returns>True if the string only contains the characters defined at <paramref name="allowedCharacters"/>. False if it contains more characters than the accepted.</returns>
    public static bool ContainsOnly(this string input, string allowedCharacters, bool ignoreCase = false)
    {
        // Set the Comparer for case sensitive / insensitive
        var comparer = ignoreCase ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal;

        // Setup the HashSet of valid strings (cannot do it with char, StringComparer does not work on it)
        //var allowedSet = new HashSet<string>(allowedCharacters.Select(c => c.ToString()), comparer);
        var allowedSet = ignoreCase ? new HashSet<char>(allowedCharacters, CharComparer.CaseInsensitive)
                                    : new HashSet<char>(allowedCharacters, CharComparer.CaseSensitive);

        return ContainsOnly(input, allowedSet);
    }

    /// <summary>
    /// Checks if a string only contains certain characters
    /// </summary>
    /// <param name="input">Reference to the original string</param>
    /// <param name="allowedCharactersHashSet">The HashSet of characters to search on</param>
    /// <returns>True if the string only contains the characters defined at <paramref name="allowedCharactersHashSet"/>. False if it contains more characters than the accepted.</returns>
    /// <remarks>Use this method in case you need to reuse the same HashSet multiple times</remarks>
    public static bool ContainsOnly(this string input, HashSet<char> allowedCharactersHashSet)
    {
        // Check each character in the input
        foreach (var c in input)
        {
            if (!allowedCharactersHashSet.Contains(c))
                return false;
        }

        return true;
    }

    /// <summary>
    /// Checks if a string only contain numbers
    /// </summary>
    /// <param name="input">Reference to the input string</param>
    /// <returns>True if the string only contains numbers. False if there are other characters in the string.</returns>
    public static bool ContainsOnlyNumbers(this string input)
    {
        // Check each character in the input
        foreach (var c in input)
        {
            if (c < '0' || c > '9')
                return false;
        }

        return true;
    }

    // ================================================================================
    // Contains Only (ASCII Performance Implementation)
    // ================================================================================

    // When only searching for ASCII characters, there is no need to use a HashSet<char>.
    // It's better to have an array with 128 bools to define if the char is allowed or not. It removes the cost of hashing.

    private const string ASCII_LETTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
    private static readonly bool[] ASCII_LettersArray = ASCII_LETTERS.ConvertToAsciiBooleanArray();

    private const string ASCII_LETTERS_AND_NUMBERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    private static readonly bool[] ASCII_LettersAndNumbersArray = ASCII_LETTERS_AND_NUMBERS.ConvertToAsciiBooleanArray();

    /// <summary>
    /// Checks if a string only contain ascii letters (case-insensitive)
    /// </summary>
    /// <param name="input">Reference to the input string</param>
    /// <returns>True if the string only contains Ascii letters. False if there are other characters in the string.</returns>
    public static bool ContainsOnlyAsciiLetters(this string input)
    {
        return ContainsOnly(input, ASCII_LettersArray);
    }

    /// <summary>
    /// Checks if a string only contains ascii letters and numbers  (case-insensitive)
    /// </summary>
    /// <param name="input">Reference to the input string</param>
    /// <returns>True if the string only contains Ascii letters or numbers. False if there are other characters in the string.</returns>
    public static bool ContainsOnlyAsciiLettersAndNumbers(this string input)
    {
        return ContainsOnly(input, ASCII_LettersAndNumbersArray);
    }

    /// <summary>
    /// Checks if a string only contains the characters defined in the input array (ASCII Only)
    /// </summary>
    /// <param name="input">Reference to the original string</param>
    /// <param name="asciiBooleanArray">A boolean array with 128 positions, each one representing one of the ascii characters</param>
    /// <returns>True if the string only contains the characters defined at <paramref name="asciiBooleanArray"/>. False if it contains more characters than the accepted.</returns>
    /// <remarks>Use this method in case you need to reuse the same boolean array multiple times. You can generate the boolean array by using the extension method <see cref="ConvertToAsciiBooleanArray(string)"/>.</remarks>
    public static bool ContainsOnly(this string input, bool[] asciiBooleanArray)
    {
        if (asciiBooleanArray.Length != 128)
            throw new ArgumentOutOfRangeException(nameof(asciiBooleanArray), $"The size of the boolean array is invalid. It should be \"128\", but it is \"{asciiBooleanArray.Length}\".");

        foreach (var c in input)
        {
            // Character is out of the boundaries
            if (c >= asciiBooleanArray.Length)
                throw new ArgumentOutOfRangeException(nameof(input), $"The character \"{c}\" is outside of the ASCII range");

            // Check if character is activated
            if (!asciiBooleanArray[c])
                return false;
        }

        return true;
    }

    /// <summary>
    /// Generates a boolean array with the ASCII characters inside the given string
    /// </summary>
    /// <param name="input">Referehcen to the original string</param>
    /// <returns>A boolean array containing the character codes and whether they are activated or not</returns>
    /// <remarks>This function will only process ASCII characters, from 0 to 127. Any character beyond this range will be ignored.</remarks>
    public static bool[] ConvertToAsciiBooleanArray(this string input)
    {
        var asciiBooleanArray = new bool[128];

        foreach (var c in input)
        {
            // Character is out of the boundaries
            if (c >= asciiBooleanArray.Length)
                throw new ArgumentOutOfRangeException(nameof(input), $"The character \"{c}\" is outside of the ASCII range");

            asciiBooleanArray[c] = true;
        }

        return asciiBooleanArray;
    }
}

#pragma warning restore IDE0059 // Unnecessary assignment of a value
