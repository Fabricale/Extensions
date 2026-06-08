# Change Log

This document contains the change log for each version deployed.

# Version v1.1.0

This release contains the following:

| Component | Purpose |
| ------ | ------- |
| `DateTimeExtensions` | Extension Methods for the `DateTime` class |

# Version v1.0.0

This release contains the following:

| Component | Purpose |
| ------ | ------- |
| `StringExtensions` | Extension Methods for the `string` class |
| `CharComparer` | object to be used to compare characters in a `HashSet<char>` |

# Version v0.1.0-alpha.3 (Pre-Release)

This pre-release version introduces the `CharComparer` class, and derived classes.

| Class | Purpose |
| ----- | ------- |
| `CharComparer` | Base class for Char Comparison, to be used in HashSets |
| `CaseSensitiveCharComparer` | This class compare two characters and ensure the casing is taken into consideration |
| `CaseInsensitiveCharComparer` | This class compares two characters, ignoring the casing |

# Version v0.1.0-alpha.2 (Pre-Release)

This pre-release version introduces additional extension methods for the `string` class.

| Method | Purpose |
| ------ | ------- |
| `ContainsOnly()` | Checks whether a string contains only certain characters |
| `ContainsOnlyNumbers()` | Checks whether a string only contains numbers |
| `ContainsOnlyAsciiLetters()` | Checks whether a string only contains Ascii letters |
| `ContainsOnlyAsciiLettersAndNumbers()` | Checks whether a string only contains Ascii letters and numbers |

# Version v0.1.0-alpha.1 (Pre-Release)

This pre-release version contains extension methods for the `string` class.

| Method | Purpose |
| ------ | ------- |
| `Find()` | Returns a list with all the locations where the text is found in a string |
| `MultiReplace()` | Replaces multiple instances of a string in the text |
