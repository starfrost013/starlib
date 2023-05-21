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
using System.Runtime.Versioning;
using static Starlib.Bindings.Utf8Marshaling;
#endregion

namespace Starlib.Bindings
{
    public static partial class SDL
    {
        #region 2.0.0 hints
        public const string SDL_HINT_FRAMEBUFFER_ACCELERATION =
            "SDL_FRAMEBUFFER_ACCELERATION";
        public const string SDL_HINT_RENDER_DRIVER =
            "SDL_RENDER_DRIVER";
        public const string SDL_HINT_RENDER_OPENGL_SHADERS =
            "SDL_RENDER_OPENGL_SHADERS";
        public const string SDL_HINT_RENDER_DIRECT3D_THREADSAFE =
            "SDL_RENDER_DIRECT3D_THREADSAFE";
        public const string SDL_HINT_RENDER_VSYNC =
            "SDL_RENDER_VSYNC";
        [Obsolete("Removed in SDL 3.0 (Xvidmode support removed)")]
        public const string SDL_HINT_VIDEO_X11_XVIDMODE =
            "SDL_VIDEO_X11_XVIDMODE";
        [Obsolete("Removed in SDL 3.0 (Xinerama support removed)")]
        public const string SDL_HINT_VIDEO_X11_XINERAMA =
            "SDL_VIDEO_X11_XINERAMA";
        public const string SDL_HINT_VIDEO_X11_XRANDR =
            "SDL_VIDEO_X11_XRANDR";
        public const string SDL_HINT_GRAB_KEYBOARD =
            "SDL_GRAB_KEYBOARD";
        public const string SDL_HINT_VIDEO_MINIMIZE_ON_FOCUS_LOSS =
            "SDL_VIDEO_MINIMIZE_ON_FOCUS_LOSS";
        [Obsolete("Replaced with the SDL_DisableScreenSaver function in SDL 3.0")]
        public const string SDL_HINT_IDLE_TIMER_DISABLED =
            "SDL_IOS_IDLE_TIMER_DISABLED";
        public const string SDL_HINT_ORIENTATIONS =
            "SDL_IOS_ORIENTATIONS";
        public const string SDL_HINT_XINPUT_ENABLED =
            "SDL_XINPUT_ENABLED";
        public const string SDL_HINT_GAMECONTROLLERCONFIG =
            "SDL_GAMECONTROLLERCONFIG";
        public const string SDL_HINT_JOYSTICK_ALLOW_BACKGROUND_EVENTS =
            "SDL_JOYSTICK_ALLOW_BACKGROUND_EVENTS";
        public const string SDL_HINT_ALLOW_TOPMOST =
            "SDL_ALLOW_TOPMOST";
        public const string SDL_HINT_TIMER_RESOLUTION =
            "SDL_TIMER_RESOLUTION";
        public const string SDL_HINT_RENDER_SCALE_QUALITY =
            "SDL_RENDER_SCALE_QUALITY";
        #endregion

        #region 2.0.1 hints
        /* Only available in SDL 2.0.1 or higher. */
        public const string SDL_HINT_VIDEO_HIGHDPI_DISABLED =
            "SDL_VIDEO_HIGHDPI_DISABLED";
        #endregion

        #region 2.0.2 hints
        /* Only available in SDL 2.0.2 or higher. */
        public const string SDL_HINT_MAC_CTRL_CLICK_EMULATE_RIGHT_CLICK =
            "SDL_CTRL_MAC_CLICK_EMULATE_RIGHT_CLICK";
        public const string SDL_HINT_VIDEO_WIN_D3DCOMPILER =
            "SDL_VIDEO_WIN_D3DCOMPILER";
        public const string SDL_HINT_MOUSE_RELATIVE_MODE_WARP =
            "SDL_MOUSE_RELATIVE_MODE_WARP";
        public const string SDL_HINT_VIDEO_WINDOW_SHARE_PIXEL_FORMAT =
            "SDL_VIDEO_WINDOW_SHARE_PIXEL_FORMAT";
        public const string SDL_HINT_VIDEO_ALLOW_SCREENSAVER =
            "SDL_VIDEO_ALLOW_SCREENSAVER";
        public const string SDL_HINT_ACCELEROMETER_AS_JOYSTICK =
            "SDL_ACCELEROMETER_AS_JOYSTICK";
        public const string SDL_HINT_VIDEO_MAC_FULLSCREEN_SPACES =
            "SDL_VIDEO_MAC_FULLSCREEN_SPACES";
        #endregion

