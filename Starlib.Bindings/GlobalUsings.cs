﻿/*
StarLib.NET Base
Copyright © 2022-2023 Connor Hyde ("starfrost")

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files 
(the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, 
merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished 
to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

// This file provides global using statements.
// Don't put any usings in individual source files, put any you need to use in here.

#region Global using statements
global using Starlib.Utilities;
global using System;
global using System.Diagnostics;
global using System.Diagnostics.CodeAnalysis;
global using System.IO;
global using System.Reflection;
global using System.Runtime.InteropServices;
#if X64
global using System.Runtime.Intrinsics.X86;
#else
global using System.Runtime.Intrinsics.Arm;
#endif
global using System.Runtime.Versioning;
global using System.Text;
global using System.Security;
global using static Starlib.Bindings.SDL;
global using static Starlib.Bindings.SDL_mixer;
#endregion