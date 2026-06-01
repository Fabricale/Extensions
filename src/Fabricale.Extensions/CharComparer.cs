using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Fabricale.Extensions;

/// <summary>
/// Represents the base class of a Char Comparer
/// </summary>
public abstract class CharComparer: IEqualityComparer<char>, IComparer<char>
{
    private static readonly CharComparer caseInsensitiveCharComparer = new CaseInsensitiveCharComparer();

    private static readonly CharComparer caseSensitiveCharComparer = new CaseSensitiveCharComparer();

    /// <summary>
    /// Initializes a new instance of the <see cref="CharComparer"/> class
    /// </summary>
    protected CharComparer()
    {

    }

    /// <inheritdoc/>>
    public abstract bool Equals(char x, char y);

    /// <inheritdoc/>>
    public abstract int Compare(char x, char y);

#if NETSTANDARD2_0_OR_GREATER || NET471_OR_GREATER
    
    /// <inheritdoc/>
    public abstract int GetHashCode(char x);

#else

    /// <inheritdoc/>
    public abstract int GetHashCode([DisallowNull] char obj);

#endif

    /// <summary>
    /// Gets a <see cref="CharComparer"/> object that does <b>Case Insensitive</b> character comparisons
    /// </summary>
    public static CharComparer CaseInsensitive => caseInsensitiveCharComparer;

    /// <summary>
    /// Gets a <see cref="CharComparer"/> object that does <b>Case Sensitive</b> character comparisons
    /// </summary>
    public static CharComparer CaseSensitive => caseSensitiveCharComparer;


}