        #region 2.0.3 hints
        /* Only available in SDL 2.0.3 or higher. */
        public const string SDL_HINT_WINRT_PRIVACY_POLICY_URL =
            "SDL_WINRT_PRIVACY_POLICY_URL";
        public const string SDL_HINT_WINRT_PRIVACY_POLICY_LABEL =
            "SDL_WINRT_PRIVACY_POLICY_LABEL";
        public const string SDL_HINT_WINRT_HANDLE_BACK_BUTTON =
            "SDL_WINRT_HANDLE_BACK_BUTTON";
        #endregion

        #region 2.0.4 hints
        /* Only available in SDL 2.0.4 or higher. */
        public const string SDL_HINT_NO_SIGNAL_HANDLERS =
            "SDL_NO_SIGNAL_HANDLERS";
        public const string SDL_HINT_IME_INTERNAL_EDITING =
            "SDL_IME_INTERNAL_EDITING";
        public const string SDL_HINT_ANDROID_SEPARATE_MOUSE_AND_TOUCH =
            "SDL_ANDROID_SEPARATE_MOUSE_AND_TOUCH";
        public const string SDL_HINT_EMSCRIPTEN_KEYBOARD_ELEMENT =
            "SDL_EMSCRIPTEN_KEYBOARD_ELEMENT";
        public const string SDL_HINT_THREAD_STACK_SIZE =
            "SDL_THREAD_STACK_SIZE";
        public const string SDL_HINT_WINDOW_FRAME_USABLE_WHILE_CURSOR_HIDDEN =
            "SDL_WINDOW_FRAME_USABLE_WHILE_CURSOR_HIDDEN";
        public const string SDL_HINT_WINDOWS_ENABLE_MESSAGELOOP =
            "SDL_WINDOWS_ENABLE_MESSAGELOOP";
        public const string SDL_HINT_WINDOWS_NO_CLOSE_ON_ALT_F4 =
            "SDL_WINDOWS_NO_CLOSE_ON_ALT_F4";
        public const string SDL_HINT_XINPUT_USE_OLD_JOYSTICK_MAPPING =
            "SDL_XINPUT_USE_OLD_JOYSTICK_MAPPING";
        public const string SDL_HINT_MAC_BACKGROUND_APP =
            "SDL_MAC_BACKGROUND_APP";
        public const string SDL_HINT_VIDEO_X11_NET_WM_PING =
            "SDL_VIDEO_X11_NET_WM_PING";
        public const string SDL_HINT_ANDROID_APK_EXPANSION_MAIN_FILE_VERSION =
            "SDL_ANDROID_APK_EXPANSION_MAIN_FILE_VERSION";
        public const string SDL_HINT_ANDROID_APK_EXPANSION_PATCH_FILE_VERSION =
            "SDL_ANDROID_APK_EXPANSION_PATCH_FILE_VERSION";
        #endregion

        #region 2.0.5 hints
        /* Only available in 2.0.5 or higher. */
        public const string SDL_HINT_MOUSE_FOCUS_CLICKTHROUGH =
            "SDL_MOUSE_FOCUS_CLICKTHROUGH";
        public const string SDL_HINT_BMP_SAVE_LEGACY_FORMAT =
            "SDL_BMP_SAVE_LEGACY_FORMAT";
        public const string SDL_HINT_WINDOWS_DISABLE_THREAD_NAMING =
            "SDL_WINDOWS_DISABLE_THREAD_NAMING";
        public const string SDL_HINT_APPLE_TV_REMOTE_ALLOW_ROTATION =
            "SDL_APPLE_TV_REMOTE_ALLOW_ROTATION";
        #endregion

        #region 2.0.6 hints
        /* Only available in 2.0.6 or higher. */
        public const string SDL_HINT_AUDIO_RESAMPLING_MODE =
            "SDL_AUDIO_RESAMPLING_MODE";
        public const string SDL_HINT_RENDER_LOGICAL_SIZE_MODE =
            "SDL_RENDER_LOGICAL_SIZE_MODE";
        public const string SDL_HINT_MOUSE_NORMAL_SPEED_SCALE =
            "SDL_MOUSE_NORMAL_SPEED_SCALE";
        public const string SDL_HINT_MOUSE_RELATIVE_SPEED_SCALE =
            "SDL_MOUSE_RELATIVE_SPEED_SCALE";
        public const string SDL_HINT_TOUCH_MOUSE_EVENTS =
            "SDL_TOUCH_MOUSE_EVENTS";
        public const string SDL_HINT_WINDOWS_INTRESOURCE_ICON =
            "SDL_WINDOWS_INTRESOURCE_ICON";
        public const string SDL_HINT_WINDOWS_INTRESOURCE_ICON_SMALL =
            "SDL_WINDOWS_INTRESOURCE_ICON_SMALL";
        #endregion

