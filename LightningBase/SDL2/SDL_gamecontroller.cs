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
using static Starlib.Base.Utf8Marshaling;
#endregion

namespace Starlib.Base
{
    public static partial class SDL
    {
        #region SDL_gamecontroller.h

        public enum SDL_GameControllerBindType
        {
            SDL_CONTROLLER_BINDTYPE_NONE,
            SDL_CONTROLLER_BINDTYPE_BUTTON,
            SDL_CONTROLLER_BINDTYPE_AXIS,
            SDL_CONTROLLER_BINDTYPE_HAT
        }

        public enum SDL_GameControllerAxis
        {
            SDL_CONTROLLER_AXIS_INVALID = -1,
            SDL_CONTROLLER_AXIS_LEFTX,
            SDL_CONTROLLER_AXIS_LEFTY,
            SDL_CONTROLLER_AXIS_RIGHTX,
            SDL_CONTROLLER_AXIS_RIGHTY,
            SDL_CONTROLLER_AXIS_TRIGGERLEFT,
            SDL_CONTROLLER_AXIS_TRIGGERRIGHT,
            SDL_CONTROLLER_AXIS_MAX
        }

        public enum SDL_GameControllerButton
        {
            SDL_CONTROLLER_BUTTON_INVALID = -1,
            SDL_CONTROLLER_BUTTON_A,
            SDL_CONTROLLER_BUTTON_B,
            SDL_CONTROLLER_BUTTON_X,
            SDL_CONTROLLER_BUTTON_Y,
            SDL_CONTROLLER_BUTTON_BACK,
            SDL_CONTROLLER_BUTTON_GUIDE,
            SDL_CONTROLLER_BUTTON_START,
            SDL_CONTROLLER_BUTTON_LEFTSTICK,
            SDL_CONTROLLER_BUTTON_RIGHTSTICK,
            SDL_CONTROLLER_BUTTON_LEFTSHOULDER,
            SDL_CONTROLLER_BUTTON_RIGHTSHOULDER,
            SDL_CONTROLLER_BUTTON_DPAD_UP,
            SDL_CONTROLLER_BUTTON_DPAD_DOWN,
            SDL_CONTROLLER_BUTTON_DPAD_LEFT,
            SDL_CONTROLLER_BUTTON_DPAD_RIGHT,
            SDL_CONTROLLER_BUTTON_MISC1,
            SDL_CONTROLLER_BUTTON_PADDLE1,
            SDL_CONTROLLER_BUTTON_PADDLE2,
            SDL_CONTROLLER_BUTTON_PADDLE3,
            SDL_CONTROLLER_BUTTON_PADDLE4,
            SDL_CONTROLLER_BUTTON_TOUCHPAD,
            SDL_CONTROLLER_BUTTON_MAX,
        }

        public enum SDL_GameControllerType
        {
            SDL_CONTROLLER_TYPE_UNKNOWN = 0,
            SDL_CONTROLLER_TYPE_XBOX360,
            SDL_CONTROLLER_TYPE_XBOXONE,
            SDL_CONTROLLER_TYPE_PS3,
            SDL_CONTROLLER_TYPE_PS4,
            SDL_CONTROLLER_TYPE_NINTENDO_SWITCH_PRO,
            SDL_CONTROLLER_TYPE_VIRTUAL,        /* Requires >= 2.0.14 */
            SDL_CONTROLLER_TYPE_PS5,        /* Requires >= 2.0.14 */
            SDL_CONTROLLER_TYPE_AMAZON_LUNA,    /* Requires >= 2.0.16 */
            SDL_CONTROLLER_TYPE_GOOGLE_STADIA   /* Requires >= 2.0.16 */
        }

        // FIXME: I'd rather this somehow be private...
        [StructLayout(LayoutKind.Sequential)]
        public struct INTERNAL_GameControllerButtonBind_hat
        {
            public int hat;
            public int hat_mask;
        }

        // FIXME: I'd rather this somehow be private...
        [StructLayout(LayoutKind.Explicit)]
        public struct INTERNAL_GameControllerButtonBind_union
        {
            [FieldOffset(0)]
            public int button;
            [FieldOffset(0)]
            public int axis;
            [FieldOffset(0)]
            public INTERNAL_GameControllerButtonBind_hat hat;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_GameControllerButtonBind
        {
            public SDL_GameControllerBindType bindType;
            public INTERNAL_GameControllerButtonBind_union value;
        }

