// *****************************************************************************
// Copyright (c) Fabricale(TM)
// Licensed under the Apache License, Version 2.0
// *****************************************************************************

using System;
using System.Collections.Generic;
using System.Text;

namespace Fabricale.Extensions;

/// <summary>
/// Represents the structure of a find/replace operation
/// </summary>
public struct MultiReplaceOptions
{
    /// <summary>
    /// The string to be found
    /// </summary>
    public string StringToFind { get; set; }
    /// <summary>
    /// The replacement for the string to be found
    /// </summary>
    public string ReplacementString { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MultiReplaceOptions"/>
    /// </summary>
    /// <param name="stringToFind">The string to be found</param>
    /// <param name="replacementString">The replacement string</param>
    public MultiReplaceOptions(string? stringToFind, string? replacementString)
    {
        StringToFind = (stringToFind is null ? string.Empty : stringToFind);
        ReplacementString = (replacementString is null ? string.Empty : replacementString);
    }
}