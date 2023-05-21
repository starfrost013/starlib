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
using static Starlib.Bindings.Utf8Marshaling;
#endregion

namespace Starlib.Bindings
{
    public static partial class SDL
    {
        #region SDL_joystick.h

        public const byte SDL_HAT_CENTERED = 0x00;
        public const byte SDL_HAT_UP = 0x01;
        public const byte SDL_HAT_RIGHT = 0x02;
        public const byte SDL_HAT_DOWN = 0x04;
        public const byte SDL_HAT_LEFT = 0x08;
        public const byte SDL_HAT_RIGHTUP = SDL_HAT_RIGHT | SDL_HAT_UP;
        public const byte SDL_HAT_RIGHTDOWN = SDL_HAT_RIGHT | SDL_HAT_DOWN;
        public const byte SDL_HAT_LEFTUP = SDL_HAT_LEFT | SDL_HAT_UP;
        public const byte SDL_HAT_LEFTDOWN = SDL_HAT_LEFT | SDL_HAT_DOWN;

        public enum SDL_JoystickPowerLevel
        {
            SDL_JOYSTICK_POWER_UNKNOWN = -1,
            SDL_JOYSTICK_POWER_EMPTY,
            SDL_JOYSTICK_POWER_LOW,
            SDL_JOYSTICK_POWER_MEDIUM,
            SDL_JOYSTICK_POWER_FULL,
            SDL_JOYSTICK_POWER_WIRED,
            SDL_JOYSTICK_POWER_MAX
        }

        public enum SDL_JoystickType
        {
            SDL_JOYSTICK_TYPE_UNKNOWN,
            SDL_JOYSTICK_TYPE_GAMECONTROLLER,
            SDL_JOYSTICK_TYPE_WHEEL,
            SDL_JOYSTICK_TYPE_ARCADE_STICK,
            SDL_JOYSTICK_TYPE_FLIGHT_STICK,
            SDL_JOYSTICK_TYPE_DANCE_PAD,
            SDL_JOYSTICK_TYPE_GUITAR,
            SDL_JOYSTICK_TYPE_DRUM_KIT,
            SDL_JOYSTICK_TYPE_ARCADE_PAD
        }

        /* Only available in 2.0.14 or higher. */
        public const float SDL_IPHONE_MAX_GFORCE = 5.0f;

        /* joystick refers to an SDL_Joystick*.
		 * Only available in 2.0.9 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickRumble(
            nint joystick,
            UInt16 low_frequency_rumble,
            UInt16 high_frequency_rumble,
            UInt32 duration_ms
        );

        /* joystick refers to an SDL_Joystick*.
		 * Only available in 2.0.14 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickRumbleTriggers(
            nint joystick,
            UInt16 left_rumble,
            UInt16 right_rumble,
            UInt32 duration_ms
        );

        /* joystick refers to an SDL_Joystick* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_JoystickClose(nint joystick);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickEventState(int state);

        /* joystick refers to an SDL_Joystick* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern short SDL_JoystickGetAxis(
            nint joystick,
            int axis
        );

        /* joystick refers to an SDL_Joystick*.
		 * Only available in 2.0.6 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_JoystickGetAxisInitialState(
            nint joystick,
            int axis,
            out short state
        );

        /* joystick refers to an SDL_Joystick* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickGetBall(
            nint joystick,
            int ball,
            out int dx,
            out int dy
        );

        /* joystick refers to an SDL_Joystick* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte SDL_JoystickGetButton(
            nint joystick,
            int button
        );

        /* joystick refers to an SDL_Joystick* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte SDL_JoystickGetHat(
            nint joystick,
            int hat
        );

        /* joystick refers to an SDL_Joystick*.
         * Only available in 2.24.0 or higher */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickGetFirmwareVersion(nint joystick);

        /* joystick refers to an SDL_Joystick* */
        [DllImport(nativeLibName, EntryPoint = "SDL_JoystickName", CallingConvention = CallingConvention.Cdecl)]
        private static extern nint INTERNAL_SDL_JoystickName(
            nint joystick
        );
        public static string SDL_JoystickName(nint joystick)
        {
            return UTF8_ToManaged(
                INTERNAL_SDL_JoystickName(joystick)
            );
        }

        [DllImport(nativeLibName, EntryPoint = "SDL_JoystickNameForIndex", CallingConvention = CallingConvention.Cdecl)]
        private static extern nint INTERNAL_SDL_JoystickNameForIndex(
            int device_index
        );
        public static string SDL_JoystickNameForIndex(int device_index)
        {
            return UTF8_ToManaged(
                INTERNAL_SDL_JoystickNameForIndex(device_index)
            );
        }

        /* joystick refers to an SDL_Joystick* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickNumAxes(nint joystick);

        /* joystick refers to an SDL_Joystick* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickNumBalls(nint joystick);

        /* joystick refers to an SDL_Joystick* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickNumButtons(nint joystick);

        /* joystick refers to an SDL_Joystick* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickNumHats(nint joystick);

        /* nint refers to an SDL_Joystick* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nint SDL_JoystickOpen(int device_index);

        /* joystick refers to an SDL_Joystick* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_JoystickUpdate();

        /* joystick refers to an SDL_Joystick* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_NumJoysticks();

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Guid SDL_JoystickGetDeviceGUID(
            int device_index
        );

        /* joystick refers to an SDL_Joystick* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Guid SDL_JoystickGetGUID(
            nint joystick
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_JoystickGetGUIDString(
            Guid guid,
            byte[] pszGUID,
            int cbGUID
        );

        [DllImport(nativeLibName, EntryPoint = "SDL_JoystickGetGUIDFromString", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe Guid INTERNAL_SDL_JoystickGetGUIDFromString(
            byte* pchGUID
        );
        public static unsafe Guid SDL_JoystickGetGUIDFromString(string pchGuid)
        {
            int utf8PchGuidBufSize = Utf8Size(pchGuid);
            byte* utf8PchGuid = stackalloc byte[utf8PchGuidBufSize];
            return INTERNAL_SDL_JoystickGetGUIDFromString(
                Utf8Encode(pchGuid, utf8PchGuid, utf8PchGuidBufSize)
            );
        }

        /* joystick refers to an SDL_Joystick* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetJoystickGUIDInfo(Guid guid,
            out ushort vendor,
            out ushort product,
            out ushort version,
            out ushort crc16);

        /* Only available in 2.0.6 or higher. */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_JoystickGetDeviceVendor(int device_index);