        #region 2.0.8 hints
        /* Only available in 2.0.8 or higher. */
        public const string SDL_HINT_IOS_HIDE_HOME_INDICATOR =
            "SDL_IOS_HIDE_HOME_INDICATOR";
        public const string SDL_HINT_TV_REMOTE_AS_JOYSTICK =
            "SDL_TV_REMOTE_AS_JOYSTICK";
        public const string SDL_VIDEO_X11_NET_WM_BYPASS_COMPOSITOR =
            "SDL_VIDEO_X11_NET_WM_BYPASS_COMPOSITOR";
        #endregion

        #region 2.0.9 hints
        /* Only available in 2.0.9 or higher. */
        public const string SDL_HINT_MOUSE_DOUBLE_CLICK_TIME =
            "SDL_MOUSE_DOUBLE_CLICK_TIME";
        public const string SDL_HINT_MOUSE_DOUBLE_CLICK_RADIUS =
            "SDL_MOUSE_DOUBLE_CLICK_RADIUS";
        public const string SDL_HINT_JOYSTICK_HIDAPI =
            "SDL_JOYSTICK_HIDAPI";
        public const string SDL_HINT_JOYSTICK_HIDAPI_PS4 =
            "SDL_JOYSTICK_HIDAPI_PS4";
        public const string SDL_HINT_JOYSTICK_HIDAPI_PS4_RUMBLE =
            "SDL_JOYSTICK_HIDAPI_PS4_RUMBLE";
        public const string SDL_HINT_JOYSTICK_HIDAPI_STEAM =
            "SDL_JOYSTICK_HIDAPI_STEAM";
        public const string SDL_HINT_JOYSTICK_HIDAPI_SWITCH =
            "SDL_JOYSTICK_HIDAPI_SWITCH";
        public const string SDL_HINT_JOYSTICK_HIDAPI_XBOX =
            "SDL_JOYSTICK_HIDAPI_XBOX";
        public const string SDL_HINT_ENABLE_STEAM_CONTROLLERS =
            "SDL_ENABLE_STEAM_CONTROLLERS";
        public const string SDL_HINT_ANDROID_TRAP_BACK_BUTTON =
            "SDL_ANDROID_TRAP_BACK_BUTTON";
        #endregion

        #region 2.0.10 hints
        /* Only available in 2.0.10 or higher. */
        public const string SDL_HINT_MOUSE_TOUCH_EVENTS =
            "SDL_MOUSE_TOUCH_EVENTS";
        public const string SDL_HINT_GAMECONTROLLERCONFIG_FILE =
            "SDL_GAMECONTROLLERCONFIG_FILE";
        public const string SDL_HINT_ANDROID_BLOCK_ON_PAUSE =
            "SDL_ANDROID_BLOCK_ON_PAUSE";
        public const string SDL_HINT_RENDER_BATCHING =
            "SDL_RENDER_BATCHING";
        public const string SDL_HINT_EVENT_LOGGING =
            "SDL_EVENT_LOGGING";
        public const string SDL_HINT_WAVE_RIFF_CHUNK_SIZE =
            "SDL_WAVE_RIFF_CHUNK_SIZE";
        public const string SDL_HINT_WAVE_TRUNCATION =
            "SDL_WAVE_TRUNCATION";
        public const string SDL_HINT_WAVE_FACT_CHUNK =
            "SDL_WAVE_FACT_CHUNK";
        #endregion

