# Starlib.NET 

Starlib.NET is a library for all of my .NET projects that provides general functionality, such as logging, noise, recursive copy, system information, some string, byte, vector, file, math, and array utility functions, SDL and Freetype (and in the future, OpenGL) bindings, and an INI file parser. It was salvaged from the ruins of the [Lightning](https://github.com/starfrost013/Lightning2) game engine project as it was one of the few parts that actually functioned correctly and then cleaned up for release. It will be improved over time and there is also intended to be a C++ version eventually for my C++ projects.

## Build Requirements

StarLib requires:

* .NET 7.0.100 or later
* Visual Studio 2022 version 17.4 or later

to build, and nothing else! It only uses the core .NET framework and does not use any external libraries for functionality.

There are two projects:

* The `Starlib.Utilities` project contains all of the general utilities (everything except the SDL).
* The `Starlib.Bindings` project contains all of the bindings for managed code (except things used internally such as system RAM detection)

You can grab both projects from NuGet as individual packages if you want to:

* `Starlib.Bindings`: https://www.nuget.org/packages/Starlib.Bindings/1.0.1
* `Starlib.Utilties`: https://www.nuget.org/packages/Starlib.Utilities/1.0.1