        /* Only available in 2.0.6 or higher. */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_JoystickGetDeviceProduct(int device_index);

        /* Only available in 2.0.6 or higher. */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_JoystickGetDeviceProductVersion(int device_index);

        /* Only available in 2.0.6 or higher. */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_JoystickType SDL_JoystickGetDeviceType(int device_index);

        /* int refers to an SDL_JoystickID.
		 * Only available in 2.0.6 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickGetDeviceInstanceID(int device_index);

        /* joystick refers to an SDL_Joystick*.
		 * Only available in 2.0.6 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_JoystickGetVendor(nint joystick);

        /* joystick refers to an SDL_Joystick*.
		 * Only available in 2.0.6 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_JoystickGetProduct(nint joystick);

        /* joystick refers to an SDL_Joystick*.
		 * Only available in 2.0.6 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_JoystickGetProductVersion(nint joystick);

        /* joystick refers to an SDL_Joystick*.
		 * Only available in 2.0.14 or higher.
		 */
        [DllImport(nativeLibName, EntryPoint = "SDL_JoystickGetSerial", CallingConvention = CallingConvention.Cdecl)]
        private static extern nint INTERNAL_SDL_JoystickGetSerial(
            nint joystick
        );
        public static string SDL_JoystickGetSerial(
            nint joystick
        )
        {
            return UTF8_ToManaged(
                INTERNAL_SDL_JoystickGetSerial(joystick)
            );
        }

        /* joystick refers to an SDL_Joystick*.
		 * Only available in 2.0.6 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_JoystickType SDL_JoystickGetType(nint joystick);

        /* joystick refers to an SDL_Joystick* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_JoystickGetAttached(nint joystick);

        /* int refers to an SDL_JoystickID, joystick to an SDL_Joystick* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickInstanceID(nint joystick);

        /* joystick refers to an SDL_Joystick*.
		 * Only available in 2.0.4 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_JoystickPowerLevel SDL_JoystickCurrentPowerLevel(
            nint joystick
        );

        /* int refers to an SDL_JoystickID, nint to an SDL_Joystick*.
		 * Only available in 2.0.4 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nint SDL_JoystickFromInstanceID(int instance_id);

        /* Only available in 2.0.7 or higher. */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LockJoysticks();

        /* Only available in 2.0.7 or higher. */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_UnlockJoysticks();

        /* nint refers to an SDL_Joystick*.
		 * Only available in 2.0.11 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nint SDL_JoystickFromPlayerIndex(int player_index);

        /* nint refers to an SDL_Joystick*.
		 * Only available in 2.0.11 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_JoystickSetPlayerIndex(
            nint joystick,
            int player_index
        );

        /* Int32 refers to an SDL_JoystickType.
		 * Only available in 2.0.14 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickAttachVirtual(
            Int32 type,
            int naxes,
            int nbuttons,
            int nhats
        );

        /* Only available in 2.24.0 or higher.*/
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct SDL_VirtualJoystickInfo
        {
            short version;
            short type;
            short naxes;
            short nbuttons;
            short nhats;
            short vendor_id;
            short product_id;
            short padding;
            // you need to convert this
            byte* name;
            nint userdata;
            nint update;
        }

        /* Only available in 2.24.0 or higher.
        */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickAttachVirtualEx(
            ref SDL_VirtualJoystickInfo stick
        );

        /* Only available in 2.0.14 or higher. */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickDetachVirtual(int device_index);

        /* Only available in 2.0.14 or higher. */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_JoystickIsVirtual(int device_index);

        /* nint refers to an SDL_Joystick*.
		 * Only available in 2.0.14 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickSetVirtualAxis(
            nint joystick,
            int axis,
            Int16 value
        );

        /* nint refers to an SDL_Joystick*.
		 * Only available in 2.0.14 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickSetVirtualButton(
            nint joystick,
            int button,
            byte value
        );

        /* nint refers to an SDL_Joystick*.
		 * Only available in 2.0.14 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickSetVirtualHat(
            nint joystick,
            int hat,
            byte value
        );

        /* nint refers to an SDL_Joystick*.
		 * Only available in 2.0.14 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_JoystickHasLED(nint joystick);


        /* nint refers to an SDL_Joystick*.
		 * Only available in 2.0.18 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_JoystickHasRumble(nint joystick);

        /* nint refers to an SDL_Joystick*.
		 * Only available in 2.0.18 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_JoystickHasRumbleTriggers(nint joystick);

        /* nint refers to an SDL_Joystick*.
		 * Only available in 2.0.14 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickSetLED(
            nint joystick,
            byte red,
            byte green,
            byte blue
        );

        /* joystick refers to an SDL_Joystick*.
		 * data refers to a const void*.
		 * Only available in 2.0.16 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickSendEffect(
            nint joystick,
            nint data,
            int size
        );

        #endregion
    }
}