        #region 2.0.11 hints
        /* Only available in 2.0.11 or higher. */
        public const string SDL_HINT_VIDO_X11_WINDOW_VISUALID =
            "SDL_VIDEO_X11_WINDOW_VISUALID";
        public const string SDL_HINT_GAMECONTROLLER_USE_BUTTON_LABELS =
            "SDL_GAMECONTROLLER_USE_BUTTON_LABELS";
        public const string SDL_HINT_VIDEO_EXTERNAL_CONTEXT =
            "SDL_VIDEO_EXTERNAL_CONTEXT";
        public const string SDL_HINT_JOYSTICK_HIDAPI_GAMECUBE =
            "SDL_JOYSTICK_HIDAPI_GAMECUBE";
        public const string SDL_HINT_DISPLAY_USABLE_BOUNDS =
            "SDL_DISPLAY_USABLE_BOUNDS";
        [Obsolete("Replaced with the SDL_HINT_VIDEO_FORCE_EGL hint in SDL 3.0")]
        public const string SDL_HINT_VIDEO_X11_FORCE_EGL =
            "SDL_VIDEO_X11_FORCE_EGL";
        public const string SDL_HINT_GAMECONTROLLERTYPE =
            "SDL_GAMECONTROLLERTYPE";
        #endregion

        #region 2.0.14 hints
        /* Only available in 2.0.14 or higher. */
        public const string SDL_HINT_JOYSTICK_HIDAPI_CORRELATE_XINPUT =
            "SDL_JOYSTICK_HIDAPI_CORRELATE_XINPUT"; /* NOTE: This was removed in 2.0.16. */
        public const string SDL_HINT_JOYSTICK_RAWINPUT =
            "SDL_JOYSTICK_RAWINPUT";
        public const string SDL_HINT_AUDIO_DEVICE_APP_NAME =
            "SDL_AUDIO_DEVICE_APP_NAME";
        public const string SDL_HINT_AUDIO_DEVICE_STREAM_NAME =
            "SDL_AUDIO_DEVICE_STREAM_NAME";
        public const string SDL_HINT_PREFERRED_LOCALES =
            "SDL_PREFERRED_LOCALES";
        public const string SDL_HINT_THREAD_PRIORITY_POLICY =
            "SDL_THREAD_PRIORITY_POLICY";
        public const string SDL_HINT_EMSCRIPTEN_ASYNCIFY =
            "SDL_EMSCRIPTEN_ASYNCIFY";
        public const string SDL_HINT_LINUX_JOYSTICK_DEADZONES =
            "SDL_LINUX_JOYSTICK_DEADZONES";
        public const string SDL_HINT_ANDROID_BLOCK_ON_PAUSE_PAUSEAUDIO =
            "SDL_ANDROID_BLOCK_ON_PAUSE_PAUSEAUDIO";
        public const string SDL_HINT_JOYSTICK_HIDAPI_PS5 =
            "SDL_JOYSTICK_HIDAPI_PS5";
        public const string SDL_HINT_THREAD_FORCE_REALTIME_TIME_CRITICAL =
            "SDL_THREAD_FORCE_REALTIME_TIME_CRITICAL";
        public const string SDL_HINT_JOYSTICK_THREAD =
            "SDL_JOYSTICK_THREAD";
        public const string SDL_HINT_AUTO_UPDATE_JOYSTICKS =
            "SDL_AUTO_UPDATE_JOYSTICKS";
        public const string SDL_HINT_AUTO_UPDATE_SENSORS =
            "SDL_AUTO_UPDATE_SENSORS";
        public const string SDL_HINT_MOUSE_RELATIVE_SCALING =
            "SDL_MOUSE_RELATIVE_SCALING";
        public const string SDL_HINT_JOYSTICK_HIDAPI_PS5_RUMBLE =
            "SDL_JOYSTICK_HIDAPI_PS5_RUMBLE";
        #endregion

