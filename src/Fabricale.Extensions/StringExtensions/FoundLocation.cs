// *****************************************************************************
// Copyright (c) Fabricale(TM)
// Licensed under the Apache License, Version 2.0
// *****************************************************************************

using System;
using System.Collections.Generic;
using System.Text;

namespace Fabricale.Extensions;

/// <summary>
/// A structure representing a location where a term was found
/// </summary>
public struct FoundLocation
{
    /// <summary>
    /// The Index of the Term
    /// </summary>
    public int IndexOfTerm { get; set; }

    /// <summary>
    /// The position where the text starts
    /// </summary>
    public int StartPosition { get; set; }

    /// <summary>
    /// The position where the text ends
    /// </summary>
    public int EndPosition { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="FoundLocation"/> Structure
    /// </summary>
    /// <param name="startPosition">The position where the text starts</param>
    /// <param name="endPosition">The position where the text ends</param>
    public FoundLocation(int startPosition, int endPosition) : this(0, startPosition, endPosition) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="FoundLocation"/> Structure
    /// </summary>
    /// <param name="indexOfTerm">The Index of the Term</param>
    /// <param name="startPosition">The position where the text starts</param>
    /// <param name="endPosition">The position where the text ends</param>
    public FoundLocation(int indexOfTerm, int startPosition, int endPosition)
    {
        IndexOfTerm = indexOfTerm;
        StartPosition = startPosition;
        EndPosition = endPosition;
    }
}