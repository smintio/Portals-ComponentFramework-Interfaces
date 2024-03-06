Description
===========
This README describes the properties of an `LocalizedStringsArrayModel`.

Current version of this document is: 1.0.0 (as of 5th of March, 2024)

- A representation of a fully localized property.
- If no language-specific value is available for a particular language, the `x-default` value should be used. Otherwise, values for specific languages such as `en`, `de` and etc.

## Properties

- `Key`: string - The language code (e.g. "x-default", "en", "de" and others).
- `Value`: string[] - An array of localized strings corresponding to the language.

Contributors
============

- Reinhard Holzner, Smint.io GmbH
- Yosif Velev, Smint.io GmbH