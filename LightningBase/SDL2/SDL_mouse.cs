﻿#region License
/* Lightning SDL2 Wrapper
 * 
 * Version 3.1.0
 * Copyright © 2022 starfrost
 * August 31, 2022
 * 
 * This software is based on the open-source SDL2# - C# Wrapper for SDL2 library.
 *
 * Copyright © 2013-2021 Ethan Lee.
 * Copyright © 2022 starfrost
 * 
 * This software is provided 'as-is', without any express or implied warranty.
 * In no event will the authors be held liable for any damages arising from
 * the use of this software.
 *
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 *
 * 1. The origin of this software must not be misrepresented; you must not
 * claim that you wrote the original software. If you use this software in a
 * product, an acknowledgment in the product documentation would be
 * appreciated but is not required.
 *
 * 2. Altered source versions must be plainly marked as such, and must not be
 * misrepresented as being the original software.
 *
 * 3. This notice may not be removed or altered from any source distribution.
 *
 * Ethan "flibitijibibo" Lee <flibitijibibo@flibitijibibo.com>
 *
 */
#endregion

#region Using Statements
#endregion

namespace LightningBase
{
    public static partial class SDL
    {
        #region SDL_mouse.c

        /* Note: SDL_Cursor is a typedef normally. We'll treat it as
		 * an nint, because C# doesn't do typedefs. Yay!
		 */

        /* System cursor types */
        public enum SDL_SystemCursor
        {
            SDL_SYSTEM_CURSOR_ARROW,    // Arrow
            SDL_SYSTEM_CURSOR_IBEAM,    // I-beam
            SDL_SYSTEM_CURSOR_WAIT,     // Wait
            SDL_SYSTEM_CURSOR_CROSSHAIR,    // Crosshair
            SDL_SYSTEM_CURSOR_WAITARROW,    // Small wait cursor (or Wait if not available)
            SDL_SYSTEM_CURSOR_SIZENWSE, // Double arrow pointing northwest and southeast
            SDL_SYSTEM_CURSOR_SIZENESW, // Double arrow pointing northeast and southwest
            SDL_SYSTEM_CURSOR_SIZEWE,   // Double arrow pointing west and east
            SDL_SYSTEM_CURSOR_SIZENS,   // Double arrow pointing north and south
            SDL_SYSTEM_CURSOR_SIZEALL,  // Four pointed arrow pointing north, south, east, and west
            SDL_SYSTEM_CURSOR_NO,       // Slashed circle or crossbones
            SDL_SYSTEM_CURSOR_HAND,     // Hand
            SDL_NUM_SYSTEM_CURSORS
        }

        /* Get the window which currently has mouse focus */
        /* Return value is an SDL_Window pointer */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nint SDL_GetMouseFocus();

        /* Get the current state of the mouse */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 SDL_GetMouseState(out int x, out int y);

        /* Get the current state of the mouse */
        /* This overload allows for passing NULL to x */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 SDL_GetMouseState(nint x, out int y);

        /* Get the current state of the mouse */
        /* This overload allows for passing NULL to y */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 SDL_GetMouseState(out int x, nint y);

        /* Get the current state of the mouse */
        /* This overload allows for passing NULL to both x and y */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 SDL_GetMouseState(nint x, nint y);

        /* Get the current state of the mouse, in relation to the desktop.
		 * Only available in 2.0.4 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 SDL_GetGlobalMouseState(out int x, out int y);

        /* Get the current state of the mouse, in relation to the desktop.
		 * Only available in 2.0.4 or higher.
		 * This overload allows for passing NULL to x.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 SDL_GetGlobalMouseState(nint x, out int y);

        /* Get the current state of the mouse, in relation to the desktop.
		 * Only available in 2.0.4 or higher.
		 * This overload allows for passing NULL to y.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 SDL_GetGlobalMouseState(out int x, nint y);

        /* Get the current state of the mouse, in relation to the desktop.
		 * Only available in 2.0.4 or higher.
		 * This overload allows for passing NULL to both x and y
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 SDL_GetGlobalMouseState(nint x, nint y);

        /* Get the mouse state with relative coords*/
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 SDL_GetRelativeMouseState(out int x, out int y);

        /* Set the mouse cursor's position (within a window) */
        /* window is an SDL_Window pointer */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_WarpMouseInWindow(nint window, int x, int y);

        /* Set the mouse cursor's position in global screen space.
		 * Only available in 2.0.4 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_WarpMouseGlobal(int x, int y);

        /* Enable/Disable relative mouse mode (grabs mouse, rel coords) */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetRelativeMouseMode(SDL_bool enabled);

        /* Capture the mouse, to track input outside an SDL window.
		 * Only available in 2.0.4 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_CaptureMouse(SDL_bool enabled);

        /* Query if the relative mouse mode is enabled */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_GetRelativeMouseMode();

        /* Create a cursor from bitmap data (amd mask) in MSB format.
		 * data and mask are byte arrays, and w must be a multiple of 8.
		 * return value is an SDL_Cursor pointer.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nint SDL_CreateCursor(
            nint data,
            nint mask,
            int w,
            int h,
            int hot_x,
            int hot_y
        );

        /* Create a cursor from an SDL_Surface.
		 * nint refers to an SDL_Cursor*, surface to an SDL_Surface*
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nint SDL_CreateColorCursor(
            nint surface,
            int hot_x,
            int hot_y
        );

        /* Create a cursor from a system cursor id.
		 * return value is an SDL_Cursor pointer
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nint SDL_CreateSystemCursor(SDL_SystemCursor id);

        /* Set the active cursor.
		 * cursor is an SDL_Cursor pointer
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetCursor(nint cursor);

        /* Return the active cursor
		 * return value is an SDL_Cursor pointer
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nint SDL_GetCursor();

        /* Frees a cursor created with one of the CreateCursor functions.
		 * cursor in an SDL_Cursor pointer
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FreeCursor(nint cursor);

        /* Toggle whether or not the cursor is shown */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_ShowCursor(int toggle);

        public static uint SDL_BUTTON(uint X)
        {
            // If only there were a better way of doing this in C#
            return (uint)(1 << ((int)X - 1));
        }

        // Used for SDL_GetMouseMotion
        public static readonly UInt32 SDL_BUTTON_LMASK = SDL_BUTTON((uint)SDL_MouseButton.Left);
        public static readonly UInt32 SDL_BUTTON_MMASK = SDL_BUTTON((uint)SDL_MouseButton.Middle);
        public static readonly UInt32 SDL_BUTTON_RMASK = SDL_BUTTON((uint)SDL_MouseButton.Right);
        public static readonly UInt32 SDL_BUTTON_X1MASK = SDL_BUTTON((uint)SDL_MouseButton.X1);
        public static readonly UInt32 SDL_BUTTON_X2MASK = SDL_BUTTON((uint)SDL_MouseButton.X2);

        #endregion
    }
}