        #region 2.0.16 hints
        /* Only available in 2.0.16 or higher. */
        public const string SDL_HINT_WINDOWS_FORCE_MUTEX_CRITICAL_SECTIONS =
            "SDL_WINDOWS_FORCE_MUTEX_CRITICAL_SECTIONS";
        public const string SDL_HINT_WINDOWS_FORCE_SEMAPHORE_KERNEL =
            "SDL_WINDOWS_FORCE_SEMAPHORE_KERNEL";
        public const string SDL_HINT_JOYSTICK_HIDAPI_PS5_PLAYER_LED =
            "SDL_JOYSTICK_HIDAPI_PS5_PLAYER_LED";
        public const string SDL_HINT_WINDOWS_USE_D3D9EX =
            "SDL_WINDOWS_USE_D3D9EX";
        public const string SDL_HINT_JOYSTICK_HIDAPI_JOY_CONS =
            "SDL_JOYSTICK_HIDAPI_JOY_CONS";
        public const string SDL_HINT_JOYSTICK_HIDAPI_STADIA =
            "SDL_JOYSTICK_HIDAPI_STADIA";
        public const string SDL_HINT_JOYSTICK_HIDAPI_SWITCH_HOME_LED =
            "SDL_JOYSTICK_HIDAPI_SWITCH_HOME_LED";
        public const string SDL_HINT_ALLOW_ALT_TAB_WHILE_GRABBED =
            "SDL_ALLOW_ALT_TAB_WHILE_GRABBED";
        public const string SDL_HINT_KMSDRM_REQUIRE_DRM_MASTER =
            "SDL_KMSDRM_REQUIRE_DRM_MASTER";
        public const string SDL_HINT_AUDIO_DEVICE_STREAM_ROLE =
            "SDL_AUDIO_DEVICE_STREAM_ROLE";
        public const string SDL_HINT_X11_FORCE_OVERRIDE_REDIRECT =
            "SDL_X11_FORCE_OVERRIDE_REDIRECT";
        public const string SDL_HINT_JOYSTICK_HIDAPI_LUNA =
            "SDL_JOYSTICK_HIDAPI_LUNA";
        public const string SDL_HINT_JOYSTICK_RAWINPUT_CORRELATE_XINPUT =
            "SDL_JOYSTICK_RAWINPUT_CORRELATE_XINPUT";
        public const string SDL_HINT_AUDIO_INCLUDE_MONITORS =
            "SDL_AUDIO_INCLUDE_MONITORS";
        public const string SDL_HINT_VIDEO_WAYLAND_ALLOW_LIBDECOR =
            "SDL_VIDEO_WAYLAND_ALLOW_LIBDECOR";
        #endregion

        #region 2.0.18 hints
        /* Only available in 2.0.18 or higher. */
        public const string SDL_HINT_VIDEO_EGL_ALLOW_TRANSPARENCY =
            "SDL_VIDEO_EGL_ALLOW_TRANSPARENCY";
        public const string SDL_HINT_APP_NAME =
            "SDL_APP_NAME";
        public const string SDL_HINT_SCREENSAVER_INHIBIT_ACTIVITY_NAME =
            "SDL_SCREENSAVER_INHIBIT_ACTIVITY_NAME";
        public const string SDL_HINT_IME_SHOW_UI =
            "SDL_IME_SHOW_UI";
        public const string SDL_HINT_WINDOW_NO_ACTIVATION_WHEN_SHOWN =
            "SDL_WINDOW_NO_ACTIVATION_WHEN_SHOWN";
        public const string SDL_HINT_POLL_SENTINEL =
            "SDL_POLL_SENTINEL";
        public const string SDL_HINT_JOYSTICK_DEVICE =
            "SDL_JOYSTICK_DEVICE";
        public const string SDL_HINT_LINUX_JOYSTICK_CLASSIC =
            "SDL_LINUX_JOYSTICK_CLASSIC";

        #endregion

        #region 2.0.20 hints
        /* Only available in 2.0.20 or higher. */
        public const string SDL_HINT_RENDER_LINE_METHOD =
            "SDL_RENDER_LINE_METHOD";
        #endregion

        #region 2.0.22 hints
        /* Only available in 2.0.22 or higher. */
        public const string SDL_HINT_FORCE_RAISEWINDOW =
            "SDL_HINT_FORCE_RAISEWINDOW";
        public const string SDL_HINT_IME_SUPPORT_EXTENDED_TEXT =
            "SDL_IME_SUPPORT_EXTENDED_TEXT";
        public const string SDL_HINT_JOYSTICK_GAMECUBE_RUMBLE_BRAKE =
            "SDL_JOYSTICK_GAMECUBE_RUMBLE_BRAKE";
        public const string SDL_HINT_JOYSTICK_ROG_CHAKRAM =
            "SDL_JOYSTICK_ROG_CHAKRAM";
        public const string SDL_HINT_MOUSE_RELATIVE_MODE_CENTER =
            "SDL_MOUSE_RELATIVE_MODE_CENTER";
        public const string SDL_HINT_MOUSE_AUTO_CAPTURE =
            "SDL_MOUSE_AUTO_CAPTURE";
        public const string SDL_HINT_VITA_TOUCH_MOUSE_DEVICE =
            "SDL_HINT_VITA_TOUCH_MOUSE_DEVICE";
        public const string SDL_HINT_VIDEO_WAYLAND_PREFER_LIBDECOR =
            "SDL_VIDEO_WAYLAND_PREFER_LIBDECOR";
        public const string SDL_HINT_VIDEO_FOREIGN_WINDOW_OPENGL =
            "SDL_VIDEO_FOREIGN_WINDOW_OPENGL";
        public const string SDL_HINT_VIDEO_FOREIGN_WINDOW_VULKAN =
            "SDL_VIDEO_FOREIGN_WINDOW_VULKAN";
        public const string SDL_HINT_X11_WINDOW_TYPE =
            "SDL_X11_WINDOW_TYPE";
        public const string SDL_HINT_QUIT_ON_LAST_WINDOW_CLOSE =
            "SDL_QUIT_ON_LAST_WINDOW_CLOSE";
        #endregion

