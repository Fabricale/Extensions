# Fabricale Extensions

[![nuget](https://img.shields.io/nuget/v/Fabricale.Extensions.svg)](https://www.nuget.org/packages/Fabricale.Extensions/) 
![GitHub release](https://img.shields.io/github/release/Fabricale/Extensions.svg)
![NuGet](https://img.shields.io/nuget/dt/Fabricale.Extensions.svg)
![license](https://img.shields.io/github/license/Fabricale/Extensions.svg)

A library providing extension methods.

This library is still under development and more updates are being released. 

Check the [Change Log](https://github.com/Fabricale/Extensions/blob/main/CHANGELOG.md) for more information about the deployed changes.

## String Extensions

The library provides the following extensions to the `string` class:

| Method | Purpose |
| ------ | ------- |
| `Find()` | Returns a list with all the locations where the text is found in a string |
| `MultiReplace()` | Replaces multiple instances of a string in the text |
| `ContainsOnly()` | Checks whether a string contains only certain characters |
| `ContainsOnlyNumbers()` | Checks whether a string only contains numbers |
| `ContainsOnlyAsciiLetters()` | Checks whether a string only contains Ascii letters |
| `ContainsOnlyAsciiLettersAndNumbers()` | Checks whether a string only contains Ascii letters and numbers |
| `ConvertToAsciiBooleanArray()` | Generates a boolean array with the ASCII characters inside the given string |

These methods are optimized for performance. The ASCII specific methods use an array of booleans to make the search fast. The Non-ASCII specific methods use a HashSet, which adds the cost of the hashing to the search, but still keep it fast.

The functionality is tested with Unicode characters.

> The functions `Find()` and `MultiReplace()` are going to be optimized for better performance in a future release. After running benchmarks, the performance is not much better than just using the traditional `String.Replace()` method. When this optimization is deployed, you will not need to execute changes to your code to benefit from it.

When using the `ContainsOnly()` method, there is a constructor available that accepts a `HashSet<char>`. If the same characters are used frequently, consider reusing it instead of creating the HashSet on each call.

If you have a specific list of ASCII characters that you want to check, consider using the extension method `ConvertToAsciiBolleanArray()` to create an array with the acceptable characters, and cache it.

## DateTime Extensions

The library provides the following extensions to the `string` class:

| Method | Purpose |
| ------ | ------- |
| `AddBusinesDays()` | Adds or Subtracts Business Days to a Date |
| `ToJulian()` | Converts a `DateTime` into a `double` representing the Julian Date |

The `AddBusinessDays()` function will add or subtract days, ignoring weekends. Holidays are not taken into consideration. A future release should include that functionality.

## CharComparer

This class offers the option to compare characters.

The following comparers are available:

| Class | Purpose |
| ----- | ------- |
| `CaseSensitiveCharComparer` | This class compare two characters and ensure the casing is taken into consideration |
| `CaseInsensitiveCharComparer` | This class compares two characters, ignoring the casing |

