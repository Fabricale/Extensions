using System;
using System.Collections.Generic;
using System.Text;

namespace Fabricale.Extensions;

/// <summary>
/// Defines a Char Comparer that checks if two characters are the same (case-insensitive)
/// </summary>
public sealed class CaseInsensitiveCharComparer: CharComparer, IEqualityComparer<char>
{
    /// <summary>
    /// Compare two characters <b>(case insensitive)</b>
    /// </summary>
    /// <param name="x">The character</param>
    /// <param name="y">The character to compare to</param>
    /// <returns>True if the characters are the same. False if they are not.</returns>
    public override bool Equals(char x, char y)
    {
        return char.ToUpperInvariant(x) == char.ToUpperInvariant(y);
    }

    /// <summary>
    /// Compare two characters <b>(case insensitive)</b> and return an indication of their relative sort order
    /// </summary>
    /// <param name="x">The character</param>
    /// <param name="y">The character to compare to</param>
    /// <returns>A number indicating the relative sort order of the given characters</returns>
    public override int Compare(char x, char y)
    {
        return char.ToUpperInvariant(x).CompareTo(char.ToUpperInvariant(y));
    }

    /// <summary>
    /// Returns the hash code of the character
    /// </summary>
    /// <param name="c">The character</param>
    /// <returns>The hash code of the character</returns>
    public override int GetHashCode(char c)
    {
     
        return char.ToUpperInvariant(c).GetHashCode();
    }
}