        /* This exists to deal with C# being stupid about blittable types. */
        [StructLayout(LayoutKind.Sequential)]
        private struct INTERNAL_SDL_GameControllerButtonBind
        {
            public int bindType;
            /* Largest data type in the union is two ints in size */
            public int unionVal0;
            public int unionVal1;
        }

        [DllImport(nativeLibName, EntryPoint = "SDL_GameControllerAddMapping", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe int INTERNAL_SDL_GameControllerAddMapping(
            byte* mappingString
        );
        public static unsafe int SDL_GameControllerAddMapping(
            string mappingString
        )
        {
            byte* utf8MappingString = Utf8EncodeHeap(mappingString);
            int result = INTERNAL_SDL_GameControllerAddMapping(
                utf8MappingString
            );
            Marshal.FreeHGlobal((nint)utf8MappingString);
            return result;
        }

        /* Only available in 2.0.6 or higher. */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerNumMappings();

        /* Only available in 2.0.6 or higher. */
        [DllImport(nativeLibName, EntryPoint = "SDL_GameControllerMappingForIndex", CallingConvention = CallingConvention.Cdecl)]
        private static extern nint INTERNAL_SDL_GameControllerMappingForIndex(int mapping_index);
        public static string SDL_GameControllerMappingForIndex(int mapping_index)
        {
            return UTF8_ToManaged(
                INTERNAL_SDL_GameControllerMappingForIndex(
                    mapping_index
                ),
                true
            );
        }

        /* THIS IS AN RWops FUNCTION! */
        [DllImport(nativeLibName, EntryPoint = "SDL_GameControllerAddMappingsFromRW", CallingConvention = CallingConvention.Cdecl)]
        private static extern int INTERNAL_SDL_GameControllerAddMappingsFromRW(
            nint rw,
            int freerw
        );
        public static int SDL_GameControllerAddMappingsFromFile(string file)
        {
            nint rwops = SDL_RWFromFile(file, "rb");
            return INTERNAL_SDL_GameControllerAddMappingsFromRW(rwops, 1);
        }

        [DllImport(nativeLibName, EntryPoint = "SDL_GameControllerMappingForGUID", CallingConvention = CallingConvention.Cdecl)]
        private static extern nint INTERNAL_SDL_GameControllerMappingForGUID(
            Guid guid
        );
        public static string SDL_GameControllerMappingForGUID(Guid guid)
        {
            return UTF8_ToManaged(
                INTERNAL_SDL_GameControllerMappingForGUID(guid),
                true
            );
        }

        /* gamecontroller refers to an SDL_GameController* */
        [DllImport(nativeLibName, EntryPoint = "SDL_GameControllerMapping", CallingConvention = CallingConvention.Cdecl)]
        private static extern nint INTERNAL_SDL_GameControllerMapping(
            nint gamecontroller
        );
        public static string SDL_GameControllerMapping(
            nint gamecontroller
        )
        {
            return UTF8_ToManaged(
                INTERNAL_SDL_GameControllerMapping(
                    gamecontroller
                ),
                true
            );
        }

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_IsGameController(int joystick_index);

        [DllImport(nativeLibName, EntryPoint = "SDL_GameControllerNameForIndex", CallingConvention = CallingConvention.Cdecl)]
        private static extern nint INTERNAL_SDL_GameControllerNameForIndex(
            int joystick_index
        );
        public static string SDL_GameControllerNameForIndex(
            int joystick_index
        )
        {
            return UTF8_ToManaged(
                INTERNAL_SDL_GameControllerNameForIndex(joystick_index)
            );
        }

        /* Only available in 2.0.9 or higher. */
        [DllImport(nativeLibName, EntryPoint = "SDL_GameControllerMappingForDeviceIndex", CallingConvention = CallingConvention.Cdecl)]
        private static extern nint INTERNAL_SDL_GameControllerMappingForDeviceIndex(
            int joystick_index
        );
        public static string SDL_GameControllerMappingForDeviceIndex(
            int joystick_index
        )
        {
            return UTF8_ToManaged(
                INTERNAL_SDL_GameControllerMappingForDeviceIndex(joystick_index),
                true
            );
        }

        /* nint refers to an SDL_GameController* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nint SDL_GameControllerOpen(int joystick_index);

        /* gamecontroller refers to an SDL_GameController* */
        [DllImport(nativeLibName, EntryPoint = "SDL_GameControllerName", CallingConvention = CallingConvention.Cdecl)]
        private static extern nint INTERNAL_SDL_GameControllerName(
            nint gamecontroller
        );
        public static string SDL_GameControllerName(
            nint gamecontroller
        )
        {
            return UTF8_ToManaged(
                INTERNAL_SDL_GameControllerName(gamecontroller)
            );
        }

        /* gamecontroller refers to an SDL_GameController*.
		 * Only available in 2.0.6 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_GameControllerGetVendor(
            nint gamecontroller
        );

        /* gamecontroller refers to an SDL_GameController*.
		 * Only available in 2.0.6 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_GameControllerGetProduct(
            nint gamecontroller
        );

        /* gamecontroller refers to an SDL_GameController*.
		 * Only available in 2.0.6 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_GameControllerGetProductVersion(
            nint gamecontroller
        );

        /* gamecontroller refers to an SDL_GameController*.
		 * Only available in 2.0.14 or higher.
		 */
        [DllImport(nativeLibName, EntryPoint = "SDL_GameControllerGetSerial", CallingConvention = CallingConvention.Cdecl)]
        private static extern nint INTERNAL_SDL_GameControllerGetSerial(
            nint gamecontroller
        );
        public static string SDL_GameControllerGetSerial(
            nint gamecontroller
        )
        {
            return UTF8_ToManaged(
                INTERNAL_SDL_GameControllerGetSerial(gamecontroller)
            );
        }

        /* gamecontroller refers to an SDL_GameController* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_GameControllerGetAttached(
            nint gamecontroller
        );

        /* nint refers to an SDL_Joystick*
		 * gamecontroller refers to an SDL_GameController*
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nint SDL_GameControllerGetJoystick(
            nint gamecontroller
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerEventState(int state);

        /* gamecontroller refers to an SDL_GameController*. Currently for DualSense (PS5 controller) ONLY!
         * Only available in 2.24.0 or higher */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerGetFirmwareVersion(nint gameController);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GameControllerUpdate();

        [DllImport(nativeLibName, EntryPoint = "SDL_GameControllerGetAxisFromString", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe SDL_GameControllerAxis INTERNAL_SDL_GameControllerGetAxisFromString(
            byte* pchString
        );
        public static unsafe SDL_GameControllerAxis SDL_GameControllerGetAxisFromString(
            string pchString
        )
        {
            int utf8PchStringBufSize = Utf8Size(pchString);
            byte* utf8PchString = stackalloc byte[utf8PchStringBufSize];
            return INTERNAL_SDL_GameControllerGetAxisFromString(
                Utf8Encode(pchString, utf8PchString, utf8PchStringBufSize)
            );
        }

        [DllImport(nativeLibName, EntryPoint = "SDL_GameControllerGetStringForAxis", CallingConvention = CallingConvention.Cdecl)]
        private static extern nint INTERNAL_SDL_GameControllerGetStringForAxis(
            SDL_GameControllerAxis axis
        );
        public static string SDL_GameControllerGetStringForAxis(
            SDL_GameControllerAxis axis
        )
        {
            return UTF8_ToManaged(
                INTERNAL_SDL_GameControllerGetStringForAxis(
                    axis
                )
            );
        }

        /* gamecontroller refers to an SDL_GameController* */
        [DllImport(nativeLibName, EntryPoint = "SDL_GameControllerGetBindForAxis", CallingConvention = CallingConvention.Cdecl)]
        private static extern INTERNAL_SDL_GameControllerButtonBind INTERNAL_SDL_GameControllerGetBindForAxis(
            nint gamecontroller,
            SDL_GameControllerAxis axis
        );
        public static SDL_GameControllerButtonBind SDL_GameControllerGetBindForAxis(
            nint gamecontroller,
            SDL_GameControllerAxis axis
        )
        {
            // This is guaranteed to never be null
            INTERNAL_SDL_GameControllerButtonBind dumb = INTERNAL_SDL_GameControllerGetBindForAxis(
                gamecontroller,
                axis
            );
            SDL_GameControllerButtonBind result = new SDL_GameControllerButtonBind();
            result.bindType = (SDL_GameControllerBindType)dumb.bindType;
            result.value.hat.hat = dumb.unionVal0;
            result.value.hat.hat_mask = dumb.unionVal1;
            return result;
        }

        /* gamecontroller refers to an SDL_GameController* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern short SDL_GameControllerGetAxis(
            nint gamecontroller,
            SDL_GameControllerAxis axis
        );

        [DllImport(nativeLibName, EntryPoint = "SDL_GameControllerGetButtonFromString", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe SDL_GameControllerButton INTERNAL_SDL_GameControllerGetButtonFromString(
            byte* pchString
        );
        public static unsafe SDL_GameControllerButton SDL_GameControllerGetButtonFromString(
            string pchString
        )
        {
            int utf8PchStringBufSize = Utf8Size(pchString);
            byte* utf8PchString = stackalloc byte[utf8PchStringBufSize];
            return INTERNAL_SDL_GameControllerGetButtonFromString(
                Utf8Encode(pchString, utf8PchString, utf8PchStringBufSize)
            );
        }

        [DllImport(nativeLibName, EntryPoint = "SDL_GameControllerGetStringForButton", CallingConvention = CallingConvention.Cdecl)]
        private static extern nint INTERNAL_SDL_GameControllerGetStringForButton(
            SDL_GameControllerButton button
        );
        public static string SDL_GameControllerGetStringForButton(
            SDL_GameControllerButton button
        )
        {
            return UTF8_ToManaged(
                INTERNAL_SDL_GameControllerGetStringForButton(button)
            );
        }

        /* gamecontroller refers to an SDL_GameController* */
        [DllImport(nativeLibName, EntryPoint = "SDL_GameControllerGetBindForButton", CallingConvention = CallingConvention.Cdecl)]
        private static extern INTERNAL_SDL_GameControllerButtonBind INTERNAL_SDL_GameControllerGetBindForButton(
            nint gamecontroller,
            SDL_GameControllerButton button
        );
        public static SDL_GameControllerButtonBind SDL_GameControllerGetBindForButton(
            nint gamecontroller,
            SDL_GameControllerButton button
        )
        {
            // This is guaranteed to never be null
            INTERNAL_SDL_GameControllerButtonBind dumb = INTERNAL_SDL_GameControllerGetBindForButton(
                gamecontroller,
                button
            );
            SDL_GameControllerButtonBind result = new SDL_GameControllerButtonBind();
            result.bindType = (SDL_GameControllerBindType)dumb.bindType;
            result.value.hat.hat = dumb.unionVal0;
            result.value.hat.hat_mask = dumb.unionVal1;
            return result;
        }

        /* gamecontroller refers to an SDL_GameController* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte SDL_GameControllerGetButton(
            nint gamecontroller,
            SDL_GameControllerButton button
        );

        /* gamecontroller refers to an SDL_GameController*.
		 * Only available in 2.0.9 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerRumble(
            nint gamecontroller,
            UInt16 low_frequency_rumble,
            UInt16 high_frequency_rumble,
            UInt32 duration_ms
        );

        /* gamecontroller refers to an SDL_GameController*.
		 * Only available in 2.0.14 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerRumbleTriggers(
            nint gamecontroller,
            UInt16 left_rumble,
            UInt16 right_rumble,
            UInt32 duration_ms
        );

        /* gamecontroller refers to an SDL_GameController* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GameControllerClose(
            nint gamecontroller
        );

        /* int refers to an SDL_JoystickID, nint to an SDL_GameController*.
		 * Only available in 2.0.4 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nint SDL_GameControllerFromInstanceID(int joyid);

        /* Only available in 2.0.11 or higher. */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_GameControllerType SDL_GameControllerTypeForIndex(
            int joystick_index
        );

        /* nint refers to an SDL_GameController*.
		 * Only available in 2.0.11 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_GameControllerType SDL_GameControllerGetType(
            nint gamecontroller
        );

        /* nint refers to an SDL_GameController*.
		 * Only available in 2.0.11 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nint SDL_GameControllerFromPlayerIndex(
            int player_index
        );

        /* nint refers to an SDL_GameController*.
		 * Only available in 2.0.11 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GameControllerSetPlayerIndex(
            nint gamecontroller,
            int player_index
        );

        /* gamecontroller refers to an SDL_GameController*.
		 * Only available in 2.0.14 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_GameControllerHasLED(
            nint gamecontroller
        );

        /* gamecontroller refers to an SDL_GameController*.
		 * Only available in 2.0.18 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_GameControllerHasRumble(
            nint gamecontroller
        );

        /* gamecontroller refers to an SDL_GameController*.
		 * Only available in 2.0.18 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_GameControllerHasRumbleTriggers(
            nint gamecontroller
        );

        /* gamecontroller refers to an SDL_GameController*.
		 * Only available in 2.0.14 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerSetLED(
            nint gamecontroller,
            byte red,
            byte green,
            byte blue
        );

        /* gamecontroller refers to an SDL_GameController*.
		 * Only available in 2.0.14 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_GameControllerHasAxis(
            nint gamecontroller,
            SDL_GameControllerAxis axis
        );

        /* gamecontroller refers to an SDL_GameController*.
		 * Only available in 2.0.14 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_GameControllerHasButton(
            nint gamecontroller,
            SDL_GameControllerButton button
        );

        /* gamecontroller refers to an SDL_GameController*.
		 * Only available in 2.0.14 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerGetNumTouchpads(
            nint gamecontroller
        );

        /* gamecontroller refers to an SDL_GameController*.
		 * Only available in 2.0.14 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerGetNumTouchpadFingers(
            nint gamecontroller,
            int touchpad
        );

        /* gamecontroller refers to an SDL_GameController*.
		 * Only available in 2.0.14 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerGetTouchpadFinger(
            nint gamecontroller,
            int touchpad,
            int finger,
            out byte state,
            out float x,
            out float y,
            out float pressure
        );

        /* gamecontroller refers to an SDL_GameController*.
		 * Only available in 2.0.14 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_GameControllerHasSensor(
            nint gamecontroller,
            SDL_SensorType type
        );

        /* gamecontroller refers to an SDL_GameController*.
		 * Only available in 2.0.14 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerSetSensorEnabled(
            nint gamecontroller,
            SDL_SensorType type,
            SDL_bool enabled
        );

        /* gamecontroller refers to an SDL_GameController*.
		 * Only available in 2.0.14 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_GameControllerIsSensorEnabled(
            nint gamecontroller,
            SDL_SensorType type
        );

        /* gamecontroller refers to an SDL_GameController*.
		 * data refers to a float*.
		 * Only available in 2.0.14 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerGetSensorData(
            nint gamecontroller,
            SDL_SensorType type,
            nint data,
            int num_values
        );

        /* gamecontroller refers to an SDL_GameController*.
        * Only available in 2.0.14 or higher.
        */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerGetSensorData(
            nint gamecontroller,
            SDL_SensorType type,
            [In] float[] data,
            int num_values
        );

        /* gamecontroller refers to an SDL_GameController*.
		 * Only available in 2.0.16 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float SDL_GameControllerGetSensorDataRate(
            nint gamecontroller,
            SDL_SensorType type
        );

        /* gamecontroller refers to an SDL_GameController*.
		 * data refers to a const void*.
		 * Only available in 2.0.16 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerSendEffect(
            nint gamecontroller,
            nint data,
            int size
        );

        /* gamecontroller refers to an SDL_GameController*
		* Only available in 2.0.18 or higher.
		*/
        [DllImport(nativeLibName, EntryPoint = "SDL_GameControllerGetAppleSFSymbolsNameForButton", CallingConvention = CallingConvention.Cdecl)]
        private static extern nint INTERNAL_SDL_GameControllerGetAppleSFSymbolsNameForButton(
            nint gamecontroller,
            SDL_GameControllerButton button
        );
        public static string SDL_GameControllerGetAppleSFSymbolsNameForButton(
            nint gamecontroller,
            SDL_GameControllerButton button
        )
        {
            return UTF8_ToManaged(
                INTERNAL_SDL_GameControllerGetAppleSFSymbolsNameForButton(gamecontroller, button)
            );
        }

        /* gamecontroller refers to an SDL_GameController*
		 * Only available in 2.0.18 or higher.
		 */
        [DllImport(nativeLibName, EntryPoint = "SDL_GameControllerGetAppleSFSymbolsNameForAxis", CallingConvention = CallingConvention.Cdecl)]
        private static extern nint INTERNAL_SDL_GameControllerGetAppleSFSymbolsNameForAxis(
            nint gamecontroller,
            SDL_GameControllerAxis axis
        );
        public static string SDL_GameControllerGetAppleSFSymbolsNameForAxis(
            nint gamecontroller,
            SDL_GameControllerAxis axis
        )
        {
            return UTF8_ToManaged(
                INTERNAL_SDL_GameControllerGetAppleSFSymbolsNameForAxis(gamecontroller, axis)
            );
        }


        #endregion
    }
}