        #region 2.24.0 hints
        /* Only available in 2.24.0 or higher. */
        public const string SDL_HINT_MOUSE_RELATIVE_WARP_MOTION =
            "SDL_HINT_MOUSE_RELATIVE_WARP_MOTION";
        public const string SDL_HINT_TRACKPAD_IS_TOUCH_ONLY =
            "SDL_HINT_TRACKPAD_IS_TOUCH_ONLY";
        public const string SDL_HINT_JOYSTICK_HIDAPI_JOYCON_HOME_LED =
            "SDL_HINT_JOYSTICK_HIDAPI_JOYCON_HOME_LED";
        public const string SDL_HINT_JOYSTICK_HIDAPI_SWITCH_PLAYER_LED =
            "SDL_HINT_JOYSTICK_HIDAPI_SWITCH_PLAYER_LED";
        public const string SDL_HINT_JOYSTICK_HIDAPI_NINTENDO_CLASSIC =
            "SDL_HINT_JOYSTICK_HIDAPI_NINTENDO_CLASSIC";
        public const string SDL_HINT_JOYSTICK_HIDAPI_SHIELD =
            "SDL_HINT_JOYSTICK_HIDAPI_SHIELD";
        public const string SDL_HINT_WINDOWS_DPI_AWARENESS =
            "SDL_HINT_WINDOWS_DPI_AWARENESS";
        public const string SDL_HINT_WINDOWS_DPI_SCALING =
            "SDL_HINT_WINDOWS_DPI_SCALING";
        public const string SDL_HINT_DIRECTINPUT_ENABLED =
            "SDL_HINT_DIRECTINPUT_ENABLED";
        public const string SDL_HINT_VIDEO_WAYLAND_MODE_EMULATION =
            "SDL_HINT_VIDEO_WAYLAND_MODE_EMULATION";
        public const string SDL_HINT_KMSDRM_DEVICE_INDEX =
            "SDL_HINT_KMSDRM_DEVICE_INDEX";
        public const string SDL_HINT_LINUX_DIGITAL_HATS =
            "SDL_HINT_LINUX_DIGITAL_HATS";
        public const string SDL_HINT_LINUX_HAT_DEADZONES =
            "SDL_HINT_LINUX_HAT_DEADZONES";
        #endregion

        #region 2.26.0 hints
        /* Only available in 2.26.0 or higher. */
        public const string SDL_HINT_JOYSTICK_HIDAPI_XBOX_360 =
            "SDL_HINT_JOYSTICK_HIDAPI_XBOX_360";

        public const string SDL_HINT_JOYSTICK_HIDAPI_XBOX_360_PLAYER_LED =
            "SDL_HINT_JOYSTICK_HIDAPI_XBOX_360_PLAYER_LED";

        public const string SDL_HINT_JOYSTICK_HIDAPI_XBOX_360_WIRELESS =
            "SDL_HINT_JOYSTICK_HIDAPI_XBOX_360_WIRELESS";

        public const string SDL_HINT_JOYSTICK_HIDAPI_XBOX_ONE =
            "SDL_HINT_JOYSTICK_HIDAPI_XBOX_ONE";

        public const string SDL_HINT_JOYSTICK_HIDAPI_XBOX_ONE_HOME_LED =
            "SDL_HINT_JOYSTICK_HIDAPI_XBOX_ONE_HOME_LED";

        public const string SDL_HINT_JOYSTICK_HIDAPI_WII_PLAYER_LED =
            "SDL_HINT_JOYSTICK_HIDAPI_WII_PLAYER_LED";

