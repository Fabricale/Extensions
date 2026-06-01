# Change Log

This document contains the change log for each version deployed.

# Version v1.0.0

This release contains the following:

- Extension Methods for the `string` class
- A `CharComparer` object to be used to compare characters in a `HashSet<char>`

## Details

### StringExtensions

The following extension methods are introduced in this release.

| Method | Purpose |
| ------ | ------- |
| `Find()` | Returns a list with all the locations where the text is found in a string |
| `MultiReplace()` | Replaces multiple instances of a string in the text |
| `ContainsOnly()` | Checks whether a string contains only certain characters |
| `ContainsOnlyNumbers()` | Checks whether a string only contains numbers |
| `ContainsOnlyAsciiLetters()` | Checks whether a string only contains Ascii letters |
| `ContainsOnlyAsciiLettersAndNumbers()` | Checks whether a string only contains Ascii letters and numbers |
| `ConvertToAsciiBooleanArray()` | Generates a boolean array with the ASCII characters inside the given string |

### CharComparer

The `CharComparer` and its derived classes are introduces in this release.

| Class | Purpose |
| ----- | ------- |
| `CharComparer` | Base class for Char Comparison, to be used in HashSets |
| `CaseSensitiveCharComparer` | This class compare two characters and ensure the casing is taken into consideration |
| `CaseInsensitiveCharComparer` | This class compares two characters, ignoring the casing |

## Pre-Releases

### v0.1.0-alpha.3

This pre-release version introduces the `CharComparer` class, and derived classes.

| Class | Purpose |
| ----- | ------- |
| `CharComparer` | Base class for Char Comparison, to be used in HashSets |
| `CaseSensitiveCharComparer` | This class compare two characters and ensure the casing is taken into consideration |
| `CaseInsensitiveCharComparer` | This class compares two characters, ignoring the casing |


### v0.1.0-alpha.2

This pre-release version introduces additional extension methods for the `string` class.

| Method | Purpose |
| ------ | ------- |
| `ContainsOnly()` | Checks whether a string contains only certain characters |
| `ContainsOnlyNumbers()` | Checks whether a string only contains numbers |
| `ContainsOnlyAsciiLetters()` | Checks whether a string only contains Ascii letters |
| `ContainsOnlyAsciiLettersAndNumbers()` | Checks whether a string only contains Ascii letters and numbers |

### v0.1.0-alpha.1

This pre-release version contains extension methods for the `string` class.

| Method | Purpose |
| ------ | ------- |
| `Find()` | Returns a list with all the locations where the text is found in a string |
| `MultiReplace()` | Replaces multiple instances of a string in the text |

