Description
===========
This README describes the properties of an `LocalizedStringsModel`.

Current version of this document is: 1.0.0 (as of 5th of March, 2024)

- A representation of a fully localized property.

## Properties

- `Key`: string - The language code (e.g. "x-default", "en", "de" and others).
- `Value`: string - The localized string corresponding to the language.

## How to resolve the value for a specific language

- First search for an exact match of the language code
- If no match is available, use the `x-default` value
- If no match is available, use the first entry

Contributors
============

- Reinhard Holzner, Smint.io GmbH
- Yosif Velev, Smint.io GmbH