        public const string SDL_HINT_JOYSTICK_HIDAPI_VERTICAL_JOY_CONS =
            "SDL_HINT_JOYSTICK_HIDAPI_VERTICAL_JOY_CONS";

        [SupportedOSPlatform("windows")]
        public const string SDL_HINT_MOUSE_RELATIVE_SYSTEM_SCALE =
            "SDL_HINT_MOUSE_RELATIVE_SYSTEM_SCALE";

        public const string SDL_HINT_HIDAPI_IGNORE_DEVICES =
            "SDL_HINT_HIDAPI_IGNORE_DEVICES";

        #endregion

        #region Hint functions (SDL_hint.h)
        public enum SDL_HintPriority
        {
            SDL_HINT_DEFAULT,
            SDL_HINT_NORMAL,
            SDL_HINT_OVERRIDE
        }

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_ClearHints();

        [DllImport(nativeLibName, EntryPoint = "SDL_GetHint", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe nint INTERNAL_SDL_GetHint(byte* name);
        public static unsafe string SDL_GetHint(string name)
        {
            int utf8NameBufSize = Utf8Size(name);
            byte* utf8Name = stackalloc byte[utf8NameBufSize];
            return UTF8_ToManaged(
                INTERNAL_SDL_GetHint(
                    Utf8Encode(name, utf8Name, utf8NameBufSize)
                )
            );
        }

        [DllImport(nativeLibName, EntryPoint = "SDL_SetHint", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe SDL_bool INTERNAL_SDL_SetHint(
            byte* name,
            byte* value
        );
        public static unsafe SDL_bool SDL_SetHint(string name, string value)
        {
            int utf8NameBufSize = Utf8Size(name);
            byte* utf8Name = stackalloc byte[utf8NameBufSize];

            int utf8ValueBufSize = Utf8Size(value);
            byte* utf8Value = stackalloc byte[utf8ValueBufSize];

            return INTERNAL_SDL_SetHint(
                Utf8Encode(name, utf8Name, utf8NameBufSize),
                Utf8Encode(value, utf8Value, utf8ValueBufSize)
            );
        }

        [DllImport(nativeLibName, EntryPoint = "SDL_SetHintWithPriority", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe SDL_bool INTERNAL_SDL_SetHintWithPriority(
            byte* name,
            byte* value,
            SDL_HintPriority priority
        );
        public static unsafe SDL_bool SDL_SetHintWithPriority(
            string name,
            string value,
            SDL_HintPriority priority
        )
        {
            int utf8NameBufSize = Utf8Size(name);
            byte* utf8Name = stackalloc byte[utf8NameBufSize];

            int utf8ValueBufSize = Utf8Size(value);
            byte* utf8Value = stackalloc byte[utf8ValueBufSize];

            return INTERNAL_SDL_SetHintWithPriority(
                Utf8Encode(name, utf8Name, utf8NameBufSize),
                Utf8Encode(value, utf8Value, utf8ValueBufSize),
                priority
            );
        }

        /* Only available in 2.0.5 or higher. */
        [DllImport(nativeLibName, EntryPoint = "SDL_GetHintBoolean", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe SDL_bool INTERNAL_SDL_GetHintBoolean(
            byte* name,
            SDL_bool default_value
        );

        public static unsafe SDL_bool SDL_GetHintBoolean(
            string name,
            SDL_bool default_value
        )
        {
            int utf8NameBufSize = Utf8Size(name);
            byte* utf8Name = stackalloc byte[utf8NameBufSize];
            return INTERNAL_SDL_GetHintBoolean(
                Utf8Encode(name, utf8Name, utf8NameBufSize),
                default_value
            );
        }

        /* Only available in 2.24.0 or higher. */
        [DllImport(nativeLibName, EntryPoint = "SDL_ResetHint", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe SDL_bool INTERNAL_SDL_ResetHint
            (byte* name);

        public static unsafe SDL_bool SDL_ResetHint(
            string name
        )
        {
            int utf8NameBufSize = Utf8Size(name);
            byte* utf8Name = stackalloc byte[utf8NameBufSize];
            return INTERNAL_SDL_ResetHint
                (
                    Utf8Encode(name, utf8Name, utf8NameBufSize)
                );
        }


        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        /// <summary>
        /// Reset all hints.
        /// </summary>
        public static extern void SDL_ResetHints();

        #endregion
    }
}
