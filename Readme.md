This repository demonstrates a bug in the 05/14/18 C# [Nullable Reference Types Preview](https://github.com/dotnet/csharplang/wiki/Nullable-Reference-Types-Preview) with Visual Studio 2017 15.7.1. It corresponds to [dotnet/roslyn#27014](https://github.com/dotnet/roslyn/issues/27014).

# Project Setup

The project consists of one file `TestClass.cs` which has multiple variations of the same class containing a static property, `TestProperty`, as well as a static field, `testField`.

Additionally, the base case (`TestClass`) contains an instance property and an instance field.

Following that, there are variations of the base case with and without null initializers or a static constructor.

In all cases, the properties/fields are never initialized, making them `null`.

# Actual Behavior

Warnings are only reported when both the initializers and the static constrctor are present.

# Expected Behavior

There should be warnings for all properties and fields in all of the examples.
